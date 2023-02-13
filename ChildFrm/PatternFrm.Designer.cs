namespace SmartCardTool.ChildFrm
{
    partial class PatternFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TbScan = new System.Windows.Forms.TextBox();
            this.TbSetTotal = new System.Windows.Forms.TextBox();
            this.TbPNstart = new System.Windows.Forms.TextBox();
            this.TbPNqty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tblen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnTest = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TbPartnumber = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbPartnumber);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.BtnTest);
            this.panel1.Controls.Add(this.BtnPaste);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Tblen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TbPNqty);
            this.panel1.Controls.Add(this.TbPNstart);
            this.panel1.Controls.Add(this.TbSetTotal);
            this.panel1.Controls.Add(this.TbScan);
            this.panel1.Location = new System.Drawing.Point(69, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 323);
            this.panel1.TabIndex = 0;
            // 
            // TbScan
            // 
            this.TbScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbScan.Location = new System.Drawing.Point(89, 20);
            this.TbScan.Multiline = true;
            this.TbScan.Name = "TbScan";
            this.TbScan.Size = new System.Drawing.Size(399, 114);
            this.TbScan.TabIndex = 0;
            this.TbScan.TabIndexChanged += new System.EventHandler(this.TbScan_TabIndexChanged);
            // 
            // TbSetTotal
            // 
            this.TbSetTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSetTotal.Location = new System.Drawing.Point(211, 180);
            this.TbSetTotal.Name = "TbSetTotal";
            this.TbSetTotal.Size = new System.Drawing.Size(100, 29);
            this.TbSetTotal.TabIndex = 1;
            // 
            // TbPNstart
            // 
            this.TbPNstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPNstart.Location = new System.Drawing.Point(211, 218);
            this.TbPNstart.Name = "TbPNstart";
            this.TbPNstart.Size = new System.Drawing.Size(100, 29);
            this.TbPNstart.TabIndex = 2;
            // 
            // TbPNqty
            // 
            this.TbPNqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPNqty.Location = new System.Drawing.Point(211, 258);
            this.TbPNqty.Name = "TbPNqty";
            this.TbPNqty.Size = new System.Drawing.Size(100, 29);
            this.TbPNqty.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total letter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Q\'TY";
            // 
            // Tblen
            // 
            this.Tblen.AutoSize = true;
            this.Tblen.Location = new System.Drawing.Point(317, 180);
            this.Tblen.Name = "Tblen";
            this.Tblen.Size = new System.Drawing.Size(31, 13);
            this.Tblen.TabIndex = 5;
            this.Tblen.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "From scanner";
            // 
            // BtnPaste
            // 
            this.BtnPaste.Location = new System.Drawing.Point(413, 140);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(75, 23);
            this.BtnPaste.TabIndex = 6;
            this.BtnPaste.Text = "Paste";
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(396, 230);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(75, 23);
            this.BtnTest.TabIndex = 7;
            this.BtnTest.Text = "Test";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(352, 292);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(119, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save && Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Part number";
            // 
            // TbPartnumber
            // 
            this.TbPartnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartnumber.Location = new System.Drawing.Point(177, 140);
            this.TbPartnumber.Name = "TbPartnumber";
            this.TbPartnumber.ReadOnly = true;
            this.TbPartnumber.Size = new System.Drawing.Size(195, 29);
            this.TbPartnumber.TabIndex = 9;
            // 
            // PatternFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "PatternFrm";
            this.Text = "PatternFrm";
            this.Load += new System.EventHandler(this.PatternFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Tblen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbPNqty;
        private System.Windows.Forms.TextBox TbPNstart;
        private System.Windows.Forms.TextBox TbSetTotal;
        private System.Windows.Forms.TextBox TbScan;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TbPartnumber;
        private System.Windows.Forms.Label label4;
    }
}