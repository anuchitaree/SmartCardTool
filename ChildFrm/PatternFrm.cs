using SmartCardTool.Modules;
using System;
using System.IO;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class PatternFrm : Form
    {
        public PatternFrm()
        {
            InitializeComponent();
        }

        private void PatternFrm_Load(object sender, EventArgs e)
        {
            string path0 = Environment.CurrentDirectory;


            string path1 = $"{path0}\\{Param.Setting}";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }

            Param.Pages = 2;

            Loadpattern();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void BtnTest_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            TbScan.Text = Clipboard.GetText();
            Tblen.Text = $"[ {TbScan.Text.Length} ]";
        }

        private void TbScan_TabIndexChanged(object sender, EventArgs e)
        {
            int aa = TbScan.SelectionStart;
        }

        private void Tblen_DoubleClick(object sender, EventArgs e)
        {
            Tblen.Text = $"[ {TbScan.Text.Length} ]";
        }

        //================//

        #region Sub Program

        private void Loadpattern()
        {
            string env = Environment.CurrentDirectory;
            string path = $"{env}\\Setting\\pattern.txt";
            if (!File.Exists(path))
            {
                //MessageBox.Show("Please Setup pattern first, SETUP -> PATTERN ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string data = File.ReadAllText(path);

            string[] parts = data.Split(',');
            if (parts.Length > 3)
            {
                TbSetTotal.Text = int.Parse(parts[0]).ToString();
                TbPNstart.Text = Convert.ToInt32(parts[1]).ToString();
                TbPNqty.Text = Convert.ToInt32(parts[2]).ToString();
            }
        }
        private void Save()
        {
            try
            {
                if (TbSetTotal.Text.Trim() == String.Empty || TbPNstart.Text.Trim() == String.Empty ||
                   TbPNqty.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Please fill all setting point before saving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult r = MessageBox.Show("Are you sure ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No) return;

                string path0 = Environment.CurrentDirectory;

                string path1 = $"{path0}\\{Param.Setting}";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }



                string path = string.Format($"{path1}\\pattern.txt");


                string data = string.Format("{0},{1},{2},{3}", TbSetTotal.Text, TbPNstart.Text, TbPNqty.Text,

                TbScan.Text);

                File.WriteAllText(path, data);
                Param.Patterns.TotalLength = int.Parse(TbSetTotal.Text);

                Param.Patterns.Start = int.Parse(TbPNstart.Text);
                Param.Patterns.Length = int.Parse(TbPNqty.Text);


                MessageBox.Show("Save pattern completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("Save pattern is NOT completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Test()
        {
            int totalletter = int.Parse(TbSetTotal.Text);

            int startletter = int.Parse(TbPNstart.Text);
            int lenletter = int.Parse(TbPNqty.Text);

            string txt = TbScan.Text;
            int lentxt = txt.Length;
            if (lentxt == totalletter && (startletter + lenletter) <= totalletter)
            {
                string result = txt.Substring(startletter, lenletter);
                TbPartnumber.Text = result;
            }


        }






        #endregion


    }
}
