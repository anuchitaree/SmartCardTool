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
            this.TbScanner = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbPartName3 = new System.Windows.Forms.TextBox();
            this.TbPartName2 = new System.Windows.Forms.TextBox();
            this.TbPartName1 = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TbScanner
            // 
            this.TbScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbScanner.Location = new System.Drawing.Point(117, 42);
            this.TbScanner.Name = "TbScanner";
            this.TbScanner.Size = new System.Drawing.Size(210, 31);
            this.TbScanner.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Call part number";
            // 
            // TbPartName3
            // 
            this.TbPartName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName3.Location = new System.Drawing.Point(148, 188);
            this.TbPartName3.MaxLength = 8;
            this.TbPartName3.Name = "TbPartName3";
            this.TbPartName3.Size = new System.Drawing.Size(130, 31);
            this.TbPartName3.TabIndex = 5;
            // 
            // TbPartName2
            // 
            this.TbPartName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName2.Location = new System.Drawing.Point(148, 151);
            this.TbPartName2.MaxLength = 8;
            this.TbPartName2.Name = "TbPartName2";
            this.TbPartName2.Size = new System.Drawing.Size(130, 31);
            this.TbPartName2.TabIndex = 6;
            // 
            // TbPartName1
            // 
            this.TbPartName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPartName1.Location = new System.Drawing.Point(148, 106);
            this.TbPartName1.MaxLength = 8;
            this.TbPartName1.Name = "TbPartName1";
            this.TbPartName1.Size = new System.Drawing.Size(130, 31);
            this.TbPartName1.TabIndex = 7;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // StartFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 511);
            this.Controls.Add(this.TbPartName3);
            this.Controls.Add(this.TbPartName2);
            this.Controls.Add(this.TbPartName1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbScanner);
            this.Name = "StartFrm";
            this.Text = "StartFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartFrm_FormClosing);
            this.Load += new System.EventHandler(this.StartFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TbScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbPartName3;
        private System.Windows.Forms.TextBox TbPartName2;
        private System.Windows.Forms.TextBox TbPartName1;
        private System.Windows.Forms.Timer timer;
    }
}