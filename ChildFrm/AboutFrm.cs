using SmartCardTool.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Startup();

            Param.Pages = 4;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Startup()
        {
            string productkey = "5ZMD-ZWSJ-YFMW-WRMZ";

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == string.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }

            TbProKey.Text = productkey;

            TbMac.Text = EncodingMacAddress(sMacAddress);
        }

        private string EncodingMacAddress(string input)
        {
            string sMacAddress = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
            sMacAddress = sMacAddress.Insert(4, "-");
            sMacAddress = sMacAddress.Insert(9, "-");
            return sMacAddress.Insert(14, "-");
        }
    }
}
