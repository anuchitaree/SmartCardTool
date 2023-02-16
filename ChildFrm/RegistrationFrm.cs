using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using SmartCardTool.Modules.Initial;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SmartCardTool.ChildFrm
{
    public partial class RegistrationFrm : Form
    {
        public RegistrationFrm()
        {
            InitializeComponent();
        }

        private void RegistrationFrm_Load(object sender, EventArgs e)
        {
            //string path1 = $"{Environment.CurrentDirectory}\\Static";

            //if (!Directory.Exists(path1))
            //{
            //    Directory.CreateDirectory(path1);
            //}

            //string path2 = $"{path1}\\Sourcefiles";

            //if (!Directory.Exists(path2))
            //{
            //    Directory.CreateDirectory(path2);
            //}

            string[] header = new string[] { "key", "No", "Search number", "Head", "Right R1", "Right R2", "Right R3" };
            int[] width = new int[] { 5, 30, 150, 100, 100, 100, 100 };

            DataGridViewInit.Pattern_1(DgvList, header, width);

            Param.Pages = 3;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            RegistrationSave();
        }

        private void BtnListup_Click(object sender, EventArgs e)
        {
            ListUp();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BtnCopyTo_Click(object sender, EventArgs e)
        {
            CopyTo();
        }

        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvList.CurrentRow.Index < 0) return;
            int index = DgvList.CurrentRow.Index;
            TbSearchPartnumber.Text = DgvList.Rows[index].Cells[2].Value.ToString();
            TbPartName0.Text = DgvList.Rows[index].Cells[3].Value.ToString();
            TbPartName1.Text = DgvList.Rows[index].Cells[4].Value.ToString();
            TbPartName2.Text = DgvList.Rows[index].Cells[5].Value.ToString();
            TbPartName3.Text = DgvList.Rows[index].Cells[6].Value.ToString();

        }

        private void TbSearchPartnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSearch.Focus();
            }
        }


        //=================//
        #region Sub Program

        private async void RegistrationSave()
        {
            try
            {

                if (TbSearchPartnumber.Text.Trim() == String.Empty)
                {
                    return;
                }

                using (var db = new DBContext())
                {
                    var existData = await db.Smartcards
                        .Where(x => x.Partnumber == TbSearchPartnumber.Text.Trim()).ToListAsync();
                    if (existData.Count > 0)
                    {
                        foreach (var item in existData)
                        {
                            item.Partname0 = TbPartName0.Text;
                            item.Partname1 = TbPartName1.Text;
                            item.Partname2 = TbPartName2.Text;
                            item.Partname3 = TbPartName3.Text;
                        }

                        db.SaveChanges();
                        MessageBox.Show("Already had part number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var record = new Smartcard()
                    {
                        Partnumber = TbSearchPartnumber.Text.Trim(),
                        Partname0 = TbPartName0.Text,
                        Partname1 = TbPartName1.Text,
                        Partname2 = TbPartName2.Text,
                        Partname3 = TbPartName3.Text,

                    };
                    db.Smartcards.Add(record);
                    db.SaveChanges();
                    MessageBox.Show("Save part completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TbSearchPartnumber.Text = TbPartName0.Text = TbPartName1.Text = TbPartName2.Text = TbPartName3.Text = String.Empty;

                }


            }
            catch
            {
                MessageBox.Show("Save Image is not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void ListUp()
        {
            try
            {
                using (var db = new DBContext())
                {

                    var wsLists = db.Smartcards.ToList();

                    DgvList.Rows.Clear();
                    int i = 1;
                    foreach (var item in wsLists)
                    {
                        DgvList.Rows.Add(item.Id, i++, item.Partnumber, item.Partname0, item.Partname1, item.Partname2, item.Partname3);
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Delete()
        {
            try
            {
                if (DgvList.RowCount > 0)
                {
                    DialogResult r = MessageBox.Show("Are you sure ?", "Delete Working-Standard List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int row = DgvList.CurrentRow.Index;

                        int key = Convert.ToInt32(DgvList.Rows[row].Cells[0].Value.ToString());
                        DgvList.Rows.RemoveAt(row);

                        using (var db = new DBContext())
                        {
                            var exist = db.Smartcards.Where(x => x.Id == key).ToList();
                            db.Smartcards.RemoveRange(exist);
                            db.SaveChanges();
                            MessageBox.Show("Delete image completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Delete image is NOT completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CopyTo()
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog
                {
                    RootFolder = Environment.SpecialFolder.Desktop,
                    SelectedPath = @"C:\",
                    ShowNewFolderButton = true
                };

                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = folderDlg.SelectedPath;

                    int row = DgvList.CurrentRow.Index;

                    string source = DgvList.Rows[row].Cells[3].Value.ToString();

                    string[] files = source.Split('\\');
                    int len = files.Length;
                    string filename = files[len - 1];


                    string destination = $"{path}\\{filename}";
                    FileInfo fi = new FileInfo(destination);
                    fi.CopyTo(destination, true);
                    MessageBox.Show("Copy image to destination completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Copy image to destination Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        #endregion

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void Preview()
        {
            ImageInfo imageInfo = CreateImage(TbPartName0.Text, TbPartName1.Text, TbPartName2.Text, TbPartName3.Text);

            //pictureBox1.Width = 300;
            //pictureBox1.Height = 200;
            //pictureBox1.Left = 117;
            //pictureBox1.Top = 74;
            //pictureBox1.Refresh();

            //label1.Text = "2.9 inch (300 x 200)";
            //txtCommand.Text = BitConverter.ToString(imageInfo.GetImage());
        }

        private ImageInfo CreateImage(string partnumber, string partname1, string partname2, string partname3)
        {
            DisplayPainter display = new DisplayPainter(DisplayPainter.DisplaySizeType.Size300x200, false);

            //'Draws text
            display.PutText(partnumber, new Font("Arial", 9), 0, 0, true);
            display.PutText(partname1, new Font("Arial", 18, FontStyle.Bold), 8, 23, false);
            display.PutText(partname2, new Font("Arial", 18, FontStyle.Bold), 8, 23, false);
            display.PutText(partname3, new Font("Arial", 18, FontStyle.Bold), 8, 23, false);

            //'Draws line
            display.PutLine(8, 52, 292, 52, 1, false);


            //'Draws barcode
            var code39 = new QRCode();
            code39.BarcodeData = $"{partnumber}_{DateTime.Now:dd-MM-yyyy}";
            code39.Height = 60;
            code39.RotateFlip = RotateFlipType.Rotate270FlipNone;
            display.PutBarcode(code39, 220, 65);

            //Show preview
            //pictureBox1.Image = display.Preview;

            return display.GetLocalDisplayImage();
        }




        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchDataInDB();
        }



        private async void SearchDataInDB()
        {
            using (var db = new DBContext())
            {
                var list = await db.Smartcards.Where(x => x.Partnumber == TbSearchPartnumber.Text.Trim())
                    .FirstOrDefaultAsync();

                if (list == null) return;

                TbPartName0.Text = list.Partname0;
                TbPartName1.Text = list.Partname1;
                TbPartName2.Text = list.Partname2;
                TbPartName3.Text = list.Partname3;

            }

        }



    }
}