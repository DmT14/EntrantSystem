using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма добавления абитуриента в базу данных
    public partial class AddingEntrant : Form
    {
        private MainForm mainForm;      // экземпляр главной формы приложения
        private int userType;           // тип авторизованного пользователя

        // конструктор класса
        public AddingEntrant(string login, int userType, MainForm mainForm)
        {
            InitializeComponent();

            textBoxEntrOperID.Text = login;
            this.mainForm = mainForm;
            this.userType = userType;
        }

        // событие: нажатие на кнопку "Добавить" в форме добавления абитуриента
        private void buttonAddEntrant_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();

            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("INSERT INTO entrant(user_type, surname, name, last_name, birthday, phone_number, email, passport, document_number, date_of_issue, code_1, code_2, code_3, oper_id, filing_date) VALUES(3, @surname, @name, @last_name, @birthday, @phone_number, @email, @passport, @document_number, @date_of_issue, @code_1, @code_2, @code_3, @oper_id, @filing_date)", db.getConnection());

                if (textBoxEntrSurname.Text != "" && textBoxEntrName.Text != "" && textBoxEntrBirthday.Text != "" && textBoxEntrTelNo.Text != "" && textBoxEntrEmail.Text != "" && textBoxEntrPassport.Text != "" && textBoxEntrDocNo.Text != "" && textBoxEntrTelNo.Text != "" && textBoxEntrOperID.Text != "" && textBoxEntrFilingDate.Text != "")        // проверка непустоты полей
                {
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
                    command.Parameters.Add("@oper_id", MySqlDbType.Int16).Value = textBoxEntrOperID.Text;
                    command.Parameters.Add("@filing_date", MySqlDbType.Date).Value = textBoxEntrFilingDate.Value.Date.ToString("yyyy-MM-dd");
                }
                else
                {
                    MessageBox.Show("Запись не добавлена, проверьте заполнение всех полей.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (command.ExecuteNonQuery() == 1)
                {
                    mainForm.toFillTables(userType);
                    MessageBox.Show("Запись добавлена.");

                    DialogResult result = MessageBox.Show("Ввести баллы добавленного абитуриента?", "Выберите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)     // открытие формы добавления баллов абитуриента с параметров parent = true
                    {
                        AddingScores form = new AddingScores(textBoxEntrDocNo, true, userType, mainForm);
                        form.Show(this);
                    }
                }  
                else MessageBox.Show("Запись не добавлена, проверьте заполнение всех полей.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxEntrSurname.Text = "";
                textBoxEntrName.Text = "";
                textBoxEntrLastName.Text = "";
                textBoxEntrBirthday.Value = new DateTime(DateTime.Now.Year - 18, 1, 1);
                textBoxEntrTelNo.Text = "";
                textBoxEntrEmail.Text = "";
                textBoxEntrPassport.Text = "";
                textBoxEntrDocNo.Text = "";
                textBoxEntrDateDoc.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                textBoxEntrCode1.Text = "—";
                textBoxEntrCode2.Text = "—";
                textBoxEntrCode3.Text = "—";
                textBoxEntrFilingDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

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

        // событие: загрузка формы добавления абитуриента
        private void AddingEntrant_Load(object sender, EventArgs e)
        {
            textBoxEntrBirthday.Value = new DateTime(DateTime.Now.Year - 18, 1, 1);
        }

        // событие: однократное нажатие мышью на поле для ввода кода направления подготовки (специальности) (__.__.__) (MaskedTextBox)
        private void textBoxEntrCode1_MouseClick(object sender, MouseEventArgs e)
        {
            // перевод каретки на первую свободную позицию при наступлении данного события
            try
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
                string code = maskedTextBox.Text;
                int index = 0;

                if (code[code.Length - 1] != '_' && code[code.Length - 1] != '.')
                    return;

                else
                {
                    for (int i = 1; i < code.Length; i++)
                    {
                        if (i == code.Length - 1)
                        {
                            if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_')
                            {
                                index = i;
                                break;
                            }
                        }
                        if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_' && (code[i + 1] == '.' || code[i + 1] == '_'))
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

        // событие: однократное нажатие мышью на поле для ввода кода направления подготовки (специальности) (__.__.__) (MaskedTextBox)
        private void textBoxEntrCode2_MouseClick(object sender, MouseEventArgs e)
        {
            // перевод каретки на первую свободную позицию при наступлении данного события
            try
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
                string code = maskedTextBox.Text;
                int index = 0;

                if (code[code.Length - 1] != '_' && code[code.Length - 1] != '.')
                    return;

                else
                {
                    for (int i = 1; i < code.Length; i++)
                    {
                        if (i == code.Length - 1)
                        {
                            if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_')
                            {
                                index = i;
                                break;
                            }
                        }
                        if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_' && (code[i + 1] == '.' || code[i + 1] == '_'))
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

        // событие: однократное нажатие мышью на поле для ввода кода направления подготовки (специальности) (__.__.__) (MaskedTextBox)
        private void textBoxEntrCode3_MouseClick(object sender, MouseEventArgs e)
        {
            // перевод каретки на первую свободную позицию при наступлении данного события
            try
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
                string code = maskedTextBox.Text;
                int index = 0;

                if (code[code.Length - 1] != '_' && code[code.Length - 1] != '.')
                    return;

                else
                {
                    for (int i = 1; i < code.Length; i++)
                    {
                        if (i == code.Length - 1)
                        {
                            if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_')
                            {
                                index = i;
                                break;
                            }
                        }
                        if ((code[i] == '.' || code[i] == '_') && code[i - 1] != '.' && code[i - 1] != '_' && (code[i + 1] == '.' || code[i + 1] == '_'))
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

        // событие: однократное нажатие мышью на поле для ввода паспортных данных (____ ______) (MaskedTextBox)
        private void textBoxEntrPassport_MouseClick(object sender, MouseEventArgs e)
        {
            // перевод каретки на первую свободную позицию при наступлении данного события
            try
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
                string passport = maskedTextBox.Text;
                int index = 0;

                if (passport[passport.Length - 1] != '_')
                    return;

                else
                {
                    for (int i = 1; i < passport.Length; i++)
                    {
                        if (i == passport.Length - 1)
                        {
                            if ((passport[i] == '_' || passport[i] == ' ') && passport[i - 1] != '_')
                            {
                                index = i;
                                break;
                            }
                        }
                        if ((passport[i] == '_' || passport[i] == ' ') && passport[i - 1] != '_' && passport[i - 1] != ' ' && (passport[i + 1] == '_' || passport[i + 1] == ' '))
                        {
                            index = i;
                            if (passport[i] == ' ')
                                index++;
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