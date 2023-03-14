namespace SmartCardTool.ChildFrm
{
    partial class RegistrationFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbPartName0 = new System.Windows.Forms.TextBox();
            this.TbPartName1 = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.DgvList = new System.Windows.Forms.DataGridView();
            this.BtnListup = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.TbPartName2 = new System.Windows.Forms.TextBox();
            this.TbPartName3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TbSearchPartnumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbPartName0
            // 
            this.TbPartName0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName0.Location = new System.Drawing.Point(16, 17);
            this.TbPartName0.MaxLength = 12;
            this.TbPartName0.Name = "TbPartName0";
            this.TbPartName0.Size = new System.Drawing.Size(247, 29);
            this.TbPartName0.TabIndex = 3;
            // 
            // TbPartName1
            // 
            this.TbPartName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName1.Location = new System.Drawing.Point(125, 61);
            this.TbPartName1.MaxLength = 8;
            this.TbPartName1.Name = "TbPartName1";
            this.TbPartName1.Size = new System.Drawing.Size(137, 24);
            this.TbPartName1.TabIndex = 4;
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(689, 139);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(84, 50);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // DgvList
            // 
            this.DgvList.AllowUserToAddRows = false;
            this.DgvList.AllowUserToDeleteRows = false;
            this.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvList.Location = new System.Drawing.Point(3, 53);
            this.DgvList.Name = "DgvList";
            this.DgvList.ReadOnly = true;
            this.DgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvList.Size = new System.Drawing.Size(772, 349);
            this.DgvList.TabIndex = 6;
            this.DgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvList_CellDoubleClick);
            // 
            // BtnListup
            // 
            this.BtnListup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnListup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListup.Location = new System.Drawing.Point(675, 3);
            this.BtnListup.Name = "BtnListup";
            this.BtnListup.Size = new System.Drawing.Size(94, 38);
            this.BtnListup.TabIndex = 7;
            this.BtnListup.Text = "List up";
            this.BtnListup.UseVisualStyleBackColor = true;
            this.BtnListup.Click += new System.EventHandler(this.BtnListup_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(575, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(94, 38);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // TbPartName2
            // 
            this.TbPartName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName2.Location = new System.Drawing.Point(126, 99);
            this.TbPartName2.MaxLength = 8;
            this.TbPartName2.Name = "TbPartName2";
            this.TbPartName2.Size = new System.Drawing.Size(137, 24);
            this.TbPartName2.TabIndex = 4;
            // 
            // TbPartName3
            // 
            this.TbPartName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName3.Location = new System.Drawing.Point(126, 140);
            this.TbPartName3.MaxLength = 8;
            this.TbPartName3.Name = "TbPartName3";
            this.TbPartName3.Size = new System.Drawing.Size(137, 24);
            this.TbPartName3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.TbSearchPartnumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 194);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Part  Number Sub-Assy(call from Stock monitoring)";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(305, 29);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(78, 35);
            this.BtnSearch.TabIndex = 14;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TbSearchPartnumber
            // 
            this.TbSearchPartnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSearchPartnumber.Location = new System.Drawing.Point(11, 33);
            this.TbSearchPartnumber.MaxLength = 12;
            this.TbSearchPartnumber.Name = "TbSearchPartnumber";
            this.TbSearchPartnumber.Size = new System.Drawing.Size(278, 29);
            this.TbSearchPartnumber.TabIndex = 12;
            this.TbSearchPartnumber.TextChanged += new System.EventHandler(this.TbSearchPartnumber_TextChanged);
            this.TbSearchPartnumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearchPartnumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Smart Card 2.9inch (SC1029L)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TbPartName0);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.TbPartName1);
            this.panel3.Controls.Add(this.TbPartName3);
            this.panel3.Controls.Add(this.TbPartName2);
            this.panel3.Location = new System.Drawing.Point(404, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 174);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(15, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 103);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 42);
            this.label1.TabIndex = 13;
            this.label1.Text = "QR";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 611);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DgvList, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 203);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(778, 405);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BtnListup, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnDelete, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnBackup, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnRestore, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(772, 44);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // BtnBackup
            // 
            this.BtnBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBackup.Location = new System.Drawing.Point(3, 3);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(94, 38);
            this.BtnBackup.TabIndex = 9;
            this.BtnBackup.Text = "Backup DB";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnRestore
            // 
            this.BtnRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRestore.Location = new System.Drawing.Point(103, 3);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(94, 38);
            this.BtnRestore.TabIndex = 10;
            this.BtnRestore.Text = "Restore DB";
            this.BtnRestore.UseVisualStyleBackColor = true;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Row1 max 8 charactors";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Row2 max 8 charactors";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Row3 max 8 charactors";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Header max 12 charactors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "146px/30mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "max 12 charactors";
            // 
            // RegistrationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RegistrationFrm";
            this.Text = "RegistrationFrm";
            this.Load += new System.EventHandler(this.RegistrationFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TbPartName0;
        private System.Windows.Forms.TextBox TbPartName1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView DgvList;
        private System.Windows.Forms.Button BtnListup;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox TbPartName2;
        private System.Windows.Forms.TextBox TbPartName3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbSearchPartnumber;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.Button BtnRestore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}