using SmartCardTool.ChildFrm;
using SmartCardTool.Modules;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SmartCardTool
{
    public partial class MainFrm : Form
    {
        private Form activeForm = null;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //var configBuilder = new ConfigurationBuilder().
            // AddJsonFile("appsettings.json").Build();

            //// get the section to read
            //var configSection = configBuilder.GetSection("AppSettings");

            //// get the configuration values in the section.
            //var client_id = configSection["id"] ?? null;

            //Param.ConnectionString = configBuilder.GetSection("ConnectionStrings")["defaultConnection"]!;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new StartFrm());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new RegistrationFrm());
        }

        private void comportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new ComportFrm());
        }


        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpenChildForm(new PatternFrm());
        }

        private void instructionManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"--kiosk D:\WSStore\z353.pdf";
            ProcessStartInfo startInfo = new ProcessStartInfo(path);
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start("firefox.exe", path);
        }

        private void licensedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFrm frm = new AboutFrm();
            frm.ShowDialog();
        }

        //=========
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Param.Pages == 0)
            {
                CloseOpenChildForm(new StartFrm());

            }
        }
    }
}
