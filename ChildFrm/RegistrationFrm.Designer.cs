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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbPartNumber = new System.Windows.Forms.TextBox();
            this.TbPartName1 = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.DgvList = new System.Windows.Forms.DataGridView();
            this.BtnListup = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnCopyTo = new System.Windows.Forms.Button();
            this.TbPartName2 = new System.Windows.Forms.TextBox();
            this.TbPartName3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(667, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Part name";
            // 
            // TbPartNumber
            // 
            this.TbPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartNumber.Location = new System.Drawing.Point(700, 20);
            this.TbPartNumber.MaxLength = 20;
            this.TbPartNumber.Name = "TbPartNumber";
            this.TbPartNumber.Size = new System.Drawing.Size(196, 31);
            this.TbPartNumber.TabIndex = 3;
            // 
            // TbPartName1
            // 
            this.TbPartName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName1.Location = new System.Drawing.Point(748, 85);
            this.TbPartName1.MaxLength = 8;
            this.TbPartName1.Name = "TbPartName1";
            this.TbPartName1.Size = new System.Drawing.Size(130, 31);
            this.TbPartName1.TabIndex = 4;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(748, 217);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(96, 34);
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
            this.DgvList.Location = new System.Drawing.Point(27, 89);
            this.DgvList.Name = "DgvList";
            this.DgvList.ReadOnly = true;
            this.DgvList.Size = new System.Drawing.Size(615, 334);
            this.DgvList.TabIndex = 6;
            // 
            // BtnListup
            // 
            this.BtnListup.Location = new System.Drawing.Point(27, 58);
            this.BtnListup.Name = "BtnListup";
            this.BtnListup.Size = new System.Drawing.Size(75, 23);
            this.BtnListup.TabIndex = 7;
            this.BtnListup.Text = "List up";
            this.BtnListup.UseVisualStyleBackColor = true;
            this.BtnListup.Click += new System.EventHandler(this.BtnListup_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(121, 61);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "Delecte";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnCopyTo
            // 
            this.BtnCopyTo.Location = new System.Drawing.Point(223, 58);
            this.BtnCopyTo.Name = "BtnCopyTo";
            this.BtnCopyTo.Size = new System.Drawing.Size(75, 23);
            this.BtnCopyTo.TabIndex = 9;
            this.BtnCopyTo.Text = "Copy to..";
            this.BtnCopyTo.UseVisualStyleBackColor = true;
            this.BtnCopyTo.Click += new System.EventHandler(this.BtnCopyTo_Click);
            // 
            // TbPartName2
            // 
            this.TbPartName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName2.Location = new System.Drawing.Point(748, 130);
            this.TbPartName2.MaxLength = 8;
            this.TbPartName2.Name = "TbPartName2";
            this.TbPartName2.Size = new System.Drawing.Size(130, 31);
            this.TbPartName2.TabIndex = 4;
            // 
            // TbPartName3
            // 
            this.TbPartName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName3.Location = new System.Drawing.Point(748, 167);
            this.TbPartName3.MaxLength = 8;
            this.TbPartName3.Name = "TbPartName3";
            this.TbPartName3.Size = new System.Drawing.Size(130, 31);
            this.TbPartName3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(670, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 75);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Location = new System.Drawing.Point(758, 376);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(86, 32);
            this.BtnPreview.TabIndex = 11;
            this.BtnPreview.Text = "Preview";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // RegistrationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnCopyTo);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnListup);
            this.Controls.Add(this.DgvList);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TbPartName3);
            this.Controls.Add(this.TbPartName2);
            this.Controls.Add(this.TbPartName1);
            this.Controls.Add(this.TbPartNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationFrm";
            this.Text = "RegistrationFrm";
            this.Load += new System.EventHandler(this.RegistrationFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbPartNumber;
        private System.Windows.Forms.TextBox TbPartName1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView DgvList;
        private System.Windows.Forms.Button BtnListup;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnCopyTo;
        private System.Windows.Forms.TextBox TbPartName2;
        private System.Windows.Forms.TextBox TbPartName3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnPreview;
    }
}