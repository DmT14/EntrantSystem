using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма изменения данных специальности из общего реестра
    public partial class ChangingSpeciality : Form
    {
        private string code = "";               // код указанного направления подготовки (специальности)  
        private string name = "";               // наименование
        private string places = "";             // количество бюджетных мест
        private string passing_last = "";       // проходной балл прошлого года
        private string cost = "";               // стоимость обучения за год
        private string sub_1 = "";              // вступительное испытание № 1
        private string sub_2 = "";              // вступительное испытание № 2
        private string sub_3 = "";              // вступительное испытание № 3
        private MainForm mainForm;              // экземпляр главной формы приложения
        private int user_type_acting;           // тип авторизованного пользователя

        // конструктор класса
        public ChangingSpeciality(MainForm mainForm, int userType, string code, string name, string places, string passing_last, string cost, string sub_1, string sub_2, string sub_3)
        {
            InitializeComponent();

            this.code = code;
            this.name = name;
            this.places = places;
            this.passing_last = passing_last;
            this.cost = cost;
            this.sub_1 = sub_1;
            this.sub_2 = sub_2;
            this.sub_3 = sub_3;
            this.mainForm = mainForm;
            user_type_acting = userType;
        }

        // событие: нажатие на кнопку "Изменить" форме изменения информации о направлении подготовки (специальности) (вызов формы из вкладки общего списка направлений подготовки (специальностей))
        private void buttonChangeSpeciality_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE speciality SET speciality_code = @code, speciality_name = @name, number_of_places = @places, passing_score = @passing_last, exam_1 = @sub_1, exam_2 = @sub_2, exam_3 = @sub_3, cost = @speciality_cost WHERE speciality_code = @code_old", db.getConnection());

                if (textBoxSpecialityCode.Text != "__.__.__" && textBoxSpecialityName.Text != "" && textBoxSpecialityPlaces.Text != "" && textBoxSpecialityPassing.Text != "" && textBoxSpecialityCost.Text != "" && textBoxSpecialityExam1.Text != "" && textBoxSpecialityExam2.Text != "" && textBoxSpecialityExam3.Text != "")   // проверка непустоты полей для ввода данных
                {
                    command.Parameters.Add("@code", MySqlDbType.VarChar).Value = textBoxSpecialityCode.Text;
                    command.Parameters.Add("@code_old", MySqlDbType.VarChar).Value = code;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxSpecialityName.Text;
                    command.Parameters.Add("@places", MySqlDbType.Int32).Value = textBoxSpecialityPlaces.Text;
                    command.Parameters.Add("@passing_last", MySqlDbType.Int32).Value = textBoxSpecialityPassing.Text;
                    command.Parameters.Add("@speciality_cost", MySqlDbType.Int32).Value = textBoxSpecialityCost.Text;
                    command.Parameters.Add("@sub_1", MySqlDbType.VarChar).Value = textBoxSpecialityExam1.Text;
                    command.Parameters.Add("@sub_2", MySqlDbType.VarChar).Value = textBoxSpecialityExam2.Text;
                    command.Parameters.Add("@sub_3", MySqlDbType.VarChar).Value = textBoxSpecialityExam3.Text;
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
                    textBoxSpecialityCode.Text = "";
                    textBoxSpecialityName.Text = "";
                    textBoxSpecialityPlaces.Text = "";
                    textBoxSpecialityPassing.Text = "";
                    textBoxSpecialityCost.Text = "";
                    textBoxSpecialityExam1.Text = "";
                    textBoxSpecialityExam2.Text = "";
                    textBoxSpecialityExam3.Text = "";
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

        // событие: загрузка формы для изменения данных направления подготовки (специальности) из общего списка
        private void ChangingSpeciality_Load(object sender, EventArgs e)
        {
            textBoxSpecialityCode.Text = code;              // вписать в поле код указанного направления подготовки (специальности)
            textBoxSpecialityName.Text = name;              // ---        наименование          ---
            textBoxSpecialityPlaces.Text = places;          // ---   количество бюджет. мест    ---
            textBoxSpecialityPassing.Text = passing_last;   // --- проходной балл прошлого года ---
            textBoxSpecialityCost.Text = cost;              // ---  стоимость обучения за год   ---
            textBoxSpecialityExam1.Text = sub_1;            // ---           ВИ № 1             ---
            textBoxSpecialityExam2.Text = sub_2;            // ---           ВИ № 2             ---
            textBoxSpecialityExam3.Text = sub_3;            // ---           ВИ № 3             ---
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