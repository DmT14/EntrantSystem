using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма изменения данных абитуриента из общего реестра
    public partial class ChangingEntrant : Form
    {
        private string id = "";                 // идентификатор
        private string surname = "";            // фамилия
        private string name = "";               // имя
        private string last_name = "";          // отчество
        private string birthday = "";           // дата рождения
        private string telNo = "";              // номер телефона
        private string email = "";              // адрес эл. почты
        private string passport = "";           // паспорт
        private string docNo = "";              // № документа об образовании
        private string docDate = "";            // дата выдачи документа об образовании
        private string code_1 = "";             // конкурс № 1
        private string code_2 = "";             // конкурс № 2
        private string code_3 = "";             // конкурс № 3
        private string oper_id = "";            // код обработавшего сотрудника
        private string filing_date = "";        // дата подачи заявления на участие в конкурсе
        private MainForm mainForm;              // экземпляр главной формы приложения
        private int user_type_acting;           // тип авторизованного пользователя
        private string login;                   // логин авторизованного пользователя (также идентификатор)

        // конструктор класса
        public ChangingEntrant(MainForm mainForm, int userType, string login, string id, string surname, string name, string last_name, string birthday, string telNo, string email, string passport, string docNo, string docDate, string code_1, string code_2, string code_3, string oper_id, string filing_date)
        {
            InitializeComponent();

            this.id = id;
            this.surname = surname;
            this.name = name;
            this.last_name = last_name;
            this.birthday = birthday;
            this.telNo = telNo;
            this.email = email;
            this.passport = passport;
            this.docNo = docNo;
            this.docDate = docDate;
            this.code_1 = code_1;
            this.code_2 = code_2;
            this.code_3 = code_3;
            this.oper_id = oper_id;
            this.filing_date = filing_date;
            this.mainForm = mainForm;
            user_type_acting = userType;
            this.login = login;
        }

        // событие: нажатие на кнопку "Изменить" форме изменения данных абитуриента (вызов формы из вкладки общего списка абитуриентов)
        private void buttonChangeEntrant_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE entrant SET surname = @surname, name = @name, last_name = @last_name, birthday = @birthday, phone_number = @phone_number, email = @email, document_number = @document_number, date_of_issue = @date_of_issue, code_1 = @code_1, code_2 = @code_2, code_3 = @code_3, oper_id = @login, filing_date = @filing_date WHERE entrant_id = @id", db.getConnection());

                if (textBoxEntrSurname.Text != "" && textBoxEntrName.Text != "" && textBoxEntrBirthday.Text != "" && textBoxEntrTelNo.Text != "" && textBoxEntrEmail.Text != "" && textBoxEntrPassport.Text != "" && textBoxEntrDocNo.Text != "" && textBoxEntrTelNo.Text != "" && textBoxEntrOperID.Text != "" && textBoxEntrFilingDate.Text != "")    // проверка заполненности полей для ввода данных
                {
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxEntrSurname.Text;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxEntrName.Text;
                    command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = textBoxEntrLastName.Text;
                    command.Parameters.Add("@birthday", MySqlDbType.Date).Value = textBoxEntrBirthday.Value.Date.ToString("yyyy-MM-dd");
                    command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = textBoxEntrTelNo.Text;
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEntrEmail.Text;
                    command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = textBoxEntrPassport.Text;
                    command.Parameters.Add("@document_number", MySqlDbType.VarChar).Value = textBoxEntrDocNo.Text;
                    command.Parameters.Add("@date_of_issue", MySqlDbType.Date).Value = textBoxEntrDateDoc.Value.Date.ToString("yyyy-MM-dd");
                    if (textBoxEntrCode1.Text == "__.__.__") command.Parameters.Add("@code_1", MySqlDbType.VarChar).Value = "—";
                    else command.Parameters.Add("@code_1", MySqlDbType.VarChar).Value = textBoxEntrCode1.Text;
                    if (textBoxEntrCode2.Text == "__.__.__") command.Parameters.Add("@code_2", MySqlDbType.VarChar).Value = "—";
                    else command.Parameters.Add("@code_2", MySqlDbType.VarChar).Value = textBoxEntrCode2.Text;
                    if (textBoxEntrCode3.Text == "__.__.__") command.Parameters.Add("@code_3", MySqlDbType.VarChar).Value = "—";
                    else command.Parameters.Add("@code_3", MySqlDbType.VarChar).Value = textBoxEntrCode3.Text;
                    command.Parameters.Add("@login", MySqlDbType.Int16).Value = textBoxEntrOperID.Text;
                    command.Parameters.Add("@filing_date", MySqlDbType.Date).Value = textBoxEntrFilingDate.Value.Date.ToString("yyyy-MM-dd");
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
                    textBoxEntrSurname.Text = "";
                    textBoxEntrName.Text = "";
                    textBoxEntrLastName.Text = "";
                    textBoxEntrBirthday.Value = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
                    textBoxEntrTelNo.Text = "";
                    textBoxEntrEmail.Text = "";
                    textBoxEntrPassport.Text = "";
                    textBoxEntrDocNo.Text = "";
                    textBoxEntrDateDoc.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    textBoxEntrCode1.Text = "";
                    textBoxEntrCode2.Text = "";
                    textBoxEntrCode3.Text = "";
                    textBoxEntrOperID.Text = "";
                    textBoxEntrFilingDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
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

        // событие: загрузка формы для изменения данных абитуриента из общего списка
        private void ChangingEntrant_Load(object sender, EventArgs e)
        {
            textBoxEntrSurname.Text = surname;                                          // вписать в поле фамилию выбранного абитуриента
            textBoxEntrName.Text = name;                                                //  ---             имя                 ---
            textBoxEntrLastName.Text = last_name;                                       //  ---           отчество              ---
            textBoxEntrBirthday.Value = Convert.ToDateTime(birthday, null);             // вписать в поле дату рождения абитуриента, конвертированную в корректный формат  
            textBoxEntrTelNo.Text = telNo;                                              //  ---        номер телефона           ---
            textBoxEntrEmail.Text = email;                                              //  ---        адрес эл. почты          ---
            textBoxEntrPassport.Text = passport;                                        //  ---            паспорт              ---
            textBoxEntrDocNo.Text = docNo;                                              //  ---  № документа об образовании     ---
            textBoxEntrDateDoc.Value = Convert.ToDateTime(docDate, null);               // вписать в поле дату выдачи документа об образовании, конвертированную в корректный формат  
            textBoxEntrCode1.Text = code_1;                                             //  ---          конкурс № 1            ---
            textBoxEntrCode2.Text = code_2;                                             //  ---          конкурс № 2            ---
            textBoxEntrCode3.Text = code_3;                                             //  ---          конкурс № 3            ---
            textBoxEntrOperID.Text = login;                                             // вписать в поле логин авторизованного сотрудника (также код обработавшего сотрудника)
            textBoxEntrFilingDate.Value = Convert.ToDateTime(filing_date, null);        // вписать в поле дату подачи заявления на участие в конкурсе, конвертированную в корректный формат  
        }

        // событие: однократное нажатие мышью на поле для ввода номера телефона (+7 (___) ___-____) (MaskedTextBox)
        private void textBoxEntrTelNo_MouseClick(object sender, MouseEventArgs e)
        {
            //  перевод каретки на первую свободную позицию при наступлении данного события
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