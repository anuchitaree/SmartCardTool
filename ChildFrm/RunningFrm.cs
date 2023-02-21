using Aioi;
using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using Newtonsoft.Json;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using SmartCartTool_API.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class RunningFrm : Form
    {

        //private static string ReadingText = null;
        private int _context = 0;
        private string _adapterName = "";
        private IAdapter _adapter;
        private SmartTag _smartcard = null;
        private DisplayPainter _display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, true);

        private const string ACR1252 = "ACS ACR1252";

        private const string STATUSREADY = "Ready";
        private const string STATUSPROCESS = "Processing...";
        private const string STATUSTOUCH = "A1: Touch Smart Card -> Place smart card on top smart card R/W";
        private const string STATUSCOMPLETED = "Completed";

        private string[] _images = new string[4];
        private string[] _request = new string[3];


        private HttpClient client;

        public RunningFrm()
        {
            InitializeComponent();
        }

        private void RunningFrm_Load(object sender, EventArgs e)
        {


            FormLoading();

            client = new HttpClient();
            client.BaseAddress = new Uri($"http://localhost:5217");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void RunningFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_smartcard != null && _smartcard.Adapter != null)
            {
                _smartcard.Adapter.CloseAdapter();
            }

            client.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ScanPartnumberDotTxt();
        }

        private void BtnReloadApp_Click(object sender, EventArgs e)
        {
            if (_smartcard != null && _smartcard.Adapter != null)
            {
                _smartcard.Adapter.CloseAdapter();
            }
            FormLoading();
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
                catch
                {
                    LbError.BackColor = Color.Red;

                    LbReady.BackColor = Color.White;

                    return;
                }
                StartProcess();
            }
            else
            {
                LbError.BackColor = Color.Red;

                LbReady.BackColor = Color.White;

                LbStatus.Text = STATUSTOUCH;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            ScanPartnumberDotTxt();
        }

        //================== Sub Program ===============//
        private void FormLoading()
        {
            Param.Pages = 9;

            string path0 = Environment.CurrentDirectory;

            string path1 = $"{path0}\\{Param.Setting}";

            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }

            InitSmartCardReader();
            ResetLamp();

        }


        private void ResetLamp()
        {
            LbOK.BackColor = Color.FromArgb(0, 28, 0);
            LbOK.ForeColor = Color.FromArgb(60, 60, 60);
            LbNG.BackColor = Color.FromArgb(42, 0, 0);
            LbNG.ForeColor = Color.FromArgb(60, 60, 60);
            LbReady.BackColor = LbReceived.BackColor = LbFindDB.BackColor = LbWriteTag.BackColor
               = LbSendToStock.BackColor = LbCompleted.BackColor = LbError.BackColor = Color.White;
            TbPartName0.Text = TbPartName1.Text = TbPartName2.Text = TbPartName3.Text = LbStatus.Text = "";
        }



        private void InvokeInit(Action a)
        {
            this.BeginInvoke(new MethodInvoker(a));
        }

        private void InitSmartCardReader()
        {
            InvokeInit(() =>
            {

                try
                {
                    int ret = PCSCModules.GetContext(ref _context);

                    if (ret != PCSCModules.SCARD_S_SUCCESS)
                    {
                        return;
                    }

                    var _ada = PCSCModules.GetAdapters(_context);
                    if (_ada == null)
                    {

                        LbStatus.Text = "A3 :No connection => Smart card reader has not yet connected. After connect, hit Reload App";

                        LbError.BackColor = Color.FromArgb(255, 85, 85);


                        return;
                    }

                    _adapterName = PCSCModules.GetAdapters(_context)[0].ToUpper();



                    if (_adapterName.Contains(ACR1252))
                    {
                        _adapter = new ACR1252_Adapter();
                    }
                    else
                    {


                        LbStatus.Text = "A4 : No compatible adapters found";

                        LbError.BackColor = Color.FromArgb(255, 85, 85);


                        return;
                    }

                    _adapter.OpenAdapter();
                    _adapter.Name = _adapterName;
                    _adapter.Context = _context;
                    _smartcard = new SmartTag(_adapter);


                    LbStatus.Text = STATUSREADY;

                    LbReady.BackColor = Color.FromArgb(85, 255, 85);


                    Thread.Sleep(1000);

                    timer1.Interval = 100;

                    timer1.Enabled = true;



                }
                catch (Exception ex)
                {
                    LbStatus.Text = ex.Message;

                    LbReady.BackColor = Color.White;

                    LbError.BackColor = Color.FromArgb(255, 85, 85);

                }

            });
        }

        private void InvokeScanPartnumberDotTxt(Action a)
        {
            this.BeginInvoke(new MethodInvoker(a));
        }


        private void ScanPartnumberDotTxt()
        {
            InvokeScanPartnumberDotTxt(() =>
            {

                try
                {
                    string path = Param.DataPath;

                    if (!File.Exists(path))
                    {
                        return;
                    }
                    string data = File.ReadAllText(path);

                    string[] parts = data.Split(',');

                    if (parts.Length != 3) return;

                    ResetLamp();


                    LbReceived.BackColor = Color.FromArgb(255, 255, 0);
                    _request[0] = parts[0];
                    _request[1] = parts[1];
                    _request[2] = parts[2];

                    timer1.Enabled = false;

                    string partnumber = parts[0];

                    CmbScanner.Text = partnumber;

                    using (var db = new DBContext())
                    {
                        var existData = db.Smartcards.Where(x => x.Partnumber == partnumber)
                            .FirstOrDefault();

                        if (existData == null)
                        {
                            TbPartName0.Text =
                            TbPartName1.Text =
                            TbPartName2.Text =
                            TbPartName3.Text = String.Empty;


                            LbStatus.Text = "A2 :Not registration => Non data in database, Tool -> Registration";

                            LbNG.BackColor = Color.Red;
                            LbError.BackColor = Color.Red;

                            Sound(Param.InCompleteSound);

                            return;
                        }
                        LbFindDB.BackColor = Color.FromArgb(255, 255, 0);

                        _images[0] = TbPartName0.Text = existData.Partname0;
                        _images[1] = TbPartName1.Text = existData.Partname1;
                        _images[2] = TbPartName2.Text = existData.Partname2;
                        _images[3] = TbPartName3.Text = existData.Partname3;




                        if (_smartcard == null)
                        {
                            return;
                        }


                        //LbStatus.Text = STATUSTOUCH;
                        //string[] err = LbStatus.Text.Split(':');
                        //if (err[0] == "A1")
                        //{
                        //    LbReady.BackColor = Color.White;
                        //    LbError.BackColor = Color.Red;
                        //}

                        timer.Interval = 250;
                        timer.Enabled = true;

                        _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;
                        _smartcard.SetImageData(CreateImage(existData.Partname0,
                            existData.Partname1,
                            existData.Partname2,
                            existData.Partname3));

                    }
                }
                catch
                {

                    LbNG.BackColor = Color.Red;
                }
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ExecuteWithRetryAsync();

        }

        public async Task<bool> ExecuteWithRetryAsync()
        {
            try
            {
                var data = new PartNumber()
                {
                    PartNoSubAssy = _request[0],
                    LotId = _request[1],
                    TimeStamp = _request[2],
                };


                string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

                StringContent httpcontent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                string uri = "/api/v1/stock/receive";

                bool status = false;
                int count = 5;
                while (!status)
                {


                    var timeRecordResp = await client.PostAsync(uri, httpcontent);

                    if (timeRecordResp.IsSuccessStatusCode)
                    {

                        string result = timeRecordResp.StatusCode.ToString();

                        if (timeRecordResp.StatusCode == HttpStatusCode.OK)
                        {
                            status = true;
                        }
                    }

                    Thread.Sleep(200);
                    count--;
                    if (count == 0)
                    {
                        return false;
                    }
                }


                return true;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return false;

            }
        }





        private bool StartPolling()
        {

            if (_smartcard == null)
            {
                return false;
            }

            timer.Interval = 250;
            timer.Enabled = true;
            return true;

        }

        private ImageInfo CreateImage(string partname0, string partname1, string partname2, string partname3)
        {
            DisplayPainter display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, false);

            string datetime = $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss}";

            string qrcode = $"{partname0},{datetime}";
            var code39 = new QRCode();
            code39.BarcodeData = qrcode; ;
            code39.Height = 200;
            code39.RotateFlip = RotateFlipType.Rotate270FlipNone;
            display.PutBarcode(code39, 0, 27);


            display.PutText(partname0, new Font("Arial", 27, FontStyle.Bold), 8, 0, false);

            //display.PutLine(5, 48, 292, 48, 1, false);
            //display.PutLine(8, 45, 292, 45, 3, false);

            display.PutText(partname1, new Font("Arial", 17, FontStyle.Bold), 170, 60, false);
            display.PutText(partname2, new Font("Arial", 17, FontStyle.Bold), 170, 100, false);
            display.PutText(partname3, new Font("Arial", 17, FontStyle.Bold), 170, 140, false);


            display.PutText(datetime.Replace("T", "  "), new Font("sans-serif", 8, FontStyle.Bold), 170, 180, false);

            //'Draws line




            return display.GetLocalDisplayImage();
        }

        private void InvokeStartProcess(Action a)
        {
            this.BeginInvoke(new MethodInvoker(a));
        }

        private void StartProcess()
        {
            InvokeStartProcess(async () =>
            {
                try
                {
                    byte[] idm = _adapter.GetIdm();

                    LbStatus.Text = STATUSPROCESS;
                    LbWriteTag.BackColor = Color.FromArgb(255, 255, 0);
                    LbReady.BackColor = Color.FromArgb(255, 255, 255);
                    LbError.BackColor = Color.White;

                    this.Refresh();
                    _smartcard.SetIdm(idm);

                    _smartcard.StartProcess();

                    LbStatus.Text = STATUSCOMPLETED;
                    LbOK.BackColor = Color.FromArgb(85, 255, 85);
                    LbNG.BackColor = Color.DarkRed;

                    _adapter.CloseCard();

                    var result = await ExecuteWithRetryAsync();
                    if (result)
                    {
                        LbSendToStock.BackColor = Color.FromArgb(255, 255, 0);
                        Sound(Param.CompleteSound);
                        LbCompleted.BackColor = Color.FromArgb(85, 255, 85);
                        Thread.Sleep(1000);


                        if (File.Exists(Param.DataPath))
                        {
                            File.Delete(Param.DataPath);
                        }
                        Thread.Sleep(1000);
                        

                        timer2.Enabled = true;

                    }



                    //StartPolling();




                    //switch (_smartcard.SelectedFunction)
                    //{
                    //    case SmartTag.SmartTagFunctions.ReadUserData:

                    //    case SmartTag.SmartTagFunctions.ReadFromCardArea:
                    //        //ShowReadData(_smartcard.GetUserData());
                    //        break;

                    //    default:
                    //        break;
                    //}
                }
                catch (Exception ex)
                {

                    LbStatus.Text = ex.Message;
                    LbError.BackColor = Color.Red;
                    LbReady.BackColor = Color.White;
                    LbNG.BackColor = Color.Red;
                    LbOK.BackColor = Color.Black;
                }
            });
        }

        private void Sound(string path)
        {
            if (!File.Exists(path)) return;

            using (var soundPlayer = new SoundPlayer(path))
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }
                      

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            ResetLamp();
            LbReady.BackColor = Color.FromArgb(85, 255, 85);
            LbStatus.Text = STATUSREADY;
        }
    }
}
