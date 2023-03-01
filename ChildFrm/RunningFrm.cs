using Aioi;
using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using Newtonsoft.Json;
using SmartCard_API.Models;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class RunningFrm : Form
    {

        private int _context = 0;
        private string _adapterName = "";
        private IAdapter _adapter;
        private SmartTag _smartcard = null;
        private DisplayPainter _display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, true);

        private const string ACR1252 = "ACS ACR1252";

        // Good status //
        private const string STATUSREADY = "0x01: Ready";
        private const string STATUSPROCESS = "0x02: Processing...";
        private const string STATUSCOMPLETED = "0x03: Completed";

        // Warning status
        private const string STATUSTOUCH = "1x01: Touch Smart Card -> Place card on top smart card reader";
        private const string STATUSSTOCKDISCONNECTION = "1x02:  Stock Monitoring is NOT conection";

        // Danger status
        private const string STATUSNOTREGIST = "2x01: Non data in database, should Tool Registration";
        private const string STATUSNOTCONNECTION = "2x02: Smart card Reader has not yet connected";
        private const string STATUSNOTCOMPATIBLE = "2x03: No compatible adapters found";

        //private const string STATUSNOTREGIST = "2x01: Touch Smart Card -> Place smart card on top smart card R/W";

        private string[] _images = new string[4];
        private string[] _request = new string[3];

        private string TagID = "";
        private long TagCount = 0;

        private bool _auto;
        private bool _man;
        private bool _autorun;
        private bool _fault = false;
        private bool _ready = false;

        private HttpClient client;

        public RunningFrm()
        {
            InitializeComponent();
        }

        private void RunningFrm_Load(object sender, EventArgs e)
        {
            _man = true;
            FormLoading();

            client = new HttpClient();
            client.BaseAddress = new Uri(Param.UploadUrl);
            LbInfo.Text = Param.UploadUrl;
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
            if (_fault == false && _autorun == true)
            {
                ScanPartnumberDotTxt();
            }
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

            _fault = false;
            _man = true;
            _auto = false;
            BtnManual.BackColor = Color.FromArgb(85, 255, 85);
        }


        private void ResetLamp()
        {
            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
            //LbError.BackColor = Color.FromArgb(255, 255, 255);
            LbOK.BackColor = Color.FromArgb(0, 28, 0);
            LbOK.ForeColor = Color.FromArgb(60, 60, 60);

            LbNG.BackColor = Color.FromArgb(42, 0, 0);
            LbNG.ForeColor = Color.FromArgb(60, 60, 60);
            LbReady.BackColor = LbReceived.BackColor = LbFindDB.BackColor = LbWriteTag.BackColor
               = LbSendToStock.BackColor = LbCompleted.BackColor = LbError.BackColor = Color.White;

            TbPartName0.Text = TbPartName1.Text = TbPartName2.Text = TbPartName3.Text = LbStatus.Text =LbInfo.Text=
               CmbScanner.Text = "";
            //TagCount = 0;
            //TagID = "";
            _fault = false;
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

                        LbStatus.Text = STATUSNOTCONNECTION;
                        _fault = true;
                        LbError.BackColor = Color.FromArgb(255, 0, 0);
                        LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);


                        return;
                    }
                    _adapterName = PCSCModules.GetAdapters(_context)[0].ToUpper();

                    if (_adapterName.Contains(ACR1252))
                    {
                        _adapter = new ACR1252_Adapter();
                    }
                    else
                    {

                        _fault = true;

                        LbStatus.Text = STATUSNOTCOMPATIBLE;

                        LbError.BackColor = Color.FromArgb(255, 85, 85);
                        LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);


                        return;
                    }

                    _adapter.OpenAdapter();
                    _adapter.Name = _adapterName;
                    _adapter.Context = _context;
                    _smartcard = new SmartTag(_adapter);


                    LbStatus.Text = STATUSREADY;

                    _ready = true;
                    LbReady.BackColor = Color.FromArgb(85, 255, 85);
                    this.Refresh();

                    Thread.Sleep(1000);

                    timer1.Interval = 100;

                    timer1.Enabled = true;



                }
                catch (Exception ex)
                {
                    LbStatus.Text = ex.Message;

                    LbReady.BackColor = Color.Red;

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
            InvokeScanPartnumberDotTxt(async () =>
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

                    LbAutoRun.BackColor = Color.FromArgb(255, 255, 0);

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

                            _images[0] =
                            _images[1] =
                            _images[2] =
                            _images[3] = null;

                            LbStatus.Text = STATUSNOTREGIST;

                            LbNG.BackColor = Color.Red;
                            LbError.BackColor = Color.Red;
                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);

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
                            var result =  await ExecuteWithRetryAsync(HttpPostMode.Abnormal, "Smart card reader is NOT connection", "", 0);
                            LbStatus.Text = STATUSNOTCONNECTION;
                            LbWriteTag.BackColor = Color.Red;
                            LbError.BackColor= Color.Red;
                            LbAutoRun.BackColor= Color.FromArgb(255, 255, 255);
                            if (result.Result == true)
                                LbSendToStock.BackColor = Color.FromArgb(85, 255, 85);
                            else
                                LbSendToStock.BackColor = Color.Red;
                            return;
                        }


                        timer.Interval = 250;
                        timer.Enabled = true;

                        _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;

                        if (existData.Partname0 != null && existData.Partname1 != null
                        && existData.Partname2 != null && existData.Partname3 != null)
                        {
                            _smartcard.SetImageData(CreateImage(existData.Partname0,
                            existData.Partname1,
                            existData.Partname2,
                            existData.Partname3));
                        }
                    }
                }
                catch (Exception ex)
                {
                    var result = await ExecuteWithRetryAsync(HttpPostMode.Abnormal, $"Error : {ex.Message}", "", 0);

                    LbStatus.Text = $"Error : {ex.Message}";

                    LbNG.BackColor = Color.Red;
                }
            });
        }



        public async Task<HttpResult> ExecuteWithRetryAsync(HttpPostMode httpPostMode, string reson, string TagId, long TagCount)
        {
            try
            {
                string json = "";
                string uri;

                switch (httpPostMode)
                {
                    case HttpPostMode.Normal:
                        uri = "api/v1/end_write_sub_assy";

                        var data1 = new PartNumber()
                        {
                            PartNoSubAssy = _request[0],
                            LotId = Convert.ToInt32(_request[1] == null ? "0" : _request[1]),
                            TimeStamp = _request[2],
                            TagID = TagId,
                            TagCount = TagCount
                        };
                        json = JsonConvert.SerializeObject(data1, Newtonsoft.Json.Formatting.Indented);

                        break;
                    case HttpPostMode.Abnormal:
                        uri = "api/v1/critical_smart_card_error_sub_assy";
                        var data2 = new ReturnError()
                        {
                            PartNoSubAssy = _request[0],
                            LotId = Convert.ToInt32(_request[1] == null ? "0" : _request[1]),
                            Detail = reson,
                           
                        };
                        json = JsonConvert.SerializeObject(data2, Newtonsoft.Json.Formatting.Indented);
                        break;
                    default:
                        uri = "";
                        break;
                }


                StringContent httpcontent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                bool status = false;
                int count = 2;
                while (!status)
                {
                    try
                    {
                        var timeRecordResp = await client.PostAsync(uri, httpcontent);

                        if (timeRecordResp.IsSuccessStatusCode)
                        {
                            var responseString = await timeRecordResp.Content.ReadAsStringAsync();

                            var object1 = JsonConvert.DeserializeObject<StatusModel>(responseString);


                            if (timeRecordResp.StatusCode == HttpStatusCode.OK && object1.Status == "ok")
                            {
                                status = true;

                                return new HttpResult()
                                {
                                    Result = true,
                                    Message = object1.Detail,
                                };
                            }
                            else
                            {
                                return new HttpResult()
                                {
                                    Result = true,
                                    Message = object1.Detail,
                                };

                            }

                        }
                        else
                        {

                        }

                        Thread.Sleep(200);
                        count--;
                        if (count == 0)
                        {
                            return new HttpResult()
                            {
                                Result = false,
                                Message = "Stock monitoring DISCONNECTION",
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        LbStatus.Text = $"2x0D: { ex.Message}";
                        return new HttpResult()
                        {
                            Result = false,
                            Message = $"2x0D: { ex.Message}",
                        };
                    }

                }


                return new HttpResult();


            }
            catch (Exception ex)
            {
                LbStatus.Text = $"2x0E: { ex.Message}";
                return new HttpResult()
                {
                    Result = false,
                    Message = $"2x0E: { ex.Message}",
                };

            }
        }

        //  https://1102-2405-9800-b650-4da4-fd7b-87dd-3357-8360.ap.ngrok.io/api/v1/critical_smart_card_error_sub_assy
        //  Data not found , 

        // Read TagID
        // CountTag
        // Data  3 set



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
            if (partname1 != null && partname1 != String.Empty)
                display.PutText(partname1, new Font("Arial", 17, FontStyle.Bold), 170, 60, false);

            if (partname2 != null && partname2 != String.Empty)
                display.PutText(partname2, new Font("Arial", 17, FontStyle.Bold), 170, 100, false);

            if (partname3 != null && partname3 != String.Empty)
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

                    string IDM = BitConverter.ToString(idm);

                    LbInfo.Text = $"TAG ID  : {IDM}";
                    TagID = IDM.Replace("-", "");

                    LbStatus.Text = STATUSPROCESS;
                    LbWriteTag.BackColor = Color.FromArgb(255, 255, 0);
                    LbReady.BackColor = Color.FromArgb(255, 255, 255);
                    LbError.BackColor = Color.White;

                    this.Refresh();
                    _smartcard.SetIdm(idm);

                    _smartcard.StartProcess();

                    LbStatus.Text = STATUSCOMPLETED;
                    LbOK.BackColor = Color.FromArgb(85, 255, 85);


                    LbNG.BackColor = Color.FromArgb(42, 0, 0);
                    LbNG.ForeColor = Color.FromArgb(60, 60, 60);
                    TagCount += 1;
                    _adapter.CloseCard();


                    switch (_smartcard.SelectedFunction)
                    {
                        case SmartTag.SmartTagFunctions.ReadUserData:
                        case SmartTag.SmartTagFunctions.ReadFromCardArea:
                            string aaa = ShowReadData(_smartcard.GetUserData());
                            break;
                        case SmartTag.SmartTagFunctions.WriteUserData:
                        case SmartTag.SmartTagFunctions.WriteToCardArea:
                        //WriteUserData(0, _userData)
                        default: break;
                    }



                    var result = await ExecuteWithRetryAsync(HttpPostMode.Normal, "", TagID, TagCount);
                    if (result.Result)
                    {
                        LbStatus.Text = result.Message;
                        LbSendToStock.BackColor = Color.FromArgb(255, 255, 0);
                        Sound(Param.CompleteSound);
                        LbCompleted.BackColor = Color.FromArgb(85, 255, 85);
                        LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                        Thread.Sleep(1000);


                        if (File.Exists(Param.DataPath))
                        {
                            File.Delete(Param.DataPath);
                        }
                        Thread.Sleep(1000);

                        timer2.Interval = Param.HoldResultSec;
                        timer2.Enabled = true;

                    }
                    else
                    {
                        LbStatus.Text = STATUSSTOCKDISCONNECTION;

                        LbSendToStock.BackColor = Color.FromArgb(255, 0, 0);
                        LbError.BackColor = Color.FromArgb(255, 0, 0);
                        LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                        LbCompleted.BackColor = Color.FromArgb(255, 255, 255);

                        _fault = true;


                    }



                }
                catch (Exception ex)
                {
                    
                    LbStatus.Text = ex.Message;
                    LbError.BackColor = Color.Red;
                    LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                    LbReady.BackColor = Color.White;
                    LbNG.BackColor = Color.Red;
                    LbOK.BackColor = Color.Black;
                    var result = await ExecuteWithRetryAsync(HttpPostMode.Abnormal, $"Error : {ex.Message}", "", 0);
                    if (result.Result)
                    {
                        LbSendToStock.BackColor = Color.FromArgb(85, 255, 85);
                    }
                    else
                    {
                        LbSendToStock.BackColor = Color.FromArgb(255, 0, 0);
                    }
                }
            });
        }

        private string ShowReadData(byte[] data)
        {
            string text = Encoding.ASCII.GetString(data);
            return text;


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
            LbInfo.Text = "";
            ResetLamp();
            LbStatus.Text = $"{STATUSREADY}  , Lasted times : {_request[0]} : {_request[1]} : {_request[2]} : {TagID} : {TagCount}";
            TagCount = 0;
            TagID = "";
            LbReady.BackColor = Color.FromArgb(85, 255, 85);
        }



        private void BtnErrorReset_Click(object sender, EventArgs e)
        {
            if (_smartcard != null && _smartcard.Adapter != null)
            {
               
                _smartcard.Adapter.CloseAdapter();
            }
            //FormLoading();
            _autorun =false;
            _ready = false;
            BtnAutoRun.BackColor = Color.FromArgb(255, 255, 255);
            timer.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            ResetLamp();
            LbReady.BackColor = Color.White;
            LbStatus.Text = STATUSREADY;
            LbError.BackColor = Color.White;
            this.Refresh();
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            if (!_fault)
            {
                InitSmartCardReader();

                _auto = true;
                _man = false;
                BtnAuto.BackColor = Color.FromArgb(85, 255, 85);
                BtnManual.BackColor = Color.FromArgb(255, 255, 255);
                ResetLamp();
            }
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            if (!_fault)
            {
                InitSmartCardReader();

                _man = true;
                _auto = false;
                _autorun = false;
                BtnAuto.BackColor = Color.FromArgb(255, 255, 255);
                BtnManual.BackColor = Color.FromArgb(85, 255, 85);
                BtnAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                LbReady.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void BtnAutoRun_Click(object sender, EventArgs e)
        {
            if (_auto == true)
            {
                if (_ready == true)
                {
                    LbReady.BackColor = Color.FromArgb(85, 255, 85);
                }
                _autorun = true;

                BtnAutoRun.BackColor = Color.FromArgb(255, 255, 0);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

            _autorun = false;
            LbReady.BackColor = Color.FromArgb(255, 255, 255);
            BtnAutoRun.BackColor = Color.FromArgb(255, 255, 255);

        }

        private void BtnReceiveData_Click(object sender, EventArgs e)
        {
            if (_man != true) return;

            String value1 = _request[0];
            String value2 = _request[1];
            String value3 = _request[2];
            var result = InputDialog.InputBox("Manual Input", "Partnumber TG114654-124", ref value1, "LoTId 150",
                ref value2, "TimeStamp yyyy-MM-ddTHH:mm:ss 2023-02-15T16:46:12", ref value3);
            if (result == DialogResult.OK)
            {
                _request[0] = value1;
                _request[1] = value2 == String.Empty ? "0" : value2;
                _request[2] = value3 == string.Empty ? DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") : value3;

                CmbScanner.Text = value1;

                LbReceived.BackColor = Color.FromArgb(85, 255, 85);
            }
        }

        private void BtnFindDB_Click(object sender, EventArgs e)
        {
            if (_man != true) return;

            string partnumber = _request[0];

            using (var db = new DBContext())
            {
                var existData = db.Smartcards.Where(x => x.Partnumber == partnumber).ToList();


                if (existData.Count == 0)
                {
                    TbPartName0.Text =
                    TbPartName1.Text =
                    TbPartName2.Text =
                    TbPartName3.Text = String.Empty;
                    _images[0] = null;
                    _images[1] = null;
                    _images[2] = null;
                    _images[3] = null;

                    LbStatus.Text = STATUSNOTREGIST; // "A2 :Not registration => Non data in database, Tool -> Registration";

                    LbFindDB.BackColor = Color.FromArgb(255, 0, 0);

                    return;
                }
                var existdata = existData.FirstOrDefault();

                _images[0] = TbPartName0.Text = existdata.Partname0;
                _images[1] = TbPartName1.Text = existdata.Partname1;
                _images[2] = TbPartName2.Text = existdata.Partname2;
                _images[3] = TbPartName3.Text = existdata.Partname3;
                LbStatus.Text = "";
                LbFindDB.BackColor = Color.FromArgb(85, 255, 85);


            }
        }
        private void BtnWriteTAG_Click(object sender, EventArgs e)
        {
            if (_man != true) return;


            LbWriteTag.BackColor = Color.FromArgb(255, 255, 255);

            if (_images[0] != null && _images[1] != null && _images[2] != null && _images[3] != null)
            {

                if (_smartcard == null)
                {
                    LbWriteTag.BackColor = Color.Red;
                    TagID = "";
                    LbStatus.Text = STATUSNOTCONNECTION;
                    return;
                }


                timer_M.Interval = 250;
                timer_M.Enabled = true;

                _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;
                _smartcard.SetImageData(CreateImage(_images[0], _images[1], _images[2], _images[3]));
            }
            else
            {
                LbWriteTag.BackColor = Color.Red;
                LbStatus.Text = STATUSNOTREGIST;
            }
        }

        private async void BtnSendStock_Click(object sender, EventArgs e)
        {
            if (_man != true) return;

            LbSendToStock.BackColor = Color.FromArgb(255, 255, 255);
            LbStatus.Text = "";
            HttpResult result =TagID==""? await ExecuteWithRetryAsync(HttpPostMode.Abnormal, "Smart card is NOT connection", "", 0) :await  ExecuteWithRetryAsync(HttpPostMode.Normal, "", TagID, TagCount);
            if (result.Result)
            {
                LbSendToStock.BackColor = Color.FromArgb(85, 255, 85);
                if (result.Result == true)
                    LbStatus.Text = $"Completed => {_request[0]}  :  {_request[1]}  :  {_request[2]} : {TagID} : {TagCount}";
                else
                    LbStatus.Text = result.Message;
            }
            else
            {
                LbSendToStock.BackColor = Color.Red;
                LbStatus.Text = STATUSSTOCKDISCONNECTION;

            }
        }

        private void timer_M_Tick(object sender, EventArgs e)
        {
            if (_smartcard.Adapter.Poll())
            {
                timer_M.Enabled = false;
                try
                {
                    _smartcard.Adapter.OpenCard();
                }
                catch
                {
                    LbWriteTag.BackColor = Color.Red;
                    return;
                }
                StartProcess_man();
            }
            else
            {
                LbWriteTag.BackColor = Color.Red;
                LbStatus.Text = STATUSTOUCH;

            }
        }

        private void StartProcess_man()
        {
            try
            {
                byte[] idm = _adapter.GetIdm();

                string IDM = BitConverter.ToString(idm);
                LbInfo.Text = $"TAG ID : {IDM}";

                TagID = IDM.Replace("-", "");

                LbStatus.Text = STATUSPROCESS;

                this.Refresh();
                _smartcard.SetIdm(idm);

                _smartcard.StartProcess();

                LbStatus.Text = STATUSCOMPLETED;
                TagCount += 1;
                _adapter.CloseCard();
                LbWriteTag.BackColor = Color.FromArgb(85, 255, 85);
            }
            catch (Exception ex)
            {
                LbStatus.Text = $"2x0F: {ex.Message}";
                LbWriteTag.BackColor = Color.Red;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_smartcard == null)
            {
                return;
            }


            timer.Interval = 250;
            timer.Enabled = true;

            if (StartPolling())
            {
                _smartcard.SetUserData(CreateTestDataForWrite("anuchit"));
                _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.WriteUserData;
            }
        }

        private byte[] CreateTestDataForWrite(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            return bytes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_smartcard == null)
            {
                return;
            }


            timer.Interval = 250;
            timer.Enabled = true;

            if (StartPolling())
            {
                _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ReadUserData;


            }
        }

        private void BtnReadFile_Click(object sender, EventArgs e)
        {
            if (_man != true) return;

            string path = Param.DataPath;

            if (!File.Exists(path))
            {
                return;
            }
            string data = File.ReadAllText(path);

            string[] parts = data.Split(',');

            if (parts.Length != 3) return;

            ResetLamp();


            LbReceived.BackColor = Color.FromArgb(85, 255, 85);
            _request[0] = parts[0];
            _request[1] = parts[1];
            _request[2] = parts[2];
            CmbScanner.Text = parts[0];


        }



    }
    public enum HttpPostMode
    {
        Normal,
        Abnormal
    }
}
