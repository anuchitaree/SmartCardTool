namespace SmartCardTool
{
    partial class AuxFrm
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
            this.Button_ReadFromUserArea = new System.Windows.Forms.Button();
            this.Button_WriteToUserArea = new System.Windows.Forms.Button();
            this.Button_ClearDisplay = new System.Windows.Forms.Button();
            this.Button_ShowImage = new System.Windows.Forms.Button();
            this.Label_IDm = new System.Windows.Forms.Label();
            this.Label_Message = new System.Windows.Forms.Label();
            this.TextBox_Log = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Label_Version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_ReadFromUserArea
            // 
            this.Button_ReadFromUserArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ReadFromUserArea.Location = new System.Drawing.Point(620, 72);
            this.Button_ReadFromUserArea.Name = "Button_ReadFromUserArea";
            this.Button_ReadFromUserArea.Size = new System.Drawing.Size(163, 56);
            this.Button_ReadFromUserArea.TabIndex = 14;
            this.Button_ReadFromUserArea.Text = "Read From User Area";
            this.Button_ReadFromUserArea.UseVisualStyleBackColor = true;
            this.Button_ReadFromUserArea.Click += new System.EventHandler(this.Button_ReadFromUserArea_Click);
            // 
            // Button_WriteToUserArea
            // 
            this.Button_WriteToUserArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_WriteToUserArea.Location = new System.Drawing.Point(438, 71);
            this.Button_WriteToUserArea.Name = "Button_WriteToUserArea";
            this.Button_WriteToUserArea.Size = new System.Drawing.Size(163, 56);
            this.Button_WriteToUserArea.TabIndex = 13;
            this.Button_WriteToUserArea.Text = "Write To User Area";
            this.Button_WriteToUserArea.UseVisualStyleBackColor = true;
            this.Button_WriteToUserArea.Click += new System.EventHandler(this.Button_WriteToUserArea_Click);
            // 
            // Button_ClearDisplay
            // 
            this.Button_ClearDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ClearDisplay.Location = new System.Drawing.Point(256, 72);
            this.Button_ClearDisplay.Name = "Button_ClearDisplay";
            this.Button_ClearDisplay.Size = new System.Drawing.Size(163, 56);
            this.Button_ClearDisplay.TabIndex = 12;
            this.Button_ClearDisplay.Text = "Clear Display";
            this.Button_ClearDisplay.UseVisualStyleBackColor = true;
            this.Button_ClearDisplay.Click += new System.EventHandler(this.Button_ClearDisplay_Click);
            // 
            // Button_ShowImage
            // 
            this.Button_ShowImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ShowImage.Location = new System.Drawing.Point(74, 72);
            this.Button_ShowImage.Name = "Button_ShowImage";
            this.Button_ShowImage.Size = new System.Drawing.Size(163, 56);
            this.Button_ShowImage.TabIndex = 11;
            this.Button_ShowImage.Text = "Show Image";
            this.Button_ShowImage.UseVisualStyleBackColor = true;
            this.Button_ShowImage.Click += new System.EventHandler(this.Button_ShowImage_Click);
            // 
            // Label_IDm
            // 
            this.Label_IDm.AutoSize = true;
            this.Label_IDm.Location = new System.Drawing.Point(39, 142);
            this.Label_IDm.Name = "Label_IDm";
            this.Label_IDm.Size = new System.Drawing.Size(35, 13);
            this.Label_IDm.TabIndex = 10;
            this.Label_IDm.Text = "IDm : ";
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Message.Location = new System.Drawing.Point(16, 15);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(182, 25);
            this.Label_Message.TabIndex = 9;
            this.Label_Message.Text = "No Reader Found";
            // 
            // TextBox_Log
            // 
            this.TextBox_Log.Location = new System.Drawing.Point(42, 171);
            this.TextBox_Log.Multiline = true;
            this.TextBox_Log.Name = "TextBox_Log";
            this.TextBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Log.Size = new System.Drawing.Size(743, 265);
            this.TextBox_Log.TabIndex = 8;
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Label_Version
            // 
            this.Label_Version.AutoSize = true;
            this.Label_Version.Location = new System.Drawing.Point(565, 35);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(74, 13);
            this.Label_Version.TabIndex = 15;
            this.Label_Version.Text = "Label_Version";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_ReadFromUserArea);
            this.Controls.Add(this.Button_WriteToUserArea);
            this.Controls.Add(this.Button_ClearDisplay);
            this.Controls.Add(this.Button_ShowImage);
            this.Controls.Add(this.Label_IDm);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.TextBox_Log);
            this.Controls.Add(this.Label_Version);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_ReadFromUserArea;
        private System.Windows.Forms.Button Button_WriteToUserArea;
        private System.Windows.Forms.Button Button_ClearDisplay;
        private System.Windows.Forms.Button Button_ShowImage;
        private System.Windows.Forms.Label Label_IDm;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.TextBox TextBox_Log;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label Label_Version;
    }
}

