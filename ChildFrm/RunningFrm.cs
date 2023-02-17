﻿using Aioi;
using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using Newtonsoft.Json;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using SmartCartTool_API.Models;
using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
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
        public RunningFrm()
        {
            InitializeComponent();
        }

        private void RunningFrm_Load(object sender, EventArgs e)
        {

            FormLoading();

        }

        private void RunningFrm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AsyncInsertTable();
        }

        private void BtnReloadApp_Click(object sender, EventArgs e)
        {
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
                catch (Exception ex)
                {
                    InvokeCtrl(LbStatus, ex.Message);

                    InvokeLampRed(LbError, true);
                    //WriteLog("Card open failed - " + ex.Message);
                    return;
                }
                StartProcess();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            AsyncInsertTable();
        }

        private void FormLoading()
        {
            Param.Pages = 9;

            string path0 = Environment.CurrentDirectory;

            string path1 = $"{path0}\\{Param.Setting}";

            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }

            LbStatus.Text = "";

            Init();

            LampNO();


            timer1.Interval = 100;
            timer1.Enabled = true;

        }

        private void LampNO()
        {
            LbOK.BackColor = Color.FromArgb(0, 28, 0);
            LbOK.ForeColor = Color.FromArgb(60, 60, 60);
            LbNG.BackColor = Color.FromArgb(42, 0, 0);
            LbNG.ForeColor = Color.FromArgb(60, 60, 60);

            LbReady.BackColor = LbReceived.BackColor = LbFindDB.BackColor = LbWriteTag.BackColor
                = LbSendToStock.BackColor = LbCompleted.BackColor = LbError.BackColor = Color.White;

        }

        private void LampOKNG(bool status)
        {
            if (status)
            {
                LbNG.BackColor = Color.FromArgb(42, 0, 0);
                LbNG.ForeColor = Color.FromArgb(60, 60, 60);
                LbOK.BackColor = Color.FromArgb(85, 255, 85);
                LbOK.ForeColor = Color.FromArgb(0, 0, 0);
            }
            else
            {
                LbOK.BackColor = Color.FromArgb(0, 28, 0);
                LbOK.ForeColor = Color.FromArgb(60, 60, 60);
                LbNG.BackColor = Color.FromArgb(255, 85, 85);
                LbNG.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void LampError(bool status)
        {
            if (status)
            {
                LbError.BackColor = Color.FromArgb(255, 85, 85);
                LbError.ForeColor = Color.FromArgb(0, 0, 0);
            }
            else
            {
                LbError.BackColor = Color.FromArgb(60, 60, 60);
                LbError.ForeColor = Color.FromArgb(60, 60, 60);
            }
        }
        private void Init()
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
                    InvokeCtrl(LbStatus, "A3 :No connection => Smart card reader has not yet connected. After connect, hit Reload App");

                    InvokeLampRed(LbError, true);

                    return;
                }

                _adapterName = PCSCModules.GetAdapters(_context)[0].ToUpper();



                if (_adapterName.Contains(ACR1252))
                {
                    _adapter = new ACR1252_Adapter();
                }
                else
                {
                    InvokeCtrl(LbStatus, "A4 : No compatible adapters found");

                    InvokeLampRed(LbError, true);

                    return;
                }

                _adapter.OpenAdapter();
                _adapter.Name = _adapterName;
                _adapter.Context = _context;
                _smartcard = new SmartTag(_adapter);

                InvokeCtrl(LbStatus, STATUSREADY);

                InvokeLampGreen(LbReady, true);


            }
            catch (Exception ex)
            {
                InvokeCtrl(LbStatus, ex.Message);

                InvokeLampRed(LbError, true);

            }


        }


        private async void AsyncInsertTable()
        {
            //@"C:\Users\Administrator\source\repos\SmartCartTool_API\bin\Release\net6.0\publish\partnumber.txt"
            string path = Param.DataPath;

            if (!File.Exists(path))
            {
                return;
            }
            string data = File.ReadAllText(path);

            string[] parts = data.Split(',');

            if (parts.Length != 3) return;

            timer1.Enabled = false;

            string partnumber = parts[0];

            CmbScanner.Text = partnumber;

            using (var db = new DBContext())
            {
                var existData = await db.Smartcards.Where(x => x.Partnumber == partnumber)
                    .FirstOrDefaultAsync();

                if (existData == null)
                {
                    TbPartName0.Text =
                    TbPartName1.Text =
                    TbPartName2.Text =
                    TbPartName3.Text = String.Empty;

                    InvokeCtrl(LbStatus, "A2 :Not registration => Non data in database, Tool -> Registration");

                    LampOKNG(false);

                    InvokeLampRed(LbError, true);

                    Sound(Param.InCompleteSound);

                    return;
                }

                TbPartName0.Text = existData.Partname0;
                TbPartName1.Text = existData.Partname1;
                TbPartName2.Text = existData.Partname2;
                TbPartName3.Text = existData.Partname3;

                if (StartPolling())
                {
                    _smartcard.SelectedFunction = SmartTag.SmartTagFunctions.ShowImage;
                    _smartcard.SetImageData(CreateImage(existData.Partname0, existData.Partname1,
               existData.Partname2, existData.Partname3));


                    var client = new HttpClient();


                    var newjson = new PartNumber()
                    {
                        PartNoSubAssy = parts[0],
                        LotId = parts[1],
                        TimeStamp = parts[2],
                    };
                    string json = JsonConvert.SerializeObject(newjson, Formatting.Indented);

                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    bool result = false;
                    while (result)
                    {

                        var response = await client.PostAsync(Param.UploadUrl, httpContent);

                        if (response.IsSuccessStatusCode)
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {

                                File.Delete(Param.DataPath);

                                await Task.Delay(100);
                                timer1.Enabled = true;
                                result = true; // exit while loop
                            }
                        }
                        else
                        {
                            await Task.Delay(3000);
                        }

                    }


                }

                return;
            }
        }


        private bool StartPolling()
        {
            if (_smartcard == null)
            {
                return false;
            }
            InvokeCtrl(LbStatus, STATUSTOUCH);

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

        private void StartProcess()
        {
            try
            {
                byte[] idm = _adapter.GetIdm();
                //Label_IDm.Text = BitConverter.ToString(idm);

                //Label_Message.Text = STATUSPROCESS;



                InvokeCtrl(LbStatus, STATUSPROCESS);


                this.Refresh();

                _smartcard.SetIdm(idm);

                _smartcard.StartProcess();

                InvokeCtrl(LbStatus, STATUSCOMPLETED);


                _adapter.CloseCard();



                Sound(Param.CompleteSound);



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

                InvokeCtrl(LbStatus, ex.Message);
            }
        }

        private void Sound(string path)
        {
            if (!File.Exists(path)) return;

            using (var soundPlayer = new SoundPlayer(path))
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }


        private void InvokeCtrl(Control ctrl, string message)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(() =>
                {
                    ctrl.Text = message;
                }));
            }
            else
            {
                ctrl.Text = message;
            }
        }
        private void InvokeLampRed(Control ctrl, bool status)
        {
            if (status)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(255, 85, 85);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(255, 85, 85);
                }
            }
            else
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(255, 255, 255);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }
        private void InvokeLampGreen(Control ctrl, bool status)
        {
            if (status)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(85, 255, 85);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(85, 255, 85);
                }
            }
            else
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(0, 0, 0);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(0, 0, 0);
                }
            }
        }
        private void InvokeLampOrange(Control ctrl, bool status)
        {
            if (status)
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(255, 104, 0);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(255, 104, 0);
                }
            }
            else
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new Action(() =>
                    {
                        ctrl.BackColor = Color.FromArgb(0, 0, 0);
                    }));
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(0, 0, 0);
                }
            }
        }

        
    }
}