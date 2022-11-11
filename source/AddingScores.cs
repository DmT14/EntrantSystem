using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма добавления баллов абитуриента в базу данных
    public partial class AddingScores : Form
    {
        private MainForm mainForm;      // экземпляр главной формы приложения
        private int userType;           // тип авторизованного пользователя
        private bool parent;            // из какой формы вызвана данная форма: true — из формы добавления абитуриента, false — из главной формы

        // конструктор класса
        public AddingScores(TextBox textBox, bool parent, int userType, MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.userType = userType;
            this.parent = parent;

            if (parent) textBoxScoresDocument.Text = textBox.Text;
            else textBoxScoresDocument.Text = "";
        }

        // событие: нажатие на кнопку "Добавить" в форме добавления результатов вступительных испытаний
        private void buttonAddScores_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("INSERT INTO exams VALUES(@document_number, @russian_language, @maths, @information_technologies, @physics, @chemistry, @biology, @social_science, @history, @foreign_language, @literature, @geography, @personal_achievements, @comments)", db.getConnection());

                // проверка заполненности обязательных для заполнения полей
                if (textBoxScoresDocument.Text != "") command.Parameters.Add("@document_number", MySqlDbType.VarChar).Value = textBoxScoresDocument.Text;
                else
                {
                    MessageBox.Show("Введите № документа об образовании!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textBoxScoresRussian.Text != "") command.Parameters.Add("@russian_language", MySqlDbType.Int16).Value = textBoxScoresRussian.Text;
                else
                {
                    MessageBox.Show("Введите количество баллов по русскому языку!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // если поле с баллами по конкретному ВИ пустое — в него вписывается 0, иначе то значение, которое указал пользователь, изменяющий результаты ВИ
                if (textBoxScoresMaths.Text == "") command.Parameters.Add("@maths", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@maths", MySqlDbType.Int16).Value = textBoxScoresMaths.Text;

                if (textBoxScoresInform.Text == "") command.Parameters.Add("@information_technologies", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@information_technologies", MySqlDbType.Int16).Value = textBoxScoresInform.Text;

                if (textBoxScoresPhysics.Text == "") command.Parameters.Add("@physics", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@physics", MySqlDbType.Int16).Value = textBoxScoresPhysics.Text;

                if (textBoxScoresChemistry.Text == "") command.Parameters.Add("@chemistry", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@chemistry", MySqlDbType.Int16).Value = textBoxScoresChemistry.Text;

                if (textBoxScoresBiology.Text == "") command.Parameters.Add("@biology", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@biology", MySqlDbType.Int16).Value = textBoxScoresBiology.Text;

                if (textBoxScoresSocialScience.Text == "") command.Parameters.Add("@social_science", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@social_science", MySqlDbType.Int16).Value = textBoxScoresSocialScience.Text;

                if (textBoxScoresHistory.Text == "") command.Parameters.Add("@history", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@history", MySqlDbType.Int16).Value = textBoxScoresHistory.Text;

                if (textBoxScoresForeign.Text == "") command.Parameters.Add("@foreign_language", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@foreign_language", MySqlDbType.Int16).Value = textBoxScoresForeign.Text;

                if (textBoxScoresLiterature.Text == "") command.Parameters.Add("@literature", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@literature", MySqlDbType.Int16).Value = textBoxScoresLiterature.Text;

                if (textBoxScoresGeography.Text == "") command.Parameters.Add("@geography", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@geography", MySqlDbType.Int16).Value = textBoxScoresGeography.Text;

                if (textBoxScoresAchievements.Text == "") command.Parameters.Add("@personal_achievements", MySqlDbType.Int16).Value = 0;
                else command.Parameters.Add("@personal_achievements", MySqlDbType.Int16).Value = textBoxScoresAchievements.Text;

                command.Parameters.Add("@comments", MySqlDbType.LongText).Value = textBoxScoresComments.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    textBoxScoresDocument.Text = "";
                    textBoxScoresRussian.Text = "";
                    textBoxScoresMaths.Text = "";
                    textBoxScoresInform.Text = "";
                    textBoxScoresPhysics.Text = "";
                    textBoxScoresChemistry.Text = "";
                    textBoxScoresBiology.Text = "";
                    textBoxScoresSocialScience.Text = "";
                    textBoxScoresHistory.Text = "";
                    textBoxScoresForeign.Text = "";
                    textBoxScoresLiterature.Text = "";
                    textBoxScoresGeography.Text = "";
                    textBoxScoresAchievements.Text = "";
                    textBoxScoresComments.Text = "";
                    
                    mainForm.toFillTables(userType);
                    MessageBox.Show("Запись добавлена.");
                    if (parent) Close();
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
    }
}