using Newtonsoft.Json;
using SmartCardTool.ChildFrm;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SmartCardTool
{
    public partial class MainFrm : Form
    {
        private Form activeForm = null;

        public MainFrm()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(975, 0);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

            FormLoad();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new RunningFrm());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new RegistrationFrm());
        }

        private void licensedToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CloseOpenChildForm(new AboutFrm());

        }

        private void instructionManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructionManual();
        }

        private void licensedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFrm frm = new AboutFrm();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Param.Pages == 0)
            {
                CloseOpenChildForm(new RunningFrm());

            }
        }

        //==== Sub Program ===//


        private void CloseOpenChildForm(Form switchForm)
        {

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "MainFrm")
                    Application.OpenForms[i].Close();
            }

            try
            {
                if (activeForm != null)
                {
                    this.pnlForm.Controls.Remove(switchForm);
                    activeForm.Close();
                }

                activeForm = switchForm;
                switchForm.TopLevel = false;
                switchForm.FormBorderStyle = FormBorderStyle.None;
                switchForm.Dock = DockStyle.Fill;

                this.pnlForm.Controls.Add(switchForm);
                this.pnlForm.Tag = switchForm;

                switchForm.BringToFront();
                switchForm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void FormLoad()
        {
            string path = @"c:\SmartCardTool";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            string path1 = @"c:\SmartCardTool\appsettings.json"; /*Environment.CurrentDirectory + "\\appsettings.json";*/
            if (!File.Exists(path1))
            {
                var paths = new Paths()
                {
                    DataPath = "C:\\SmartCardTool\\partnumber.txt",
                    UploadUrl = "http://localhost:5217",
                    HoldResultSec=10,

                };
                var sett = new AppSettings()
                {
                    Path = paths
                };
                string json = JsonConvert.SerializeObject(sett, Formatting.Indented);

                File.WriteAllText(path1, json);

            }

            using (var reader = new StreamReader(path1))
            {
                string readline = reader.ReadToEnd();

                var appSettings = JsonConvert.DeserializeObject<AppSettings>(readline);

                Param.DataPath = appSettings.Path.DataPath;
                Param.UploadUrl = appSettings.Path.UploadUrl;
                Param.HoldResultSec=appSettings.Path.HoldResultSec;
            }
        }

        private void InstructionManual()
        {
            string path = Param.manual;
            if (!File.Exists(path)) return;


            string cmd = @"--kiosk {path}";
            ProcessStartInfo startInfo = new ProcessStartInfo(cmd);
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start("firefox.exe", path);
        }
    }
}
