using SmartCardTool.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class ComportFrm : Form
    {

        private static SerialPort serialPort = new SerialPort();

        private static string ReadingText = null;



        public ComportFrm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            OpenPort();
        }

        private void ComportFrm_Load(object sender, EventArgs e)
        {
            string path0 = Environment.CurrentDirectory;

            string path1 = $"{path0}\\{Param.Setting}";

            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }

            COMPort();

            LoadSettingfile();

            Param.Pages = 1;
        }

        private void ComportFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ReadingText != null)
            {
                AsyncInsertTable(ReadingText);
            }
            ReadingText = null;
        }


        //===============================//
        #region  Sub Program

        private void COMPort()
        {
            for (int i = 1; i < 20; i++)
            {
                string str = string.Format("COM{0}", i);
                CmbCom.Items.Add(str);
            }
            CmbCom.SelectedIndex = 0;
            string[] baudrate = new string[] { "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600" };
            string[] parity = new string[] { "None", "Even", "Odd" };
            string[] lenght = new string[] { "7", "8", "9" };
            string[] stopbit = new string[] { "1", "1.5", "2" };
            CmbBaudRate.DataSource = baudrate;
            CmbParity.DataSource = parity;
            CmbDatalength.DataSource = lenght;
            CmbStopBit.DataSource = stopbit;
        }
        private void LoadSettingfile()
        {
            string path = $"{Environment.CurrentDirectory}\\{Param.Setting}\\port.txt";

            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                string[] parts = data.Split(',');
                if (parts.Length == 5)
                {
                    string comport = parts[0];
                    string baudrate = parts[1];
                    string parity = parts[2];
                    string dataBits = parts[3];
                    string stopbit = parts[4];

                    CmbCom.SelectedItem = comport;


                    CmbBaudRate.SelectedItem = baudrate;
                    CmbParity.SelectedItem = parity;
                    CmbDatalength.SelectedItem = dataBits;
                    CmbStopBit.SelectedItem = stopbit;
                }
            }
        }

        private void SaveSetting()
        {
            try
            {
                string setting = string.Format("{0},{1},{2},{3},{4}", CmbCom.SelectedItem, CmbBaudRate.SelectedItem, CmbParity.SelectedItem,
                   CmbDatalength.SelectedItem, CmbStopBit.SelectedItem);

                string path = $"{Environment.CurrentDirectory}\\{Param.Setting}\\port.txt";

                File.WriteAllText(path, setting);
                MessageBox.Show("Save Communication port setting Completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Save Communication port setting Error, try it again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                                BtnReload.BackColor = Color.Green;
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
                        BtnReload.BackColor = Color.FromArgb(246, 246, 246);
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

        private void AsyncInsertTable(string partnumber)
        {
            TbTrial.Text = partnumber;
            if (TbTrial.Text != String.Empty)
                Clipboard.SetText(TbTrial.Text);
        }


        #endregion


    }
}
