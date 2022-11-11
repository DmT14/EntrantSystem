namespace EntrantSystem
{
    partial class AuthForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.authButton = new System.Windows.Forms.Button();
            this.radioButtonEntrant = new System.Windows.Forms.RadioButton();
            this.radioButtonOper = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(70, 19);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(161, 20);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(70, 45);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(161, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль:";
            // 
            // authButton
            // 
            this.authButton.Location = new System.Drawing.Point(70, 149);
            this.authButton.Name = "authButton";
            this.authButton.Size = new System.Drawing.Size(116, 30);
            this.authButton.TabIndex = 8;
            this.authButton.Text = "Войти";
            this.authButton.UseVisualStyleBackColor = true;
            this.authButton.Click += new System.EventHandler(this.authButton_Click);
            // 
            // radioButtonEntrant
            // 
            this.radioButtonEntrant.AutoSize = true;
            this.radioButtonEntrant.Checked = true;
            this.radioButtonEntrant.Location = new System.Drawing.Point(70, 71);
            this.radioButtonEntrant.Name = "radioButtonEntrant";
            this.radioButtonEntrant.Size = new System.Drawing.Size(83, 17);
            this.radioButtonEntrant.TabIndex = 5;
            this.radioButtonEntrant.TabStop = true;
            this.radioButtonEntrant.Text = "Абитуриент";
            this.radioButtonEntrant.UseVisualStyleBackColor = true;
            // 
            // radioButtonOper
            // 
            this.radioButtonOper.AutoSize = true;
            this.radioButtonOper.Location = new System.Drawing.Point(70, 94);
            this.radioButtonOper.Name = "radioButtonOper";
            this.radioButtonOper.Size = new System.Drawing.Size(74, 17);
            this.radioButtonOper.TabIndex = 6;
            this.radioButtonOper.Text = "Оператор";
            this.radioButtonOper.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(70, 117);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(104, 17);
            this.radioButtonAdmin.TabIndex = 7;
            this.radioButtonAdmin.Text = "Администратор";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 193);
            this.Controls.Add(this.radioButtonAdmin);
            this.Controls.Add(this.radioButtonOper);
            this.Controls.Add(this.radioButtonEntrant);
            this.Controls.Add(this.authButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button authButton;
        private System.Windows.Forms.RadioButton radioButtonEntrant;
        private System.Windows.Forms.RadioButton radioButtonOper;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
    }
}

