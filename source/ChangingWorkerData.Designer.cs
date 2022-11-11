namespace EntrantSystem
{
    partial class ChangingWorkerData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangingWorkerData));
            this.textBoxWorkTelNo = new System.Windows.Forms.MaskedTextBox();
            this.buttonChangeWorkerData = new System.Windows.Forms.Button();
            this.textBoxWorkPassword = new System.Windows.Forms.TextBox();
            this.textBoxWorkEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWorkTelNo
            // 
            this.textBoxWorkTelNo.Location = new System.Drawing.Point(120, 37);
            this.textBoxWorkTelNo.Mask = "\\+\\7 (000) 000-0000";
            this.textBoxWorkTelNo.Name = "textBoxWorkTelNo";
            this.textBoxWorkTelNo.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkTelNo.TabIndex = 2;
            this.textBoxWorkTelNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.textBoxWorkTelNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxWorkTelNo_MouseClick);
            // 
            // buttonChangeWorkerData
            // 
            this.buttonChangeWorkerData.Location = new System.Drawing.Point(77, 92);
            this.buttonChangeWorkerData.Name = "buttonChangeWorkerData";
            this.buttonChangeWorkerData.Size = new System.Drawing.Size(120, 30);
            this.buttonChangeWorkerData.TabIndex = 4;
            this.buttonChangeWorkerData.Text = "Изменить";
            this.buttonChangeWorkerData.UseVisualStyleBackColor = true;
            this.buttonChangeWorkerData.Click += new System.EventHandler(this.buttonChangeWorkerData_Click);
            // 
            // textBoxWorkPassword
            // 
            this.textBoxWorkPassword.Location = new System.Drawing.Point(120, 12);
            this.textBoxWorkPassword.Name = "textBoxWorkPassword";
            this.textBoxWorkPassword.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkPassword.TabIndex = 1;
            // 
            // textBoxWorkEmail
            // 
            this.textBoxWorkEmail.Location = new System.Drawing.Point(120, 62);
            this.textBoxWorkEmail.Name = "textBoxWorkEmail";
            this.textBoxWorkEmail.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkEmail.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Адрес эл. почты:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Номер телефона:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Пароль:";
            // 
            // ChangingWorkerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 133);
            this.Controls.Add(this.textBoxWorkTelNo);
            this.Controls.Add(this.buttonChangeWorkerData);
            this.Controls.Add(this.textBoxWorkPassword);
            this.Controls.Add(this.textBoxWorkEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangingWorkerData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение данных";
            this.Load += new System.EventHandler(this.ChangingWorkerData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxWorkTelNo;
        private System.Windows.Forms.Button buttonChangeWorkerData;
        private System.Windows.Forms.TextBox textBoxWorkPassword;
        private System.Windows.Forms.TextBox textBoxWorkEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}