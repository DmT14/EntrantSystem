using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — форма изменения баллов абитуриента
    public partial class ChangingScores : Form
    {
        private string docNo = "";               // номер документа об образовании указанного набора результатов ВИ
        private string russian = "";             // ВИ: русский язык
        private string maths = "";               //     математика
        private string inform = "";              //     информатика и ИКТ
        private string physics = "";             //     и т.д.
        private string chemistry = "";           //     ...
        private string biology = "";
        private string social = "";
        private string history = "";
        private string foreign = "";
        private string literature = "";
        private string geography = "";
        private string achievements = "";        // баллы за индивидуальные достижения
        private string comments = "";            // комментарий
        private MainForm mainForm;               // экземпляр главной формы приложения
        private int user_type_acting;            // тип авторизованного пользователя
        private string login;                    // логин авторизованного пользователя (также идентификатор)

        // конструктор класса
        public ChangingScores(MainForm mainForm, int userType, string login, string docNo, string russian, string maths, string inform, string physics, string chemistry, string biology, string social, string history, string foreign, string literature, string geography, string achievements, string comments)
        {
            InitializeComponent();

            this.docNo = docNo;
            this.russian = russian;
            this.maths = maths;
            this.inform = inform;
            this.physics = physics;
            this.chemistry = chemistry;
            this.biology = biology;
            this.social = social;
            this.history = history;
            this.foreign = foreign;
            this.literature = literature;
            this.geography = geography;
            this.achievements = achievements;
            this.comments = comments;
            this.mainForm = mainForm;
            user_type_acting = userType;
            this.login = login;
        }

        // событие: нажатие на кнопку "Изменить" в форме изменения результатов ВИ (вызов из вкладки общего результатов ВИ)
        private void buttonAddScores_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                MySqlCommand command = new MySqlCommand("UPDATE exams SET russian_language = @russian_language, maths = @maths, information_technologies = @information_technologies, physics = @physics, chemistry = @chemistry, biology = @biology, social_science = @social_science, history = @history, foreign_language = @foreign_language, literature = @literature, geography = @geography, personal_achievements = @personal_achievements, comments = @comments WHERE document_number = @docNo", db.getConnection());

                if (textBoxScoresRussian.Text != "") command.Parameters.Add("@russian_language", MySqlDbType.Int16).Value = textBoxScoresRussian.Text;      // проверка непустоты поля для ввода баллов по русскому языку
                else
                {
                    MessageBox.Show("Введите количество баллов по русскому языку!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                command.Parameters.Add("@docNo", MySqlDbType.VarChar).Value = docNo;

                // если поле с результатами по конкретному ВИ пустое — в него вписывается 0, иначе то значение, которое указал пользователь, изменяющий баллы
                
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

                // установка в код обработавшего сотрудника код сотрудника, который изменил результаты ВИ абитуриента
                MySqlCommand commandChangeOper = new MySqlCommand("UPDATE entrant SET oper_id = @oper_id WHERE document_number = @docNo", db.getConnection());
                commandChangeOper.Parameters.Add("@oper_id", MySqlDbType.Int16).Value = login;
                commandChangeOper.Parameters.Add("@docNo", MySqlDbType.VarChar).Value = docNo;

                if (command.ExecuteNonQuery() == 1 && commandChangeOper.ExecuteNonQuery() == 1)
                {
                    mainForm.toFillTables(user_type_acting);
                    MessageBox.Show("Запись изменена.");
                    textBoxScoresDocument.Text = "";
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

        // событие: загрузка формы для изменения результатов ВИ абитуриента из общего списка
        private void ChangingScores_Load(object sender, EventArgs e)
        {
            textBoxScoresDocument.Text = docNo;                 // вписать в поле номер документа об образовании указанного набора результатов ВИ      
            textBoxScoresRussian.Text = russian;                //           ---  результаты по русскому языку        ---
            textBoxScoresMaths.Text = maths;                    //           ---  результаты по математике            ---
            textBoxScoresInform.Text = inform;                  //           ---  и т.д.                              ---
            textBoxScoresPhysics.Text = physics;                //           ---  ...                                 ---
            textBoxScoresChemistry.Text = chemistry;
            textBoxScoresBiology.Text = biology;
            textBoxScoresSocialScience.Text = social;
            textBoxScoresHistory.Text = history;
            textBoxScoresForeign.Text = foreign;
            textBoxScoresLiterature.Text = literature;
            textBoxScoresGeography.Text = geography;
            textBoxScoresAchievements.Text = achievements;      //           ---  баллы за индивидуальные достижения  ---
            textBoxScoresComments.Text = comments;              //           ---  комментарий                         ---
        }
    }
}