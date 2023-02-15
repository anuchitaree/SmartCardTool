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
            this.label7 = new System.Windows.Forms.Label();
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
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
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
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 367);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Text....";
            // 
            // TbTrial
            // 
            this.TbTrial.Location = new System.Drawing.Point(5, 218);
            this.TbTrial.Multiline = true;
            this.TbTrial.Name = "TbTrial";
            this.TbTrial.Size = new System.Drawing.Size(348, 123);
            this.TbTrial.TabIndex = 4;
            // 
            // BtnReload
            // 
            this.BtnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReload.Location = new System.Drawing.Point(234, 140);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(102, 41);
            this.BtnReload.TabIndex = 3;
            this.BtnReload.Text = "Reload";
            this.BtnReload.UseVisualStyleBackColor = true;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(234, 36);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Communication port setting for Scanner";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stop bit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Data length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Boad rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(244, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "You can test scanner after hit the \"Reload button\"";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}