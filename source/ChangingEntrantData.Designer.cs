namespace EntrantSystem
{
    partial class ChangingEntrantData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangingEntrantData));
            this.textBoxEntrTelNo = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEntrEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonChangeEntrantData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEntrTelNo
            // 
            this.textBoxEntrTelNo.Location = new System.Drawing.Point(120, 12);
            this.textBoxEntrTelNo.Mask = "\\+\\7 (000) 000-0000";
            this.textBoxEntrTelNo.Name = "textBoxEntrTelNo";
            this.textBoxEntrTelNo.Size = new System.Drawing.Size(137, 20);
            this.textBoxEntrTelNo.TabIndex = 1;
            this.textBoxEntrTelNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.textBoxEntrTelNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxEntrTelNo_MouseClick);
            // 
            // textBoxEntrEmail
            // 
            this.textBoxEntrEmail.Location = new System.Drawing.Point(120, 37);
            this.textBoxEntrEmail.Name = "textBoxEntrEmail";
            this.textBoxEntrEmail.Size = new System.Drawing.Size(137, 20);
            this.textBoxEntrEmail.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Адрес эл. почты:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Номер телефона:";
            // 
            // buttonChangeEntrantData
            // 
            this.buttonChangeEntrantData.Location = new System.Drawing.Point(77, 66);
            this.buttonChangeEntrantData.Name = "buttonChangeEntrantData";
            this.buttonChangeEntrantData.Size = new System.Drawing.Size(120, 30);
            this.buttonChangeEntrantData.TabIndex = 3;
            this.buttonChangeEntrantData.Text = "Изменить";
            this.buttonChangeEntrantData.UseVisualStyleBackColor = true;
            this.buttonChangeEntrantData.Click += new System.EventHandler(this.buttonChangeEntrantData_Click);
            // 
            // ChangingEntrantData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 104);
            this.Controls.Add(this.buttonChangeEntrantData);
            this.Controls.Add(this.textBoxEntrTelNo);
            this.Controls.Add(this.textBoxEntrEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangingEntrantData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение данных";
            this.Load += new System.EventHandler(this.ChangingEntrantData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxEntrTelNo;
        private System.Windows.Forms.TextBox textBoxEntrEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonChangeEntrantData;
    }
}