namespace SmartCardTool.ChildFrm
{
    partial class StartFrm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TbPartName3 = new System.Windows.Forms.TextBox();
            this.TbPartName2 = new System.Windows.Forms.TextBox();
            this.TbPartName1 = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.LbStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TbPartName0 = new System.Windows.Forms.TextBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.CmbScanner = new System.Windows.Forms.ComboBox();
            this.CkbAuto = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TbPartName3
            // 
            this.TbPartName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName3.Location = new System.Drawing.Point(212, 133);
            this.TbPartName3.MaxLength = 8;
            this.TbPartName3.Name = "TbPartName3";
            this.TbPartName3.Size = new System.Drawing.Size(141, 31);
            this.TbPartName3.TabIndex = 5;
            // 
            // TbPartName2
            // 
            this.TbPartName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName2.Location = new System.Drawing.Point(212, 95);
            this.TbPartName2.MaxLength = 8;
            this.TbPartName2.Name = "TbPartName2";
            this.TbPartName2.Size = new System.Drawing.Size(141, 31);
            this.TbPartName2.TabIndex = 6;
            // 
            // TbPartName1
            // 
            this.TbPartName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName1.Location = new System.Drawing.Point(212, 58);
            this.TbPartName1.MaxLength = 8;
            this.TbPartName1.Name = "TbPartName1";
            this.TbPartName1.Size = new System.Drawing.Size(141, 31);
            this.TbPartName1.TabIndex = 7;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LbStatus
            // 
            this.LbStatus.AutoSize = true;
            this.LbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbStatus.Location = new System.Drawing.Point(3, 291);
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(564, 30);
            this.LbStatus.TabIndex = 8;
            this.LbStatus.Text = "status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnWrite);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.BtnSubmit);
            this.groupBox1.Controls.Add(this.CmbScanner);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 255);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Smart card 2.9inch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search number";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.TbPartName0);
            this.panel1.Controls.Add(this.TbPartName1);
            this.panel1.Controls.Add(this.TbPartName2);
            this.panel1.Controls.Add(this.TbPartName3);
            this.panel1.Location = new System.Drawing.Point(57, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 171);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(15, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 105);
            this.panel2.TabIndex = 8;
            // 
            // TbPartName0
            // 
            this.TbPartName0.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName0.Location = new System.Drawing.Point(15, 8);
            this.TbPartName0.MaxLength = 13;
            this.TbPartName0.Name = "TbPartName0";
            this.TbPartName0.Size = new System.Drawing.Size(338, 44);
            this.TbPartName0.TabIndex = 7;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.Location = new System.Drawing.Point(439, 25);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(119, 40);
            this.BtnSubmit.TabIndex = 9;
            this.BtnSubmit.Text = "Search && Write";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // CmbScanner
            // 
            this.CmbScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbScanner.FormattingEnabled = true;
            this.CmbScanner.Location = new System.Drawing.Point(57, 25);
            this.CmbScanner.Name = "CmbScanner";
            this.CmbScanner.Size = new System.Drawing.Size(364, 39);
            this.CmbScanner.TabIndex = 8;
            this.CmbScanner.SelectedIndexChanged += new System.EventHandler(this.CmbScanner_SelectedIndexChanged);
            this.CmbScanner.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbScanner_KeyPress);
            // 
            // CkbAuto
            // 
            this.CkbAuto.AutoSize = true;
            this.CkbAuto.Checked = true;
            this.CkbAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkbAuto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CkbAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkbAuto.Location = new System.Drawing.Point(3, 3);
            this.CkbAuto.Name = "CkbAuto";
            this.CkbAuto.Size = new System.Drawing.Size(564, 24);
            this.CkbAuto.TabIndex = 10;
            this.CkbAuto.Text = "Automatic scanner";
            this.CkbAuto.UseVisualStyleBackColor = true;
            this.CkbAuto.CheckedChanged += new System.EventHandler(this.CkbAuto_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LbStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CkbAuto, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 321);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // BtnWrite
            // 
            this.BtnWrite.Location = new System.Drawing.Point(439, 202);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(119, 40);
            this.BtnWrite.TabIndex = 12;
            this.BtnWrite.Text = "Write";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // StartFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StartFrm";
            this.Text = "StartFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartFrm_FormClosing);
            this.Load += new System.EventHandler(this.StartFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TbPartName3;
        private System.Windows.Forms.TextBox TbPartName2;
        private System.Windows.Forms.TextBox TbPartName1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label LbStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.ComboBox CmbScanner;
        private System.Windows.Forms.CheckBox CkbAuto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TbPartName0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnWrite;
    }
}