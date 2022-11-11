namespace EntrantSystem
{
    partial class ChangingWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangingWorker));
            this.textBoxWorkTelNo = new System.Windows.Forms.MaskedTextBox();
            this.textBoxWorkHiringDate = new System.Windows.Forms.DateTimePicker();
            this.buttonChangeWorker = new System.Windows.Forms.Button();
            this.textBoxWorkPassword = new System.Windows.Forms.TextBox();
            this.textBoxWorkUserType = new System.Windows.Forms.TextBox();
            this.textBoxWorkSurname = new System.Windows.Forms.TextBox();
            this.textBoxWorkName = new System.Windows.Forms.TextBox();
            this.textBoxWorkLastName = new System.Windows.Forms.TextBox();
            this.textBoxWorkEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWorkTelNo
            // 
            this.textBoxWorkTelNo.Location = new System.Drawing.Point(149, 162);
            this.textBoxWorkTelNo.Mask = "\\+\\7 (000) 000-0000";
            this.textBoxWorkTelNo.Name = "textBoxWorkTelNo";
            this.textBoxWorkTelNo.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkTelNo.TabIndex = 7;
            this.textBoxWorkTelNo.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.textBoxWorkTelNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxWorkTelNo_MouseClick);
            // 
            // textBoxWorkHiringDate
            // 
            this.textBoxWorkHiringDate.Location = new System.Drawing.Point(149, 137);
            this.textBoxWorkHiringDate.Name = "textBoxWorkHiringDate";
            this.textBoxWorkHiringDate.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkHiringDate.TabIndex = 6;
            // 
            // buttonChangeWorker
            // 
            this.buttonChangeWorker.Location = new System.Drawing.Point(94, 216);
            this.buttonChangeWorker.Name = "buttonChangeWorker";
            this.buttonChangeWorker.Size = new System.Drawing.Size(120, 30);
            this.buttonChangeWorker.TabIndex = 9;
            this.buttonChangeWorker.Text = "Изменить";
            this.buttonChangeWorker.UseVisualStyleBackColor = true;
            this.buttonChangeWorker.Click += new System.EventHandler(this.buttonChangeWorker_Click);
            // 
            // textBoxWorkPassword
            // 
            this.textBoxWorkPassword.Location = new System.Drawing.Point(149, 12);
            this.textBoxWorkPassword.Name = "textBoxWorkPassword";
            this.textBoxWorkPassword.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkPassword.TabIndex = 1;
            // 
            // textBoxWorkUserType
            // 
            this.textBoxWorkUserType.Location = new System.Drawing.Point(149, 37);
            this.textBoxWorkUserType.Name = "textBoxWorkUserType";
            this.textBoxWorkUserType.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkUserType.TabIndex = 2;
            // 
            // textBoxWorkSurname
            // 
            this.textBoxWorkSurname.Location = new System.Drawing.Point(149, 62);
            this.textBoxWorkSurname.Name = "textBoxWorkSurname";
            this.textBoxWorkSurname.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkSurname.TabIndex = 3;
            // 
            // textBoxWorkName
            // 
            this.textBoxWorkName.Location = new System.Drawing.Point(149, 87);
            this.textBoxWorkName.Name = "textBoxWorkName";
            this.textBoxWorkName.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkName.TabIndex = 4;
            // 
            // textBoxWorkLastName
            // 
            this.textBoxWorkLastName.Location = new System.Drawing.Point(149, 112);
            this.textBoxWorkLastName.Name = "textBoxWorkLastName";
            this.textBoxWorkLastName.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkLastName.TabIndex = 5;
            // 
            // textBoxWorkEmail
            // 
            this.textBoxWorkEmail.Location = new System.Drawing.Point(149, 187);
            this.textBoxWorkEmail.Name = "textBoxWorkEmail";
            this.textBoxWorkEmail.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkEmail.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Адрес эл. почты:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Номер телефона:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Дата найма:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Отчество (при наличии):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Фамилия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Тип пользователя:";
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
            // ChangingWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 254);
            this.Controls.Add(this.textBoxWorkTelNo);
            this.Controls.Add(this.textBoxWorkHiringDate);
            this.Controls.Add(this.buttonChangeWorker);
            this.Controls.Add(this.textBoxWorkPassword);
            this.Controls.Add(this.textBoxWorkUserType);
            this.Controls.Add(this.textBoxWorkSurname);
            this.Controls.Add(this.textBoxWorkName);
            this.Controls.Add(this.textBoxWorkLastName);
            this.Controls.Add(this.textBoxWorkEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangingWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение информации";
            this.Load += new System.EventHandler(this.ChangingWorker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxWorkTelNo;
        private System.Windows.Forms.DateTimePicker textBoxWorkHiringDate;
        private System.Windows.Forms.Button buttonChangeWorker;
        private System.Windows.Forms.TextBox textBoxWorkPassword;
        private System.Windows.Forms.TextBox textBoxWorkUserType;
        private System.Windows.Forms.TextBox textBoxWorkSurname;
        private System.Windows.Forms.TextBox textBoxWorkName;
        private System.Windows.Forms.TextBox textBoxWorkLastName;
        private System.Windows.Forms.TextBox textBoxWorkEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}