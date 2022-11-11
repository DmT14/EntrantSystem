using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма изменения данных сотрудника из общего реестра
    public partial class ChangingWorker : Form
    {
        private string id = "";             // идентификатор
        private string password = "";       // пароль
        private string user_type = "";      // тип пользователя
        private string surname = "";        // фамилия
        private string name = "";           // имя
        private string last_name = "";      // отчество
        private string hiring_date = "";    // дата найма
        private string telNo = "";          // номер телефона
        private string email = "";          // адрес эл. почты
        private MainForm mainForm;          // экземпляр главной формы приложения
        private int user_type_acting;       // тип авторизованного пользователя

        // конструктор класса
        public ChangingWorker(MainForm mainForm, int user_type_acting, string id, string password, string user_type, string surname, string name, string last_name, string hiring_date, string telNo, string email)
        {
            InitializeComponent();

            this.id = id;
            this.password = password;
            this.user_type = user_type;
            this.surname = surname;
            this.name = name;
            this.last_name = last_name;
            this.hiring_date = hiring_date;
            this.telNo = telNo;
            this.email = email;
            this.mainForm = mainForm;
            this.user_type_acting = user_type_acting;
        }

        // событие: нажатие на кнопку "Изменить" в форме изменения данных сотрудника (вызов формы из вкладки общего списка сотрудников)
        private void buttonChangeWorker_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE worker SET password = @pass, user_type = @user_type, surname = @surname, name = @name, last_name = @last_name, hiring_date = @hiring_date, phone_number = @phone_number, email = @email WHERE worker_id = @id", db.getConnection());

                if (textBoxWorkPassword.Text != "" && textBoxWorkUserType.Text != "" && textBoxWorkSurname.Text != "" && textBoxWorkName.Text != "" && textBoxWorkHiringDate.Text != "" && textBoxWorkTelNo.Text != "" && textBoxWorkEmail.Text != "")  // проверка непустоты полей для ввода данных
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxWorkPassword.Text;
                    command.Parameters.Add("@user_type", MySqlDbType.VarChar).Value = textBoxWorkUserType.Text;
                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxWorkSurname.Text;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxWorkName.Text;
                    command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = textBoxWorkLastName.Text;
                    command.Parameters.Add("@hiring_date", MySqlDbType.DateTime).Value = textBoxWorkHiringDate.Value.Date.ToString("yyyy-MM-dd");
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
                    mainForm.toFillTables(user_type_acting);
                    MessageBox.Show("Запись изменена.");
                    textBoxWorkPassword.Text = "";
                    textBoxWorkUserType.Text = "";
                    textBoxWorkSurname.Text = "";
                    textBoxWorkName.Text = "";
                    textBoxWorkLastName.Text = "";
                    textBoxWorkHiringDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    textBoxWorkTelNo.Text = "";
                    textBoxWorkEmail.Text = "";
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

        // событие: загрузка формы для изменения данных сотрудника из общего списка
        private void ChangingWorker_Load(object sender, EventArgs e)
        {
            textBoxWorkPassword.Text = password;                                    // вписать в поле пароль выбранного сотрудника
            textBoxWorkUserType.Text = user_type;                                   //        --- тип пользователя ---
            textBoxWorkSurname.Text = surname;                                      //        ---      фамилию     ---
            textBoxWorkName.Text = name;                                            //        ---        имя       ---
            textBoxWorkLastName.Text = last_name;                                   //        ---     отчество     ---
            textBoxWorkHiringDate.Value = Convert.ToDateTime(hiring_date, null);    // вписать в поле дату найма выбранного сотрудника, конвертированную в корректный формат
            textBoxWorkTelNo.Text = telNo;                                          //        ---  номер телефона  ---
            textBoxWorkEmail.Text = email;                                          //        ---  адрес эл. почты ---
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