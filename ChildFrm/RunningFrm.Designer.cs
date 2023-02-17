namespace SmartCardTool.ChildFrm
{
    partial class RunningFrm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbError = new System.Windows.Forms.Label();
            this.LbCompleted = new System.Windows.Forms.Label();
            this.LbSendToStock = new System.Windows.Forms.Label();
            this.LbWriteTag = new System.Windows.Forms.Label();
            this.LbFindDB = new System.Windows.Forms.Label();
            this.LbReceived = new System.Windows.Forms.Label();
            this.LbReady = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbPartName3 = new System.Windows.Forms.TextBox();
            this.TbPartName2 = new System.Windows.Forms.TextBox();
            this.TbPartName1 = new System.Windows.Forms.TextBox();
            this.CmbScanner = new System.Windows.Forms.TextBox();
            this.TbPartName0 = new System.Windows.Forms.TextBox();
            this.LbStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LbOK = new System.Windows.Forms.Label();
            this.LbNG = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnReloadApp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LbStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 948);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LbError);
            this.panel1.Controls.Add(this.LbCompleted);
            this.panel1.Controls.Add(this.LbSendToStock);
            this.panel1.Controls.Add(this.LbWriteTag);
            this.panel1.Controls.Add(this.LbFindDB);
            this.panel1.Controls.Add(this.LbReceived);
            this.panel1.Controls.Add(this.LbReady);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TbPartName3);
            this.panel1.Controls.Add(this.TbPartName2);
            this.panel1.Controls.Add(this.TbPartName1);
            this.panel1.Controls.Add(this.CmbScanner);
            this.panel1.Controls.Add(this.TbPartName0);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 94);
            this.panel1.TabIndex = 0;
            // 
            // LbError
            // 
            this.LbError.BackColor = System.Drawing.Color.White;
            this.LbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbError.Location = new System.Drawing.Point(780, 54);
            this.LbError.Name = "LbError";
            this.LbError.Size = new System.Drawing.Size(91, 32);
            this.LbError.TabIndex = 15;
            this.LbError.Text = "Error";
            this.LbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbCompleted
            // 
            this.LbCompleted.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbCompleted.Location = new System.Drawing.Point(544, 55);
            this.LbCompleted.Name = "LbCompleted";
            this.LbCompleted.Size = new System.Drawing.Size(91, 32);
            this.LbCompleted.TabIndex = 15;
            this.LbCompleted.Text = "Completed";
            this.LbCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbSendToStock
            // 
            this.LbSendToStock.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbSendToStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbSendToStock.Location = new System.Drawing.Point(453, 55);
            this.LbSendToStock.Name = "LbSendToStock";
            this.LbSendToStock.Size = new System.Drawing.Size(91, 32);
            this.LbSendToStock.TabIndex = 15;
            this.LbSendToStock.Text = "Send to St mon.";
            this.LbSendToStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbWriteTag
            // 
            this.LbWriteTag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbWriteTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbWriteTag.Location = new System.Drawing.Point(362, 55);
            this.LbWriteTag.Name = "LbWriteTag";
            this.LbWriteTag.Size = new System.Drawing.Size(91, 32);
            this.LbWriteTag.TabIndex = 15;
            this.LbWriteTag.Text = "Write TAG";
            this.LbWriteTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbFindDB
            // 
            this.LbFindDB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbFindDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbFindDB.Location = new System.Drawing.Point(271, 55);
            this.LbFindDB.Name = "LbFindDB";
            this.LbFindDB.Size = new System.Drawing.Size(91, 32);
            this.LbFindDB.TabIndex = 15;
            this.LbFindDB.Text = "Find DB";
            this.LbFindDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbReceived
            // 
            this.LbReceived.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbReceived.Location = new System.Drawing.Point(180, 55);
            this.LbReceived.Name = "LbReceived";
            this.LbReceived.Size = new System.Drawing.Size(91, 32);
            this.LbReceived.TabIndex = 15;
            this.LbReceived.Text = "Received";
            this.LbReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbReady
            // 
            this.LbReady.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LbReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbReady.Location = new System.Drawing.Point(89, 55);
            this.LbReady.Name = "LbReady";
            this.LbReady.Size = new System.Drawing.Size(91, 32);
            this.LbReady.TabIndex = 15;
            this.LbReady.Text = "Ready";
            this.LbReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Machine state";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(732, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Part name (at row3)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Part name (at row2)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Part name (at row1)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Part number (at header)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From Production system";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TbPartName3
            // 
            this.TbPartName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName3.Location = new System.Drawing.Point(732, 17);
            this.TbPartName3.MaxLength = 8;
            this.TbPartName3.Name = "TbPartName3";
            this.TbPartName3.ReadOnly = true;
            this.TbPartName3.Size = new System.Drawing.Size(141, 29);
            this.TbPartName3.TabIndex = 5;
            // 
            // TbPartName2
            // 
            this.TbPartName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName2.Location = new System.Drawing.Point(591, 17);
            this.TbPartName2.MaxLength = 8;
            this.TbPartName2.Name = "TbPartName2";
            this.TbPartName2.ReadOnly = true;
            this.TbPartName2.Size = new System.Drawing.Size(141, 29);
            this.TbPartName2.TabIndex = 6;
            // 
            // TbPartName1
            // 
            this.TbPartName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName1.Location = new System.Drawing.Point(447, 17);
            this.TbPartName1.MaxLength = 8;
            this.TbPartName1.Name = "TbPartName1";
            this.TbPartName1.ReadOnly = true;
            this.TbPartName1.Size = new System.Drawing.Size(141, 29);
            this.TbPartName1.TabIndex = 7;
            // 
            // CmbScanner
            // 
            this.CmbScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbScanner.Location = new System.Drawing.Point(7, 15);
            this.CmbScanner.MaxLength = 13;
            this.CmbScanner.Name = "CmbScanner";
            this.CmbScanner.ReadOnly = true;
            this.CmbScanner.Size = new System.Drawing.Size(215, 31);
            this.CmbScanner.TabIndex = 7;
            // 
            // TbPartName0
            // 
            this.TbPartName0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName0.Location = new System.Drawing.Point(228, 16);
            this.TbPartName0.MaxLength = 13;
            this.TbPartName0.Name = "TbPartName0";
            this.TbPartName0.ReadOnly = true;
            this.TbPartName0.Size = new System.Drawing.Size(215, 31);
            this.TbPartName0.TabIndex = 7;
            // 
            // LbStatus
            // 
            this.LbStatus.AutoSize = true;
            this.LbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbStatus.Location = new System.Drawing.Point(3, 932);
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(878, 16);
            this.LbStatus.TabIndex = 13;
            this.LbStatus.Text = "label6";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 721);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.LbOK, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.LbNG, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 721);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // LbOK
            // 
            this.LbOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LbOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOK.Location = new System.Drawing.Point(3, 0);
            this.LbOK.Name = "LbOK";
            this.LbOK.Size = new System.Drawing.Size(433, 721);
            this.LbOK.TabIndex = 1;
            this.LbOK.Text = "OK";
            this.LbOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbNG
            // 
            this.LbNG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LbNG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbNG.Location = new System.Drawing.Point(442, 0);
            this.LbNG.Name = "LbNG";
            this.LbNG.Size = new System.Drawing.Size(433, 721);
            this.LbNG.TabIndex = 1;
            this.LbNG.Text = "NG";
            this.LbNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.BtnStart, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnReloadApp, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 830);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(878, 81);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // BtnStart
            // 
            this.BtnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(581, 3);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(294, 75);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnReloadApp
            // 
            this.BtnReloadApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnReloadApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReloadApp.Location = new System.Drawing.Point(292, 3);
            this.BtnReloadApp.Name = "BtnReloadApp";
            this.BtnReloadApp.Size = new System.Drawing.Size(283, 75);
            this.BtnReloadApp.TabIndex = 1;
            this.BtnReloadApp.Text = "Reload App";
            this.BtnReloadApp.UseVisualStyleBackColor = true;
            this.BtnReloadApp.Click += new System.EventHandler(this.BtnReloadApp_Click);
            // 
            // RunningFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 948);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RunningFrm";
            this.Text = "RunningFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RunningFrm_FormClosing);
            this.Load += new System.EventHandler(this.RunningFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TbPartName3;
        private System.Windows.Forms.TextBox TbPartName2;
        private System.Windows.Forms.TextBox TbPartName1;
        private System.Windows.Forms.TextBox TbPartName0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CmbScanner;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label LbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LbNG;
        private System.Windows.Forms.Label LbOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label LbError;
        private System.Windows.Forms.Label LbCompleted;
        private System.Windows.Forms.Label LbSendToStock;
        private System.Windows.Forms.Label LbWriteTag;
        private System.Windows.Forms.Label LbFindDB;
        private System.Windows.Forms.Label LbReceived;
        private System.Windows.Forms.Label LbReady;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnReloadApp;
    }
}