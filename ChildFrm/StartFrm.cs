using Aioi;
using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class StartFrm : Form
    {

        private static SerialPort serialPort = new SerialPort();
        private static string ReadingText = null;


        private int _context = 0;
        private string _adapterName = "";
        private IAdapter _adapter;
        //private string _iDm = "";
        private SmartTag _smartcard = null;
        private DisplayPainter _display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, true);

        private const string ACR1252 = "ACS ACR1252";

        private const string STATUSREADY = "Ready";
        private const string STATUSPROCESS = "Processing...";
        private const string STATUSTOUCH = "Touch Smart Card";
        private const string STATUSCOMPLETED = "Completed";





        public StartFrm()
        {
            InitializeComponent();
        }

        private void StartFrm_Load(object sender, EventArgs e)
        {
            string path0 = Environment.CurrentDirectory;

            string path1 = $"{path0}\\{Param.Setting}";

            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }

            Loadpattern();

            OpenPort();

            Init();
        }

        private void StartFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.Close();
                    serialPort.Dispose();
                }
            }
        }


        //===============================//
        #region  Sub Program


        private void Loadpattern()
        {
            string env = Environment.CurrentDirectory;
            string path = $"{env}\\Setting\\pattern.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Please Setup pattern first, SETUP -> PATTERN ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string data = File.ReadAllText(path);

            string[] parts = data.Split(',');
            if (parts.Length > 3)
            {
                Param.Patterns.TotalLength = int.Parse(parts[0]);
                Param.Patterns.Start = Convert.ToInt32(parts[1]);
                Param.Patterns.Length = Convert.ToInt32(parts[2]);
            }
        }

        private void OpenPort()
        {
            try
            {

                string directory = $"{Environment.CurrentDirectory}\\{Param.Setting}\\port.txt";
                string setting = File.ReadAllText(directory);

                string[] parts = setting.Split(',');
                if (parts.Length == 5)
                {
                    string comport = parts[0];
                    string BaudRate = parts[1];
                    string DataBits = parts[3];
                    string stopbit = parts[4];
                    string parity = parts[2];

                    int maxRetries = 3;
                    const int sleepTimeInMs = 500;
                    while (maxRetries > 0)
                    {
                        try
                        {
                            if (serialPort != null)
                            {

                                if (serialPort.IsOpen)
                                {
                                    serialPort.Close();
                                }
                            }
                            serialPort.PortName = comport;
                            serialPort.BaudRate = Convert.ToInt32(BaudRate);
                            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopbit);
                            serialPort.DataBits = Convert.ToInt16(DataBits);

                            serialPort.Handshake = Handshake.None;

                            if (!serialPort.IsOpen)
                                serialPort.Open();

                            if (serialPort.IsOpen)
                            {
                                serialPort.DiscardInBuffer();
                                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                                timer1.Enabled = true;

                                //BtnReload.BackColor = Color.Green;
                                //MessageBox.Show("AlReady to trial port", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }

                        catch (UnauthorizedAccessException)
                        {
                            maxRetries--;
                            Thread.Sleep(sleepTimeInMs);
                        }
                        catch (Exception exception)
                        {
                            maxRetries--;
                            Console.WriteLine(exception.Message);
                        }
                    }

                    if (maxRetries != 3)
                    {
                        //BtnReload.BackColor = Color.FromArgb(246, 246, 246);
                        MessageBox.Show("can not open port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            ReadingText = sp.ReadExisting().Trim('\r');

            serialPort.DiscardInBuffer();
        }

        private async void AsyncInsertTable(string partnumber)
        {
            TbScanner.Text = partnumber;
            using (var db = new DBContext())
            {

                var existData = await db.Smartcards.Where(x => x.Partnumber == partnumber)
                    .FirstOrDefaultAsync();
                if (existData == null)
                {
                    TbPartName1.Text =
                    TbPartName2.Text =
                    TbPartName3.Text = String.Empty;
                    return;
                }
                TbPartName1.Text = existData.Partname1;
                TbPartName2.Text = existData.Partname2;
                TbPartName3.Text = existData.Partname3;

                if (StartPolling())
                {
                    _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;
                    _smartcard.SetImageData(CreateImage(partnumber, existData.Partname1,
               existData.Partname2, existData.Partname3));


                }



                return;
            }
        }



        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ReadingText != null && ReadingText.Length == Param.Patterns.TotalLength)
            {
                ReadingText = ReadingText.Substring(Param.Patterns.Start, Param.Patterns.Length);
                AsyncInsertTable(ReadingText);
            }
            ReadingText = null;
        }




        private void Init()
        {
            try
            {
                //var iserror = false;

                int ret = PCSCModules.GetContext(ref _context);

                if (ret != PCSCModules.SCARD_S_SUCCESS)
                {
                    return;
                }
                _adapterName = PCSCModules.GetAdapters(_context)[0].ToUpper();

                if (_adapterName.Contains(ACR1252))
                {
                    _adapter = new ACR1252_Adapter();
                }
                else
                {
                    //WriteLog("No compatible adapters found");
                    return;
                }

                _adapter.OpenAdapter();
                _adapter.Name = _adapterName;
                _adapter.Context = _context;
                _smartcard = new SmartTag(_adapter);

                //WriteLog(_adapterName + " detected");
                //Label_Message.Text = STATUSREADY;
                //Label_IDm.Text = "---";
            }
            catch (Exception ex)
            {
                //WriteLog(ex.Message);
            }


        }

        private bool StartPolling()
        {
            if (_smartcard == null)
            {
                return false;
            }
            //Label_Message.Text = STATUSTOUCH;
            //Label_IDm.Text = "---";
            timer.Interval = 250;
            timer.Enabled = true;
            return true;
        }
        private ImageInfo CreateImage(string partnumber, string partname1, string partname2, string partname3)
        {
            DisplayPainter display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, false);

            string qrcode = $"{partnumber},{DateTime.Now:yyyy-MM-ddTHH:mm:ss}";
            var code39 = new QRCode();
            code39.BarcodeData = qrcode; ;
            code39.Height = 200;
            code39.RotateFlip = RotateFlipType.Rotate270FlipNone;
            display.PutBarcode(code39, 0, 25);


            display.PutText(partnumber, new Font("Arial", 28, FontStyle.Bold), 8, 5, false);
            display.PutLine(8, 45, 292, 45, 3, false);
            //display.PutLine(5, 48, 292, 48, 1, false);

            display.PutText(partname1, new Font("Arial", 17, FontStyle.Bold), 170, 70, false);
            display.PutText(partname2, new Font("Arial", 17, FontStyle.Bold), 170, 110, false);
            display.PutText(partname3, new Font("Arial", 17, FontStyle.Bold), 170, 150, false);



            //'Draws line




            return display.GetLocalDisplayImage();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_smartcard.Adapter.Poll())
            {
                timer.Enabled = false;
                try
                {
                    _smartcard.Adapter.OpenCard();
                }
                catch (Exception ex)
                {
                    //WriteLog("Card open failed - " + ex.Message);
                    return;
                }
                StartProcess();
            }
        }
        private void StartProcess()
        {
            try
            {
                byte[] idm = _adapter.GetIdm();
                //Label_IDm.Text = BitConverter.ToString(idm);

                //Label_Message.Text = STATUSPROCESS;
                this.Refresh();

                _smartcard.SetIdm(idm);

                _smartcard.StartProcess();

                //Label_Message.Text = STATUSCOMPLETED;
                _adapter.CloseCard();


                switch (_smartcard.SelectedFunction)
                {
                    case SmartTag.SmartTagFunctions.ReadUserData:

                    case SmartTag.SmartTagFunctions.ReadFromCardArea:
                        //ShowReadData(_smartcard.GetUserData());
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //WriteLog(ex.Message);


            }
        }



    }
}
