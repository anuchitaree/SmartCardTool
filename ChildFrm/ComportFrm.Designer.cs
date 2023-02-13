namespace SmartCardTool.ChildFrm
{
    partial class ComportFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TbTrial = new System.Windows.Forms.TextBox();
            this.BtnReload = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CmbStopBit = new System.Windows.Forms.ComboBox();
            this.CmbDatalength = new System.Windows.Forms.ComboBox();
            this.CmbParity = new System.Windows.Forms.ComboBox();
            this.CmbBaudRate = new System.Windows.Forms.ComboBox();
            this.CmbCom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbTrial);
            this.panel1.Controls.Add(this.BtnReload);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.CmbStopBit);
            this.panel1.Controls.Add(this.CmbDatalength);
            this.panel1.Controls.Add(this.CmbParity);
            this.panel1.Controls.Add(this.CmbBaudRate);
            this.panel1.Controls.Add(this.CmbCom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(81, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 345);
            this.panel1.TabIndex = 0;
            // 
            // TbTrial
            // 
            this.TbTrial.Location = new System.Drawing.Point(17, 277);
            this.TbTrial.Multiline = true;
            this.TbTrial.Name = "TbTrial";
            this.TbTrial.Size = new System.Drawing.Size(406, 49);
            this.TbTrial.TabIndex = 4;
            // 
            // BtnReload
            // 
            this.BtnReload.Location = new System.Drawing.Point(120, 208);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(102, 41);
            this.BtnReload.TabIndex = 3;
            this.BtnReload.Text = "Reload";
            this.BtnReload.UseVisualStyleBackColor = true;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(244, 208);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(102, 41);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CmbStopBit
            // 
            this.CmbStopBit.FormattingEnabled = true;
            this.CmbStopBit.Location = new System.Drawing.Point(91, 160);
            this.CmbStopBit.Name = "CmbStopBit";
            this.CmbStopBit.Size = new System.Drawing.Size(121, 21);
            this.CmbStopBit.TabIndex = 1;
            // 
            // CmbDatalength
            // 
            this.CmbDatalength.FormattingEnabled = true;
            this.CmbDatalength.Location = new System.Drawing.Point(91, 129);
            this.CmbDatalength.Name = "CmbDatalength";
            this.CmbDatalength.Size = new System.Drawing.Size(121, 21);
            this.CmbDatalength.TabIndex = 1;
            // 
            // CmbParity
            // 
            this.CmbParity.FormattingEnabled = true;
            this.CmbParity.Location = new System.Drawing.Point(91, 98);
            this.CmbParity.Name = "CmbParity";
            this.CmbParity.Size = new System.Drawing.Size(121, 21);
            this.CmbParity.TabIndex = 1;
            // 
            // CmbBaudRate
            // 
            this.CmbBaudRate.FormattingEnabled = true;
            this.CmbBaudRate.Location = new System.Drawing.Point(91, 67);
            this.CmbBaudRate.Name = "CmbBaudRate";
            this.CmbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.CmbBaudRate.TabIndex = 1;
            // 
            // CmbCom
            // 
            this.CmbCom.FormattingEnabled = true;
            this.CmbCom.Location = new System.Drawing.Point(91, 36);
            this.CmbCom.Name = "CmbCom";
            this.CmbCom.Size = new System.Drawing.Size(121, 21);
            this.CmbCom.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Communication port setting for Scanner";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stop bit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Boad rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ComportFrm";
            this.Text = "Comport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComportFrm_FormClosing);
            this.Load += new System.EventHandler(this.ComportFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CmbStopBit;
        private System.Windows.Forms.ComboBox CmbDatalength;
        private System.Windows.Forms.ComboBox CmbParity;
        private System.Windows.Forms.ComboBox CmbBaudRate;
        private System.Windows.Forms.ComboBox CmbCom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbTrial;
        private System.Windows.Forms.Button BtnReload;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Timer timer1;
    }
}