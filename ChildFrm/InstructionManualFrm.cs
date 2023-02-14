using SmartCardTool.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class InstructionManualFrm : Form
    {
        public InstructionManualFrm()
        {
            InitializeComponent();
        }

        private void InstructionManual_Load(object sender, EventArgs e)
        {
            Param.Pages = 5;
        }
    }
}
