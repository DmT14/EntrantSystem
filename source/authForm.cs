using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма авторизации
    public partial class AuthForm : Form
    {
        // конструктор класса
        public AuthForm()
        {
            InitializeComponent();
        }

        // событие: нажатие на кнопку "Войти" формы авторизации
        private void authButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                string login = textBoxLogin.Text;           // текст в поле ввода логина
                string password = textBoxPassword.Text;     // текст в поле ввода пароля

                int userType;                               // указание типа авторизующегося пользователя: 1 — администратор, 2 — оператор, 3 — абитуриент
                if (radioButtonEntrant.Checked == true)
                {
                    userType = 3;
                    MySqlCommand commandAuth = new MySqlCommand("SELECT document_number FROM entrant WHERE entrant_id = @login", db.getConnection());   // проверка набора "логин + пароль" в базе данных
                    commandAuth.Parameters.Add(new MySqlParameter("@login", login));
                    object value = commandAuth.ExecuteScalar();

                    if(password.Equals(value))
                    {
                        MainForm mainForm = new MainForm(userType, login, password, this);
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введённых данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    radioButtonEntrant.Checked = false;
                    userType = 0;
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                    radioButtonEntrant.Checked = true;
                    return;
                }
                else if (radioButtonOper.Checked == true)
                {
                    userType = 2;
                    MySqlCommand commandAuth = new MySqlCommand("SELECT password FROM worker WHERE worker_id = @login AND user_type = @userType", db.getConnection());  // проверка набора "логин + пароль" в базе данных
                    commandAuth.Parameters.Add(new MySqlParameter("@login", login));
                    commandAuth.Parameters.Add(new MySqlParameter("@userType", userType));
                    object value = commandAuth.ExecuteScalar();

                    if (password.Equals(value))
                    {
                        MainForm mainForm = new MainForm(userType, login, password, this);
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введённых данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    radioButtonOper.Checked = false;
                    userType = 0;
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                    radioButtonEntrant.Checked = true;
                    return;
                }
                else if(radioButtonAdmin.Checked == true)
                {
                    userType = 1;
                    MySqlCommand commandAuth = new MySqlCommand("SELECT password FROM worker WHERE worker_id = @login AND user_type = @userType", db.getConnection());  // проверка набора "логин + пароль" в базе данных
                    commandAuth.Parameters.Add(new MySqlParameter("@login", login));
                    commandAuth.Parameters.Add(new MySqlParameter("@userType", userType));
                    object value = commandAuth.ExecuteScalar();

                    if (password.Equals(value))
                    {
                        MainForm mainForm = new MainForm(userType, login, password, this);
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введённых данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    radioButtonAdmin.Checked = false;
                    userType = 0;
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                    radioButtonEntrant.Checked = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Укажите тип пользователя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Проверьте правильность введённых данных.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}