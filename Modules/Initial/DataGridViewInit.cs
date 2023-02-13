using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartCardTool.Modules.Initial
{
    public static class DataGridViewInit
    {
        public static void Pattern_1(DataGridView Dgv, string[] header, int[] width)
        {
            int len = header.Length;
            Dgv.ColumnCount = len;
            for (int i = 0; i < len; i++)
            {
                Dgv.Columns[i].Name = header[i];
                Dgv.Columns[i].Width = width[i];
                Dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Dgv.Columns[header[0]].Visible = false;
            Dgv.RowHeadersWidth = 4;
            Dgv.DefaultCellStyle.Font = new Font("Tahoma", 9);
            Dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9);
            Dgv.RowTemplate.Height = 30;

            Dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            Dgv.AllowUserToResizeRows = false;
            Dgv.AllowUserToResizeColumns = false;

        }





    }
}
