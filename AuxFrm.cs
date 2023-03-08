using Aioi;
using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartCardTool.Models;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SmartCardTool
{
    public partial class AuxFrm : Form
    {

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

        //private readonly IConfiguration _configuration;

        public AuxFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Init();

            //var _destinationPath1 = _configuration.GetConnectionString("Email:Host");


            Label_Version.Text = "ver: " + Application.ProductVersion;

            var path =@"D:\Project\SmartCardTool\appsettings.json";

            using (var reader = new StreamReader(path))
            {
                var appSettings = JsonConvert.DeserializeObject<AppSettings>(reader.ReadToEnd());


            }
        }

        private void Button_ShowImage_Click(object sender, EventArgs e)
        {
            try
            {
                WriteLog("<Show Image>");
                if (StartPolling())
                {
                    _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;
                    _smartcard.SetImageData(CreateImageFor29inch());
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }
        }

        private void Button_ClearDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                WriteLog("<Clear Display>");
                if (StartPolling())
                {
                    _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ClearDisplay;
                }
            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }
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
                    WriteLog("No compatible adapters found");
                    return;
                }

                _adapter.OpenAdapter();
                _adapter.Name = _adapterName;
                _adapter.Context = _context;
                _smartcard = new SmartTag(_adapter);

                WriteLog(_adapterName + " detected");
                Label_Message.Text = STATUSREADY;
                Label_IDm.Text = "---";
                //AddHandler _smartcard.ShowMessage, AddressOf Me.WriteToUiLog;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }


        }

        private void WriteToUiLog(Object sender, UiLogEventArgs e)
        {
            WriteLog(e.Message);
        }
        private void WriteLog(string message)
        {
            TextBox_Log.AppendText(message + "\n");

        }

        private bool StartPolling()
        {
            if (_smartcard == null)
            {
                return false;
            }
            Label_Message.Text = STATUSTOUCH;
            Label_IDm.Text = "---";
            timer.Interval = 250;
            timer.Enabled = true;
            return true;
        }

        //''' <summary>
        //''' Creates the sample image.(for 2.9inch)
        //''' </summary>
        //''' <returns></returns>
        private ImageInfo CreateImageFor29inch()
        {
            DisplayPainter display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, false);

            //'Draws text
            display.PutText("SmartCard", new Font("Arial", 9), 0, 0, true);
            display.PutText("Sample Program", new Font("Arial", 18, FontStyle.Bold), 8, 23, false);


            //'Draws line
            display.PutLine(8, 52, 292, 52, 1, false);


            //'Draws barcode
            var code39 = new Code39();
            code39.BarcodeData = "123456";
            code39.Height = 60;
            code39.RotateFlip = RotateFlipType.Rotate270FlipNone;
            display.PutBarcode(code39, 220, 65);


            //'Draws image
            //display.PutImage(Application.StartupPath + "\\image2.jpg", 8, 60, 203, 135, true, false);

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
                    WriteLog("Card open failed - " + ex.Message);
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
                Label_IDm.Text = BitConverter.ToString(idm);

                Label_Message.Text = STATUSPROCESS;
                this.Refresh();

                _smartcard.SetIdm(idm);

                _smartcard.StartProcess();

                Label_Message.Text = STATUSCOMPLETED;
                _adapter.CloseCard();


                switch (_smartcard.SelectedFunction)
                {
                    case SmartTag.SmartTagFunctions.ReadUserData:

                    case SmartTag.SmartTagFunctions.ReadFromCardArea:
                        ShowReadData(_smartcard.GetUserData());
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);


            }
        }

        private void ShowReadData(byte[] data)
        {
            string text = Encoding.ASCII.GetString(data);
            WriteLog(text);

        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_smartcard != null && _smartcard.Adapter != null)
            {
                _smartcard.Adapter.CloseAdapter();
            }
        }

        private void Button_WriteToUserArea_Click(object sender, EventArgs e)
        {
            WriteLog("<Write To User Data>");

            if (StartPolling())
            {
                _smartcard.SetUserData(CreateTestDataForWrite(3070));
                _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.WriteUserData;
            }
        }

        private void Button_ReadFromUserArea_Click(object sender, EventArgs e)
        {
            WriteLog("<Read From User Data>");
            if (StartPolling())
            {
                _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ReadUserData;
            }
        }

        private byte[] CreateTestDataForWrite(int size)
        {
            byte[] data = new byte[size - 1];
            for (int i = 0; i < data.Length - 1; i++)
            {
                data[i] = (byte)(((i % 10) + 0x30));
            }
            return data;
        }

    }
}
