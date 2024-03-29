﻿using Aioi;
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
        private const string STATUSNOINPUT = "1x03: Has NO Part number";
        private const string STATUSNOMEMO = "1x04: Has NO Part number in memory. Please send it from Stock monitoring first";

        // Danger status
        private const string STATUSNOTREGIST = "2x01: The Part number is NOT FOUND. Please registration first";
        private const string STATUSNOTCONNECTION = "2x02: Smart card reader has NOT yet connected";
        private const string STATUSNOTCOMPATIBLE = "2x03: No compatible adapters found";
        private const string STATUSLENGTHNOTCORRECT = "2x04: Inprocess critical : request data is not 3";

        private string[] _images = new string[4];
        private string[] _request = new string[3];

        private string TagID = "";
        private long TagCount = 0;

        private bool _auto;
        private bool _man;
        private bool _autorun;
        private bool _fault = false;
        private bool _scReady = false;

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

        #region Manual Operation

        private void BtnErrorReset_Click(object sender, EventArgs e)
        {
            if (_smartcard != null && _smartcard.Adapter != null)
            {
                _scReady = false;

                _smartcard.Adapter.CloseAdapter();
            }
            //FormLoading();
            _autorun = false;
            BtnAutoRun.BackColor = Color.FromArgb(255, 255, 255);
            timer.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            ResetLamp();
            //LbReady.BackColor = Color.White;
            LbStatus.Text = "";
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
                _request[0] = _request[1] = _request[2] = null;
                TagCount = 0;
                TagID = "";
                LbInfo.Text = String.Empty;
                if (File.Exists(Param.DataPath))
                {
                    File.Delete(Param.DataPath);
                }

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
                _request[0] = _request[1] = _request[2] = null;
                TagCount = 0;
                TagID = "";
                LbInfo.Text = String.Empty;
            }
        }

        private void BtnAutoRun_Click(object sender, EventArgs e)
        {
            if (_auto == true && _fault != true && _scReady == true && _smartcard != null)
            {
                if (_smartcard == null)
                {

                }
                //if (_scReady == true)
                //{
                //    LbReady.BackColor = Color.FromArgb(85, 255, 85);
                //}
                
                _autorun = true;
                timer1.Enabled = true;
                BtnAutoRun.BackColor = Color.FromArgb(255, 255, 0);
                _request[0] = _request[1] = _request[2] = null;
                TagCount = 0;
                TagID = "";
            }
            else
            {
                LbError.BackColor = Color.Red;
                LbStatus.Text = "Please check Smart card reader connection or extension cable";
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

            _autorun = false;
            //LbReady.BackColor = Color.FromArgb(255, 255, 255);
            BtnAutoRun.BackColor = Color.FromArgb(255, 255, 255);
            LbAutoRun.BackColor =  Color.FromArgb(255, 255, 255);

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
                if (value1 != "")
                {
                    _request[0] = value1;
                    _request[1] = value2 == String.Empty ? "0" : value2;
                    _request[2] = value3 == string.Empty ? DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") : value3;

                    CmbScanner.Text = value1;

                    LbReceived.BackColor = Color.FromArgb(85, 255, 85);
                }
                else
                {
                    LbStatus.Text = STATUSNOINPUT;
                    LbReceived.BackColor = Color.Red;
                }
            }
        }

        private void BtnFindDB_Click(object sender, EventArgs e)
        {
            if (_man != true) return;

            if (_request[0] == null)
            {
                LbStatus.Text = STATUSNOINPUT + ", Please input the part number first.";
                LbFindDB.BackColor = Color.Red;
                return;
            }

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
            if ((_man != true && _fault == true) || _auto == true) return;


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
            if (_auto == true) return;

            if (_man != true || _request[0] == null)
            {
                LbStatus.Text = STATUSNOINPUT;
                LbSendToStock.BackColor = Color.Red;
                return;
            }

            LbSendToStock.BackColor = Color.FromArgb(255, 255, 255);
            LbStatus.Text = "";




            HttpResult result = TagID == "" ? await ExecuteWithRetryAsync(HttpPostMode.Abnormal, "It has not yet writen data in SmartCard.", "", 0) : await ExecuteWithRetryAsync(HttpPostMode.Normal, "", TagID, TagCount);

            switch (result.Result)
            {
                case SendHttpResult.Success:
                    if (TagID != "")
                    {
                        LbSendToStock.BackColor = Color.FromArgb(85, 255, 85);
                        LbStatus.Text = $"Send Completed => P/N:{_request[0]}  ,LotId:{_request[1]}  ,DateTime:  {_request[2]} ,TagId: {TagID} ,CountTag: {TagCount}";
                        if (File.Exists(Param.DataPath))
                        {
                            File.Delete(Param.DataPath);
                        }
                    }
                    else
                    {
                        LbSendToStock.BackColor = Color.Red;
                        LbStatus.Text = $"Send \"Error\" Completed => P/N:{_request[0]}  ,LotId:{_request[1]}  ,DateTime:  {_request[2]} ,TagId: {TagID} ,CountTag: {TagCount}";
                    }
                    break;

                case SendHttpResult.NoProduction:

                    LbSendToStock.BackColor = Color.Red;
                    LbStatus.Text = $"No Production => P/N:{_request[0]}  ,LotId:{_request[1]}  ,DateTime:  {_request[2]} ,TagId: {TagID} ,CountTag: {TagCount}";
                    if (File.Exists(Param.DataPath))
                    {
                        File.Delete(Param.DataPath);
                    }

                    break;

                case SendHttpResult.WrongData:
                    LbSendToStock.BackColor = Color.Red;
                    LbStatus.Text = $"Meassage from StockMonitor :{ result.Message}";
                    break;

                case SendHttpResult.Disconnect:
                    LbSendToStock.BackColor = Color.Red;
                    LbStatus.Text = STATUSSTOCKDISCONNECTION;
                    break;

                case SendHttpResult.Other:
                    LbSendToStock.BackColor = Color.Red;
                    LbStatus.Text = $"Meassage from StockMonitor :{ result.Message}";
                    break;

                default:
                    break;
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
                TagID = IDM.Replace("-", "");
                LbInfo.Text = $"TAG ID : {TagID}";


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
                _request[0] = _request[1] = _request[2] = null;
                _images[0] = _images[1] = _images[2] = _images[3] = null;
                TagID = "";
                LbInfo.Text = String.Empty;
                ResetLamp();
                LbStatus.Text = STATUSNOMEMO;
                LbReceived.BackColor = Color.Red;

                return;
            }
            string data = File.ReadAllText(path);

            string[] parts = data.Split(',');

            if (parts.Length != 3)
            {
                LbStatus.Text = STATUSLENGTHNOTCORRECT;
                return;
            }

            ResetLamp();


            LbReceived.BackColor = Color.FromArgb(85, 255, 85);
            _request[0] = parts[0];
            _request[1] = parts[1];
            _request[2] = parts[2];
            CmbScanner.Text = parts[0];


        }

        #endregion Manual Operation



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_fault == false && _autorun == true)
            {
                ScanPartnumberDotTxt();
            }
        }

        //private void BtnReloadApp_Click(object sender, EventArgs e)
        //{
        //    if (_smartcard != null && _smartcard.Adapter != null)
        //    {
        //        _smartcard.Adapter.CloseAdapter();
        //    }
        //    FormLoading();
        //}

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

                Thread.Sleep(500);
                LbStatus.Text = "";
            }
        }


        //================== Sub Program ===============//

        #region Initial Auto Running
        private void FormLoading()
        {
            Param.Pages = 9;

            //string path0 = Environment.CurrentDirectory;

            //string path1 = $"{path0}\\{Param.Setting}";

            //if (!Directory.Exists(path1))
            //{
            //    Directory.CreateDirectory(path1);
            //}

            string path = Param.DataPath;

            if (File.Exists(path))
            {
                File.Delete(path);
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
            if (_scReady == false)
                LbReady.BackColor = Color.White;


            LbReceived.BackColor = LbFindDB.BackColor = LbWriteTag.BackColor
           = LbSendToStock.BackColor = LbCompleted.BackColor = LbError.BackColor = Color.White;

            TbPartName0.Text = TbPartName1.Text = TbPartName2.Text = TbPartName3.Text = LbStatus.Text =
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
                        _scReady = false;
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
                        _scReady = false;
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

                    _scReady = true;
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

        #endregion

        #region Automatic Opereate
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
                            var result = await ExecuteWithRetryAsync(HttpPostMode.Abnormal, "Smart card reader is NOT connection", "", 0);
                            LbStatus.Text = STATUSNOTCONNECTION;
                            LbWriteTag.BackColor = Color.Red;
                            LbError.BackColor = Color.Red;
                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                            if (result.Result == SendHttpResult.Success)
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

                    TagID = IDM.Replace("-", "");

                    LbInfo.Text = $"TAG ID  : {TagID}";

                    LbStatus.Text = STATUSPROCESS;
                    LbWriteTag.BackColor = Color.FromArgb(255, 255, 0);
                    LbWriteTag.Refresh();
                    LbReady.BackColor = Color.FromArgb(255, 255, 0);
                    LbReady.Refresh();
                    LbError.BackColor = Color.White;

                    this.Refresh();
                    _smartcard.SetIdm(idm);

                    _smartcard.StartProcess();

                    LbStatus.Text = STATUSCOMPLETED;
                    LbOK.BackColor = Color.FromArgb(85, 255, 85);
                    LbOK.Refresh();

                    LbNG.BackColor = Color.FromArgb(42, 0, 0);
                    LbNG.ForeColor = Color.FromArgb(60, 60, 60);
                    LbNG.Refresh();
                    TagCount += 1;
                    _adapter.CloseCard();


                    //switch (_smartcard.SelectedFunction)
                    //{
                    //    case SmartTag.SmartTagFunctions.ReadUserData:
                    //    case SmartTag.SmartTagFunctions.ReadFromCardArea:
                    //        string aaa = ShowReadData(_smartcard.GetUserData());
                    //        break;
                    //    case SmartTag.SmartTagFunctions.WriteUserData:
                    //    case SmartTag.SmartTagFunctions.WriteToCardArea:
                    //    //WriteUserData(0, _userData)
                    //    default: break;
                    //}



                    var result = await ExecuteWithRetryAsync(HttpPostMode.Normal, "", TagID, TagCount);
                    switch (result.Result)
                    {
                        case SendHttpResult.Success:
                            LbStatus.Text = $"Message from StockMonitor : {result.Message}";

                            LbSendToStock.BackColor = Color.FromArgb(255, 255, 0);
                            LbSendToStock.Refresh();

                            Sound(Param.CompleteSound);


                            LbCompleted.BackColor = Color.FromArgb(85, 255, 85); // Green
                            LbCompleted.Refresh();
                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255); // ดับ
                            LbAutoRun.Refresh();    

                            Thread.Sleep(1000);

                            if (File.Exists(Param.DataPath))
                            {
                                File.Delete(Param.DataPath);
                            }
                            Thread.Sleep(1000);

                            timer2.Interval = Param.HoldResultSec;
                            timer2.Enabled = true;
                            break;

                        case SendHttpResult.WrongData:
                            LbStatus.Text = $"Message from StockMonitor : {result.Message}";
                            LbError.BackColor = Color.FromArgb(255, 0, 0);
                            LbError.Refresh();

                            LbSendToStock.BackColor = Color.FromArgb(255, 0, 0);
                            LbSendToStock.Refresh();


                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                            LbAutoRun.Refresh();

                            break;

                        case SendHttpResult.NoProduction:
                            LbStatus.Text = $"Message from StockMonitor : {result.Message}";
                            LbError.BackColor = Color.FromArgb(255, 0, 0);
                            LbError.Refresh();

                            LbSendToStock.BackColor = Color.FromArgb(255, 0, 0);
                            LbSendToStock.Refresh();

                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                            LbAutoRun.Refresh();

                            if (File.Exists(Param.DataPath))
                            {
                                File.Delete(Param.DataPath);
                            }
                            Thread.Sleep(1000);

                            timer2.Interval = Param.HoldResultSec;
                            timer2.Enabled = true;
                            break;

                        case SendHttpResult.Disconnect:
                            LbStatus.Text = STATUSSTOCKDISCONNECTION;

                            LbSendToStock.BackColor = Color.FromArgb(255, 0, 0);
                            LbSendToStock.Refresh();

                            LbError.BackColor = Color.FromArgb(255, 0, 0);
                            LbError.Refresh();

                            LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                            LbAutoRun.Refresh();

                            LbCompleted.BackColor = Color.FromArgb(255, 255, 255);
                            LbCompleted.Refresh();


                            _fault = true;
                            break;
                        case SendHttpResult.Other:
                            break;
                        default:
                            break;

                    }



                }
                catch (Exception ex)
                {

                    LbStatus.Text = ex.Message;
                    LbError.BackColor = Color.Red;
                    LbError.Refresh();

                    LbAutoRun.BackColor = Color.FromArgb(255, 255, 255);
                    LbAutoRun.Refresh();

                    LbReady.BackColor = Color.White;
                    LbReady.Refresh();

                    LbNG.BackColor = Color.Red;
                    LbNG.Refresh();

                    LbOK.BackColor = Color.Black;
                    LbOK.Refresh();

                    _scReady = false;
                    var result = await ExecuteWithRetryAsync(HttpPostMode.Abnormal, $"Error : {ex.Message}", "", 0);
                    if (result.Result == SendHttpResult.Other)
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
                            TagId = TagId == null ? "" : TagId,
                            CountTag = TagCount
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

                LbInfo.Text = $"{Param.UploadUrl}/{uri} {json}";

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


                            if (timeRecordResp.StatusCode == HttpStatusCode.OK)
                            {

                                status = true;

                                if (object1.Status == "ok" && object1.Detail == "")
                                {
                                    return new HttpResult()
                                    {
                                        Result = SendHttpResult.Success,
                                        Message = object1.Detail,
                                    };
                                }
                                else if (object1.Status == "ng" && object1.Detail == "Parts NO. not production now.")
                                {
                                    return new HttpResult()
                                    {
                                        Result = SendHttpResult.NoProduction,
                                        Message = object1.Detail,
                                    };
                                }

                                else
                                {
                                    return new HttpResult()
                                    {
                                        Result = SendHttpResult.WrongData,
                                        Message = object1.Detail,
                                    };
                                }


                            }
                            //else
                            //{
                            //    return new HttpResult()
                            //    {
                            //        Result = false,
                            //        Message = object1.Detail,
                            //    };

                            //}


                        }


                        Thread.Sleep(200);
                        count--;
                        if (count == 0)
                        {
                            return new HttpResult()
                            {
                                Result = SendHttpResult.Disconnect,
                                Message = "Stock monitoring DISCONNECTION",
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        LbStatus.Text = $"2x0D: { ex.Message}";
                        return new HttpResult()
                        {
                            Result = SendHttpResult.Other,
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
                    Result = SendHttpResult.Other,
                    Message = $"2x0E: { ex.Message}",
                };

            }
        }

        //  https://1102-2405-9800-b650-4da4-fd7b-87dd-3357-8360.ap.ngrok.io/api/v1/critical_smart_card_error_sub_assy
        //  Data not found , 

        // Read TagID
        // CountTag
        // Data  3 set


        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            ResetLamp();
            LbStatus.Text = $"{STATUSREADY}  , Lasted times : {_request[0]} : {_request[1]} : {_request[2]} : {TagID} : {TagCount}";
            TagCount = 0;
            TagID = "";
            LbReady.BackColor = Color.FromArgb(85, 255, 85);
        }



        #endregion

        private void BtnSmartCard_Click(object sender, EventArgs e)
        {
            InitSmartCardReader();
        }

        private void LbReady_Click(object sender, EventArgs e)
        {

        }
    }
    public enum HttpPostMode
    {
        Normal,
        Abnormal
    }
}
