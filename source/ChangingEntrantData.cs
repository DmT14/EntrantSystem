using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма изменения данных абитуриента из личного кабинета
    public partial class ChangingEntrantData : Form
    {
        private string id = "";         // идентификатор
        private string telNo = "";      // номер телефона
        private string email = "";      // адрес эп. почты
        private MainForm mainForm;      // экземпляр главной формы приложения
        private int user_type_acting;   // тип авторизованного пользователя

        // конструктор класса
        public ChangingEntrantData(MainForm mainForm, int user_type_acting, string id, string telNo, string email)
        {
            InitializeComponent();

            this.id = id;
            this.telNo = telNo;
            this.email = email;
            this.mainForm = mainForm;
            this.user_type_acting = user_type_acting;
        }

        // событие: нажатие на кнопку "Изменить данные" в личном кабинете абитуриента
        private void buttonChangeEntrantData_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE entrant SET phone_number = @phone_number, email = @email WHERE entrant_id = @id", db.getConnection());

                if (textBoxEntrTelNo.Text != "" && textBoxEntrEmail.Text != "")     // проверка заполненности полей для ввода данных
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = textBoxEntrTelNo.Text;
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEntrEmail.Text;
                }
                else
                {
                    MessageBox.Show("Не все данные введены!");
                    return;
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    mainForm.toFillTables(user_type_acting);
                    mainForm.toFillCabinetEntrant();
                    MessageBox.Show("Запись изменена.");
                    textBoxEntrTelNo.Text = "";
                    textBoxEntrEmail.Text = "";
                    Close();    // закрыть текущую форму
                }
                else
                    MessageBox.Show("Запись не изменена, проверьте заполнение всех полей.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Проверьте корректность введённых данных.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // событие: загрузка формы для изменения данных абитуриента из личного кабинета
        private void ChangingEntrantData_Load(object sender, EventArgs e)
        {
            textBoxEntrTelNo.Text = telNo;      // вписать в поле номер телефона пользователя
            textBoxEntrEmail.Text = email;      //          ---   адрес эл. почты     ---
        }

        // событие: однократное нажатие мышью на поле для ввода номера телефона (+7 (___) ___-____) (MaskedTextBox)
        private void textBoxEntrTelNo_MouseClick(object sender, MouseEventArgs e)
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