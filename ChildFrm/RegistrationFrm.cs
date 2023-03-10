using AioiSystems.DotModule;
using AioiSystems.DotModule.Barcode;
using Newtonsoft.Json;
using SmartCardTool.Models;
using SmartCardTool.Modules;
using SmartCardTool.Modules.Initial;
using System;
using System.Collections.Generic;
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

            string[] header = new string[] { "key", "No", "Search number", "Header", "Right Row1", "Right Row2", "Right Row3" };
            int[] width = new int[] { 5, 30, 150, 150, 150, 150, 150 };

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

                    TbPartName0.Text = TbPartName0.Text == string.Empty ? " " : TbPartName0.Text;
                    TbPartName1.Text = TbPartName1.Text == string.Empty ? " " : TbPartName1.Text;
                    TbPartName2.Text = TbPartName2.Text == string.Empty ? " " : TbPartName2.Text;
                    TbPartName3.Text = TbPartName3.Text == string.Empty ? " " : TbPartName3.Text;


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TbSearchPartnumber_TextChanged(object sender, EventArgs e)
        {
            TbPartName0.Text = TbSearchPartnumber.Text;
        }

        private async void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var existdata = await db.Smartcards.ToListAsync();

                    if (existdata.Count == 0) return;

                    string json = JsonConvert.SerializeObject(existdata, Formatting.Indented);

                    FolderBrowserDialog folderDlg = new FolderBrowserDialog
                    {
                        RootFolder = Environment.SpecialFolder.Desktop,
                        //SelectedPath = @"C:\",
                        ShowNewFolderButton = true
                    };
                    DialogResult result = folderDlg.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string destination = $"{folderDlg.SelectedPath}\\backup-smartcard-database.json";
                        using (StreamWriter sw = new StreamWriter(destination))
                        {
                            sw.WriteLine(json);
                        }
                        MessageBox.Show("Backup database completed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Backup database is NOT complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                    RestoreDirectory = true,
                    Title = "Browse JSON Files",
                    DefaultExt = "json",
                    Filter = "Json files (*.json)|*.json",
                    FilterIndex = 2
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    openFileDialog1.Multiselect = false;
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string json = sr.ReadToEnd();
                        var backupdata = JsonConvert.DeserializeObject<List<Smartcard>>(json);
                        if (backupdata.Count == 0) return;

                        using (var db = new DBContext())
                        {
                            foreach (var item in backupdata)
                            {
                                var exist = await db.Smartcards.FirstOrDefaultAsync(x=>x.Partnumber==item.Partnumber);
                                if (exist != null) continue;
                                var newrecode = new Smartcard()
                                {
                                    Partnumber = item.Partnumber,
                                    Partname0 = item.Partname0,
                                    Partname1 = item.Partname1,
                                    Partname2 = item.Partname2,
                                    Partname3 = item.Partname3,
                                };
                                db.Smartcards.Add(newrecode);

                            }
                            db.SaveChanges();
                            MessageBox.Show("Restore database completed.","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Restore database is NOT complete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}