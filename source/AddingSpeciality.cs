using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма добавления специальности в базу данных
    public partial class AddingSpeciality : Form
    {
        private MainForm mainForm;      // экземпляр главной формы приложения
        private int userType;           // тип авторизованного пользователя

        // конструктор класса
        public AddingSpeciality(MainForm mainForm, int userType)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.userType = userType;
        }

        // событие: нажатие на кнопку "Добавить" в форме добавления направления подготовки (специальности)
        private void buttonAddSpeciality_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("INSERT INTO speciality VALUES(@speciality_code, @speciality_name, @number_of_places, @passing_score, @exam_1, @exam_2, @exam_3, @speciality_cost)", db.getConnection());

                if (textBoxSpecialityCode.Text != "" && textBoxSpecialityName.Text != "" && textBoxSpecialityPlaces.Text != "" && textBoxSpecialityPassing.Text != "" && textBoxSpecialityCost.Text != "" && textBoxSpecialityExam1.Text != "" && textBoxSpecialityExam2.Text != "" && textBoxSpecialityExam3.Text != "")   // проверка непустоты полей
                {
                    command.Parameters.Add("@speciality_code", MySqlDbType.VarChar).Value = textBoxSpecialityCode.Text;
                    command.Parameters.Add("@speciality_name", MySqlDbType.VarChar).Value = textBoxSpecialityName.Text;
                    command.Parameters.Add("@number_of_places", MySqlDbType.Int32).Value = textBoxSpecialityPlaces.Text;
                    command.Parameters.Add("@passing_score", MySqlDbType.Int32).Value = textBoxSpecialityPassing.Text;
                    command.Parameters.Add("@speciality_cost", MySqlDbType.Int32).Value = textBoxSpecialityCost.Text;
                    command.Parameters.Add("@exam_1", MySqlDbType.VarChar).Value = textBoxSpecialityExam1.Text;
                    command.Parameters.Add("@exam_2", MySqlDbType.VarChar).Value = textBoxSpecialityExam2.Text;
                    command.Parameters.Add("@exam_3", MySqlDbType.VarChar).Value = textBoxSpecialityExam3.Text;
                }
                else
                {
                    MessageBox.Show("Не все данные введены!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (command.ExecuteNonQuery() == 1)
                {
                    textBoxSpecialityCode.Text = "";
                    textBoxSpecialityName.Text = "";
                    textBoxSpecialityPlaces.Text = "";
                    textBoxSpecialityPassing.Text = "";
                    textBoxSpecialityCost.Text = "";
                    textBoxSpecialityExam1.Text = "";
                    textBoxSpecialityExam2.Text = "";
                    textBoxSpecialityExam3.Text = "";
                    
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

        // событие: однократное нажатие мышью на поле для ввода кода направления подготовки (специальности) (__.__.__) (MaskedTextBox)
        private void textBoxSpecialityCode_MouseClick(object sender, MouseEventArgs e)
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
    }
}