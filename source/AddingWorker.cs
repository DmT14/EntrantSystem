using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма добавления сотрудника в базу данных
    public partial class AddingWorker : Form
    {
        private MainForm mainForm;      // экземпляр главной формы приложения
        private int userType;           // тип авторизованного пользователя

        // конструктор класса
        public AddingWorker(MainForm mainForm, int userType)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.userType = userType;
        }

        // событие: нажатие на кнопку "Добавить" в форме добавления сотрудника
        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("INSERT INTO worker(password, user_type, surname, name, last_name, hiring_date, phone_number, email) VALUES(@pass, @user_type, @surname, @name, @last_name, @hiring_date, @phone_number, @email)", db.getConnection());
                
                if(textBoxWorkPassword.Text != "" && textBoxWorkUserType.Text != "" && textBoxWorkSurname.Text != "" && textBoxWorkName.Text != "" && textBoxWorkHiringDate.Text != "" && textBoxWorkTelNo.Text != "" && textBoxWorkEmail.Text != "")       // проверка непустоты полей
                {
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxWorkPassword.Text;
                    command.Parameters.Add("@user_type", MySqlDbType.VarChar).Value = textBoxWorkUserType.Text;
                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxWorkSurname.Text;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxWorkName.Text;
                    command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = textBoxWorkLastName.Text;
                    command.Parameters.Add("@hiring_date", MySqlDbType.VarChar).Value = textBoxWorkHiringDate.Value.Date.ToString("yyyy-MM-dd");
                    command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = textBoxWorkTelNo.Text;
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxWorkEmail.Text;
                }
                else
                {
                    MessageBox.Show("Не все данные введены!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    textBoxWorkPassword.Text = "";
                    textBoxWorkUserType.Text = "";
                    textBoxWorkSurname.Text = "";
                    textBoxWorkName.Text = "";
                    textBoxWorkLastName.Text = "";
                    textBoxWorkHiringDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    textBoxWorkTelNo.Text = "";
                    textBoxWorkEmail.Text = "";
                    
                    mainForm.toFillTables(userType);
                    MessageBox.Show("Запись добавлена.");
                }
                else
                    MessageBox.Show("Запись не добавлена, проверьте заполнение всех полей.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // событие: однократное нажатие мышью на поле для ввода номера телефона (+7 (___) ___-____) (MaskedTextBox)
        private void textBoxWorkTelNo_MouseClick(object sender, MouseEventArgs e)
        {
            // перевод каретки на первую свободную позицию при наступлении данного события
            try
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
                string telNo = maskedTextBox.Text;
                int index = 4;

                if (telNo[telNo.Length - 1] != '_')
                    return;

                else
                {
                    for (int i = 4; i < telNo.Length; i++)
                    {
                        if (i == telNo.Length - 1)
                        {
                            if (telNo[i] == '_' && telNo[i - 1] != '_')
                            {
                                index = i;
                                break;
                            }
                        }
                        if (telNo[i - 1] == '(' && telNo[i] == '_' && telNo[i + 1] == '_' || char.IsDigit(telNo[i - 1]) && telNo[i] == '_' && telNo[i + 1] == '_' || char.IsDigit(telNo[i - 1]) && telNo[i] == '_' && telNo[i + 1] == ')' || telNo[i - 1] == ' ' && telNo[i] == '_' && telNo[i + 1] == '_' || char.IsDigit(telNo[i - 1]) && telNo[i] == '_' && telNo[i + 1] == '-' || telNo[i - 1] == '-' && telNo[i] == '_' && telNo[i + 1] == '_')
                        {
                            index = i;
                            break;
                        }
                    }
                }

                ((MaskedTextBox)sender).SelectionStart = index;
                ((MaskedTextBox)sender).Select();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}