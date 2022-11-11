using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EntrantSystem
{
    // Класс — главная форма приложения
    public partial class MainForm : Form
    {
        private string login;           // логин
        private string pass;            // пароль
        private int userType;           // тип пользователя
        private AuthForm authForm;      // экземпляр формы авторизации
        
        // конструктор класса
        public MainForm(int userType, string login, string password, AuthForm form)
        {
            InitializeComponent();

            this.login = login;
            pass = password;
            this.userType = userType;
            authForm = form;
            
            switch(userType)
            {
                case 3:                                 // настройка доступности элементов формы при входе абитуриента
                    tabWorkers.Parent = null;
                    tabEntrants.Parent = null;
                    tabScores.Parent = null;
                    tabCabinetWorker.Parent = null;
                    dataGridViewSpecialities.ReadOnly = true;
                    buttonAddSpecialityForm.Visible = false;
                    buttonDeleteSpeciality.Visible = false;
                    buttonChangeSpecialities.Visible = false;
                    break;

                case 2:                                 // настройка доступности элементов формы при входе оператора
                    tabWorkers.Parent = null;
                    tabCabinetEntr.Parent = null;
                    dataGridViewSpecialities.ReadOnly = true;
                    buttonAddSpecialityForm.Visible = false;
                    buttonDeleteSpeciality.Visible = false;
                    buttonChangeSpecialities.Visible = false;
                    pictureBoxWorker.Image = Properties.Resources.oper;
                    break;

                case 1:                                 // настройка доступности элементов формы при входе администратора
                    tabCabinetEntr.Parent = null;
                    pictureBoxWorker.Image = Properties.Resources.admin;
                    break;
            }
        }

        // событие: загрузка главной формы приложения
        private void MainForm_Load(object sender, EventArgs e)
        {
            authForm.Hide();
            toFillTables(userType);
            if (userType != 3) toFillCabinetWorker();
            else toFillCabinetEntrant();
        }

        // событие: закрытие главной формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            authForm.Show();
        }

        // функция: заполнение всех таблиц приложения данными из БД
        public void toFillTables(int userType)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();
                
                if (userType == 1)
                {
                    dataGridViewWorkers.Rows.Clear();
                    MySqlCommand commandWorkers = new MySqlCommand("SELECT * FROM worker", db.getConnection());
                    MySqlDataReader readerWorkers = commandWorkers.ExecuteReader();
                    while (readerWorkers.Read())
                    {
                        dataGridViewWorkers.Rows.Add(
                            readerWorkers["worker_id"],
                            readerWorkers["password"],
                            readerWorkers["user_type"],
                            readerWorkers["surname"],
                            readerWorkers["name"],
                            readerWorkers["last_name"],
                            readerWorkers["hiring_date"],
                            readerWorkers["phone_number"],
                            readerWorkers["email"]
                            );
                    }
                    readerWorkers.Close();
                }
                for (int i = 0; i < dataGridViewWorkers.RowCount - 1; i++)
                    if (dataGridViewWorkers.Rows[i].Cells[5].Value is null)
                        dataGridViewWorkers.Rows[i].Cells[5].Value = " ";

                if (userType != 3)
                {
                    dataGridViewEntrants.Rows.Clear();
                    MySqlCommand commandEntrants = new MySqlCommand("SELECT * FROM entrant", db.getConnection());
                    MySqlDataReader readerEntrants = commandEntrants.ExecuteReader();
                    while (readerEntrants.Read())
                    {
                        dataGridViewEntrants.Rows.Add(
                            readerEntrants["entrant_id"],
                            readerEntrants["surname"],
                            readerEntrants["name"],
                            readerEntrants["last_name"],
                            readerEntrants["birthday"],
                            readerEntrants["phone_number"],
                            readerEntrants["email"],
                            readerEntrants["passport"],
                            readerEntrants["document_number"],
                            readerEntrants["date_of_issue"],
                            readerEntrants["code_1"],
                            readerEntrants["code_2"],
                            readerEntrants["code_3"],
                            readerEntrants["oper_id"],
                            readerEntrants["filing_date"]
                            );
                    }
                    readerEntrants.Close();
                    for (int i = 0; i < dataGridViewEntrants.RowCount - 1; i++)
                        if (dataGridViewEntrants.Rows[i].Cells[3].Value is null)
                            dataGridViewEntrants.Rows[i].Cells[3].Value = " ";

                    dataGridViewScores.Rows.Clear();
                    MySqlCommand commandScores = new MySqlCommand("SELECT * FROM exams", db.getConnection());
                    MySqlDataReader readerScores = commandScores.ExecuteReader();
                    while (readerScores.Read())
                    {
                        dataGridViewScores.Rows.Add(
                            readerScores["document_number"],
                            readerScores["russian_language"],
                            readerScores["maths"],
                            readerScores["information_technologies"],
                            readerScores["physics"],
                            readerScores["chemistry"],
                            readerScores["biology"],
                            readerScores["social_science"],
                            readerScores["history"],
                            readerScores["foreign_language"],
                            readerScores["literature"],
                            readerScores["geography"],
                            readerScores["personal_achievements"],
                            readerScores["comments"]
                            );
                    }
                    readerScores.Close();
                }

                for (int i = 0; i < dataGridViewScores.RowCount; i++)
                    for (int j = 0; j < dataGridViewScores.ColumnCount - 2; j++)
                        if ("0".Equals(dataGridViewScores.Rows[i].Cells[j].Value) || dataGridViewScores.Rows[i].Cells[j].Value is 0)
                            dataGridViewScores.Rows[i].Cells[j].Value = null;


                dataGridViewSpecialities.Rows.Clear();
                MySqlCommand commandSpecialities = new MySqlCommand("SELECT * FROM speciality WHERE speciality_code != '-' AND speciality_code != '—'", db.getConnection());
                MySqlDataReader readerSpecialities = commandSpecialities.ExecuteReader();
                while (readerSpecialities.Read())
                {
                    dataGridViewSpecialities.Rows.Add(
                        readerSpecialities["speciality_code"],
                        readerSpecialities["speciality_name"],
                        readerSpecialities["number_of_places"],
                        readerSpecialities["passing_score"],
                        readerSpecialities["cost"],
                        readerSpecialities["exam_1"],
                        readerSpecialities["exam_2"],
                        readerSpecialities["exam_3"]
                        );
                }
                readerSpecialities.Close();
                if (userType != 3) toFillCabinetWorker();
                else toFillCabinetEntrant();

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

        // событие: нажатие на кнопку меню "Файл" — "Обновить информацию"
        private void обновитьИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewCompetition.Rows.Clear();
            textBoxCodeForResult.Text = "";
            textBoxSpecialityName.Text = "";
            textBoxSpecialityPlaces.Text = "";
            textBoxSpecialityPassing.Text = "";
            textBoxCurrentPassingScore.Text = "";
            textBoxAverageScore.Text = "";
            textBoxCost.Text = "";
            textBoxSurnameForCompetitionSearch.Text = "";
            textBoxSurnameWorkersForSearch.Text = "";
            textBoxSurnameEntrantsForSearch.Text = "";
            textBoxDocumentForSearch.Text = "";
            textBoxSpecialityForSearch.Text = "";

            toFillTables(userType);
            if (userType != 3) toFillCabinetWorker();
            else toFillCabinetEntrant();
        }

        // событие: нажатие на кнопку меню "Файл" — "Выйти из учётной записи"
        private void выйтиИзУчётнойЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            authForm.Show();
        }

        // событие: нажатие на кнопку меню "Помощь" — "О программе"
        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информационная система учёта абитуриентов высшего учебного заведения предназначена для автоматизации приёмной кампании и призвана повысить эффективность работы приёмной комиссии.\n\n© Дмитрий Терентьев, 2021");
        }

        // событие: нажатие на кнопку "Добавить сотрудника" во вкладке общего списка сотрудников
        private void buttonAddWorkerForm_Click(object sender, EventArgs e)
        {
            AddingWorker form = new AddingWorker(this, userType);
            form.Show(this);
        }

        // событие: нажатие на кнопку "Добавить абитуриента" во вкладке общего списка абитуриентов
        private void buttonAddEntrantForm_Click(object sender, EventArgs e)
        {
            AddingEntrant form = new AddingEntrant(login, userType, this);
            form.Show(this);
        }

        // событие: нажатие на кнопку "Добавить результаты" во вкладке общего списка результатов вступительных испытаний
        private void buttonAddScoresForm_Click(object sender, EventArgs e)
        {
            AddingScores form = new AddingScores(null, false, userType, this);
            form.Show(this);
        }

        // событие: нажатие на кнопку "Добавить" во вкладке общего списка направлений подготовки (специальностей)
        private void buttonAddSpecialityForm_Click(object sender, EventArgs e)
        {
            AddingSpeciality form = new AddingSpeciality(this, userType);
            form.Show(this);
        }

        // событие: нажатие на кнопку "Изменить информацию" во вкладке общего списка сотрудников
        private void buttonChangeWorkers_Click(object sender, EventArgs e)
        {
            string id = dataGridViewWorkers.CurrentRow.Cells[0].Value.ToString();
            string password = dataGridViewWorkers.CurrentRow.Cells[1].Value.ToString();
            string user_type = dataGridViewWorkers.CurrentRow.Cells[2].Value.ToString();
            string surname = dataGridViewWorkers.CurrentRow.Cells[3].Value.ToString();
            string name = dataGridViewWorkers.CurrentRow.Cells[4].Value.ToString();
            string last_name = dataGridViewWorkers.CurrentRow.Cells[5].Value.ToString();
            string hiring_date = dataGridViewWorkers.CurrentRow.Cells[6].Value.ToString();
            string telNo = dataGridViewWorkers.CurrentRow.Cells[7].Value.ToString();
            string email = dataGridViewWorkers.CurrentRow.Cells[8].Value.ToString();
            ChangingWorker changingWorker = new ChangingWorker(this, userType, id, password, user_type, surname, name, last_name, hiring_date, telNo, email);
            changingWorker.Show(this);
        }

        // событие: нажатие на кнопку "Изменить информацию" во вкладке общего списка абитуриентов
        private void buttonChangeEntrants_Click(object sender, EventArgs e)
        {
            string id = dataGridViewEntrants.CurrentRow.Cells[0].Value.ToString();
            string surname = dataGridViewEntrants.CurrentRow.Cells[1].Value.ToString();
            string name = dataGridViewEntrants.CurrentRow.Cells[2].Value.ToString();
            string last_name = dataGridViewEntrants.CurrentRow.Cells[3].Value.ToString();
            string birthday = dataGridViewEntrants.CurrentRow.Cells[4].Value.ToString();
            string telNo = dataGridViewEntrants.CurrentRow.Cells[5].Value.ToString();
            string email = dataGridViewEntrants.CurrentRow.Cells[6].Value.ToString();
            string passport = dataGridViewEntrants.CurrentRow.Cells[7].Value.ToString();
            string docNo = dataGridViewEntrants.CurrentRow.Cells[8].Value.ToString();
            string docDate = dataGridViewEntrants.CurrentRow.Cells[9].Value.ToString();
            string code_1 = dataGridViewEntrants.CurrentRow.Cells[10].Value.ToString();
            string code_2 = dataGridViewEntrants.CurrentRow.Cells[11].Value.ToString();
            string code_3 = dataGridViewEntrants.CurrentRow.Cells[12].Value.ToString();
            string oper_id = dataGridViewEntrants.CurrentRow.Cells[13].Value.ToString();
            string filing_date = dataGridViewEntrants.CurrentRow.Cells[14].Value.ToString();
            ChangingEntrant changingEntrant = new ChangingEntrant(this, userType, login, id, surname, name, last_name, birthday, telNo, email, passport, docNo, docDate, code_1, code_2, code_3, oper_id, filing_date);
            changingEntrant.Show(this);
        }

        // событие: нажатие на кнопку "Изменить информацию" во вкладке общего списка результатов вступительных испытаний
        private void buttonChangeScores_Click(object sender, EventArgs e)
        {
            string docNo = dataGridViewScores.CurrentRow.Cells[0].Value.ToString();
            string russian = dataGridViewScores.CurrentRow.Cells[1].Value.ToString();
            string maths = dataGridViewScores.CurrentRow.Cells[2].Value.ToString();
            string inform = dataGridViewScores.CurrentRow.Cells[3].Value.ToString();
            string physics = dataGridViewScores.CurrentRow.Cells[4].Value.ToString();
            string chemistry = dataGridViewScores.CurrentRow.Cells[5].Value.ToString();
            string biology = dataGridViewScores.CurrentRow.Cells[6].Value.ToString();
            string social = dataGridViewScores.CurrentRow.Cells[7].Value.ToString();
            string history = dataGridViewScores.CurrentRow.Cells[8].Value.ToString();
            string foreign = dataGridViewScores.CurrentRow.Cells[9].Value.ToString();
            string literature = dataGridViewScores.CurrentRow.Cells[10].Value.ToString();
            string geography = dataGridViewScores.CurrentRow.Cells[11].Value.ToString();
            string achievements = dataGridViewScores.CurrentRow.Cells[12].Value.ToString();
            string comments = dataGridViewScores.CurrentRow.Cells[13].Value.ToString();
            ChangingScores changingScores = new ChangingScores(this, userType, login, docNo, russian, maths, inform, physics, chemistry, biology, social, history, foreign, literature, geography, achievements, comments);
            changingScores.Show(this);
        }

        // событие: нажатие на кнопку "Изменить информацию" во вкладке общего списка направлений подготовки (специальностей)
        private void buttonChangeSpecialities_Click(object sender, EventArgs e)
        {
            string code = dataGridViewSpecialities.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridViewSpecialities.CurrentRow.Cells[1].Value.ToString();
            string places = dataGridViewSpecialities.CurrentRow.Cells[2].Value.ToString();
            string passing_last = dataGridViewSpecialities.CurrentRow.Cells[3].Value.ToString();
            string cost = dataGridViewSpecialities.CurrentRow.Cells[4].Value.ToString();
            string sub_1 = dataGridViewSpecialities.CurrentRow.Cells[5].Value.ToString();
            string sub_2 = dataGridViewSpecialities.CurrentRow.Cells[6].Value.ToString();
            string sub_3 = dataGridViewSpecialities.CurrentRow.Cells[7].Value.ToString();
            ChangingSpeciality changingSpeciality = new ChangingSpeciality(this, userType, code, name, places, passing_last, cost, sub_1, sub_2, sub_3);
            changingSpeciality.Show(this);
        }

        // событие: нажатие на кнопку "Удалить сотрудника" во вкладке общего списка сотрудников
        private void buttonDeleteWorker_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();
                
                DialogResult result = MessageBox.Show("Удалить запись?", "Выберите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    db.closeConnection();
                    return;
                }

                string worker_id = dataGridViewWorkers.CurrentRow.Cells["worker_id"].Value.ToString();
                MySqlCommand commandDelete = new MySqlCommand("DELETE FROM worker WHERE worker_id = @worker_id", db.getConnection());
                commandDelete.Parameters.Add(new MySqlParameter("@worker_id", worker_id));

                // цикл, проверяющий, является ли данный сотрудник оператором хотя бы одного абитуриента
                bool flag = false;
                for(int i = 0; i < dataGridViewEntrants.RowCount; i++)
                    if(dataGridViewEntrants.Rows[i].Cells[13].Value == dataGridViewWorkers.CurrentRow.Cells["worker_id"].Value)
                    {
                        flag = true;
                        break;
                    }

                if (commandDelete.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запись удалена.");
                    dataGridViewWorkers.Rows.Clear();
                    MySqlCommand commandWorkers = new MySqlCommand("SELECT * FROM worker", db.getConnection());
                    MySqlDataReader readerWorkers = commandWorkers.ExecuteReader();
                    while (readerWorkers.Read())
                    {
                        dataGridViewWorkers.Rows.Add(
                            readerWorkers["worker_id"],
                            readerWorkers["password"],
                            readerWorkers["user_type"],
                            readerWorkers["surname"],
                            readerWorkers["name"],
                            readerWorkers["last_name"],
                            readerWorkers["hiring_date"],
                            readerWorkers["phone_number"],
                            readerWorkers["email"]
                            );
                    }
                    readerWorkers.Close();

                    if (flag)
                    {
                        MySqlCommand commandGetEntrID = new MySqlCommand("SELECT entrant_id FROM entrant WHERE oper_id = @worker_id", db.getConnection());
                        commandGetEntrID.Parameters.Add(new MySqlParameter("@worker_id", worker_id));
                        object value = commandGetEntrID.ExecuteScalar();
                        string entr_id = value.ToString();

                        MySqlCommand commandChangeOper = new MySqlCommand("UPDATE entrant SET oper_id = @login WHERE oper_id IS NULL", db.getConnection());
                        commandChangeOper.Parameters.Add(new MySqlParameter("@login", login));
                        commandChangeOper.ExecuteNonQuery();
                    }  
                }
                
                if (login == worker_id) Close();
                else toFillTables(userType);

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

        // событие: нажатие на кнопку "Удалить абитуриента" во вкладке общего списка абитуриентов
        private void buttonDeleteEntrant_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();
                
                DialogResult result = MessageBox.Show("Удалить запись?", "Выберите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    db.closeConnection();
                    return;
                }

                MySqlCommand command = new MySqlCommand("DELETE FROM entrant WHERE entrant_id = @entrant_id", db.getConnection());
                command.Parameters.Add(new MySqlParameter("@entrant_id", this.dataGridViewEntrants.CurrentRow.Cells["entrant_id"].Value));

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запись удалена.");
                    dataGridViewEntrants.Rows.Clear();
                    MySqlCommand commandEntrants = new MySqlCommand("SELECT * FROM entrant", db.getConnection());
                    MySqlDataReader readerEntrants = commandEntrants.ExecuteReader();
                    while (readerEntrants.Read())
                    {
                        dataGridViewEntrants.Rows.Add(
                            readerEntrants["entrant_id"],
                            readerEntrants["surname"],
                            readerEntrants["name"],
                            readerEntrants["last_name"],
                            readerEntrants["birthday"],
                            readerEntrants["phone_number"],
                            readerEntrants["email"],
                            readerEntrants["passport"],
                            readerEntrants["document_number"],
                            readerEntrants["date_of_issue"],
                            readerEntrants["code_1"],
                            readerEntrants["code_2"],
                            readerEntrants["code_3"],
                            readerEntrants["oper_id"],
                            readerEntrants["filing_date"]
                            );
                    }
                    readerEntrants.Close();
                }

                toFillTables(userType);
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

        // событие: нажатие на кнопку "Удалить" во вкладке общего списка направлений подготовки (специальностей)
        private void buttonDeleteSpeciality_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            try
            {
                db.openConnection();

                DialogResult result = MessageBox.Show("Удалить запись?", "Выберите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    db.closeConnection();
                    return;
                }

                MySqlCommand command = new MySqlCommand("DELETE FROM speciality WHERE speciality_code = @speciality_code", db.getConnection());
                command.Parameters.Add(new MySqlParameter("@speciality_code", this.dataGridViewSpecialities.CurrentRow.Cells["speciality_code"].Value));

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Запись удалена.");
                    dataGridViewSpecialities.Rows.Clear();
                    MySqlCommand commandSpecialities = new MySqlCommand("SELECT * FROM speciality", db.getConnection());
                    MySqlDataReader readerSpecialities = commandSpecialities.ExecuteReader();
                    while (readerSpecialities.Read())
                    {
                        dataGridViewSpecialities.Rows.Add(
                            readerSpecialities["speciality_code"],
                            readerSpecialities["speciality_name"],
                            readerSpecialities["number_of_places"],
                            readerSpecialities["passing_score"],
                            readerSpecialities["cost"],
                            readerSpecialities["exam_1"],
                            readerSpecialities["exam_2"],
                            readerSpecialities["exam_3"]
                        );
                    }
                    readerSpecialities.Close();

                    MySqlCommand commandChangeCode_1 = new MySqlCommand("UPDATE entrant SET code_1 = '—' WHERE code_1 IS NULL", db.getConnection());
                    MySqlCommand commandChangeCode_2 = new MySqlCommand("UPDATE entrant SET code_2 = '—' WHERE code_2 IS NULL", db.getConnection());
                    MySqlCommand commandChangeCode_3 = new MySqlCommand("UPDATE entrant SET code_3 = '—' WHERE code_3 IS NULL", db.getConnection());
                    commandChangeCode_1.ExecuteNonQuery();
                    commandChangeCode_2.ExecuteNonQuery();
                    commandChangeCode_3.ExecuteNonQuery();
                }

                toFillTables(userType);
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

        // событие: нажатие на кнопку "Обновить информацию" во вкладке общего списка сотрудников
        private void buttonRefreshWorkers_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            dataGridViewWorkers.Rows.Clear();
            try
            {
                db.openConnection();
                
                MySqlCommand commandWorkers = new MySqlCommand("SELECT * FROM worker", db.getConnection());
                MySqlDataReader readerWorkers = commandWorkers.ExecuteReader();
                while (readerWorkers.Read())
                {
                    dataGridViewWorkers.Rows.Add(
                        readerWorkers["worker_id"],
                        readerWorkers["password"],
                        readerWorkers["user_type"],
                        readerWorkers["surname"],
                        readerWorkers["name"],
                        readerWorkers["last_name"],
                        readerWorkers["hiring_date"],
                        readerWorkers["phone_number"],
                        readerWorkers["email"]
                        );
                }
                readerWorkers.Close();

                for (int i = 0; i < dataGridViewWorkers.RowCount - 1; i++)
                    if (dataGridViewWorkers.Rows[i].Cells[5].Value is null)
                        dataGridViewWorkers.Rows[i].Cells[5].Value = " ";

                textBoxSurnameWorkersForSearch.Text = "";
                
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

        // событие: нажатие на кнопку "Обновить информацию" во вкладке общего списка абитуриентов
        private void buttonRefreshEntrants_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            dataGridViewEntrants.Rows.Clear();
            try
            {
                db.openConnection();
                
                MySqlCommand commandEntrants = new MySqlCommand("SELECT * FROM entrant", db.getConnection());
                MySqlDataReader readerEntrants = commandEntrants.ExecuteReader();
                while (readerEntrants.Read())
                {
                    dataGridViewEntrants.Rows.Add(
                            readerEntrants["entrant_id"],
                            readerEntrants["surname"],
                            readerEntrants["name"],
                            readerEntrants["last_name"],
                            readerEntrants["birthday"],
                            readerEntrants["phone_number"],
                            readerEntrants["email"],
                            readerEntrants["passport"],
                            readerEntrants["document_number"],
                            readerEntrants["date_of_issue"],
                            readerEntrants["code_1"],
                            readerEntrants["code_2"],
                            readerEntrants["code_3"],
                            readerEntrants["oper_id"],
                            readerEntrants["filing_date"]
                        );
                }
                readerEntrants.Close();

                for (int i = 0; i < dataGridViewEntrants.RowCount - 1; i++)
                    if (dataGridViewEntrants.Rows[i].Cells[3].Value is null)
                        dataGridViewEntrants.Rows[i].Cells[3].Value = " ";

                textBoxSurnameEntrantsForSearch.Text = "";

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

        // событие: нажатие на кнопку "Обновить информацию" во вкладке общего списка направлений подготовки (специальностей)
        private void buttonRefreshSpecialities_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            dataGridViewSpecialities.Rows.Clear();
            try
            {
                db.openConnection();
                
                MySqlCommand commandSpecialities = new MySqlCommand("SELECT * FROM speciality WHERE speciality_code != '-' AND speciality_code != '—'", db.getConnection());
                MySqlDataReader readerSpecialities = commandSpecialities.ExecuteReader();
                while (readerSpecialities.Read())
                {
                    dataGridViewSpecialities.Rows.Add(
                        readerSpecialities["speciality_code"],
                        readerSpecialities["speciality_name"],
                        readerSpecialities["number_of_places"],
                        readerSpecialities["passing_score"],
                        readerSpecialities["cost"],
                        readerSpecialities["exam_1"],
                        readerSpecialities["exam_2"],
                        readerSpecialities["exam_3"]
                        );
                }
                readerSpecialities.Close();

                textBoxSpecialityForSearch.Text = "";

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

        // событие: нажатие на кнопку "Обновить информацию" во вкладке общего списка результатов вступительных испытаний
        private void buttonRefreshScores_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            
            dataGridViewScores.Rows.Clear();
            try
            {
                db.openConnection();

                MySqlCommand commandScores = new MySqlCommand("SELECT * FROM exams", db.getConnection());
                MySqlDataReader readerScores = commandScores.ExecuteReader();

                while (readerScores.Read())
                {
                    dataGridViewScores.Rows.Add(
                        readerScores["document_number"],
                        readerScores["russian_language"],
                        readerScores["maths"],
                        readerScores["information_technologies"],
                        readerScores["physics"],
                        readerScores["chemistry"],
                        readerScores["biology"],
                        readerScores["social_science"],
                        readerScores["history"],
                        readerScores["foreign_language"],
                        readerScores["literature"],
                        readerScores["geography"],
                        readerScores["personal_achievements"],
                        readerScores["comments"]
                        );
                }

                for (int i = 0; i < dataGridViewScores.RowCount; i++)
                    for (int j = 0; j < dataGridViewScores.ColumnCount - 2; j++)
                        if (dataGridViewScores.Rows[i].Cells[j].Value is 0)
                            dataGridViewScores.Rows[i].Cells[j].Value = null;

                readerScores.Close();

                textBoxDocumentForSearch.Text = "";

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

        // событие: нажатие на кнопку "Показать конкурсный список" во вкладке "Конкурсные списки"
        private void buttonShowCompetition_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();

            dataGridViewCompetition.Rows.Clear();
            try
            {
                db.openConnection();

                string code = textBoxCodeForResult.Text;
                
                MySqlCommand existence = new MySqlCommand("SELECT count(*) FROM speciality WHERE speciality_code = @code", db.getConnection());
                existence.Parameters.Add(new MySqlParameter("@code", code));
                int count = Convert.ToInt32(existence.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Такого направления подготовки (специальности) нет!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sum = 0;
                textBoxSpecialityName.Text = "";
                textBoxSpecialityPlaces.Text = "";
                textBoxSpecialityPassing.Text = "";
                textBoxCurrentPassingScore.Text = "";
                textBoxAverageScore.Text = "";
                textBoxCost.Text = "";

                MySqlCommand getSpecialityExam2 = new MySqlCommand("SELECT exam_2 FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityExam2.Parameters.Add(new MySqlParameter("@code", code));
                object value_exam2 = getSpecialityExam2.ExecuteScalar();
                subject2_competition.HeaderText = value_exam2.ToString();

                MySqlCommand getSpecialityExam3 = new MySqlCommand("SELECT exam_3 FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityExam3.Parameters.Add(new MySqlParameter("@code", code));
                object value_exam3 = getSpecialityExam3.ExecuteScalar();
                subject3_competition.HeaderText = value_exam3.ToString();

                string exam_2 = "";
                string exam_3 = "";
                
                switch(value_exam2)
                {
                    case "Математика":
                        exam_2 = "maths";
                        break;
                    case "Информатика и ИКТ":
                        exam_2 = "information_technologies";
                        break;
                    case "Физика":
                        exam_2 = "physics";
                        break;
                    case "Химия":
                        exam_2 = "chemistry";
                        break;
                    case "Биология":
                        exam_2 = "biology";
                        break;
                    case "Обществознание":
                        exam_2 = "social_science";
                        break;
                    case "История":
                        exam_2 = "history";
                        break;
                    case "Иностранный язык":
                        exam_2 = "foreign_language";
                        break;
                    case "Литература":
                        exam_2 = "literature";
                        break;
                    case "География":
                        exam_2 = "geography";
                        break;
                }

                switch (value_exam3)
                {
                    case "Математика":
                        exam_3 = "maths";
                        break;
                    case "Информатика и ИКТ":
                        exam_3 = "information_technologies";
                        break;
                    case "Физика":
                        exam_3 = "physics";
                        break;
                    case "Химия":
                        exam_3 = "chemistry";
                        break;
                    case "Биология":
                        exam_3 = "biology";
                        break;
                    case "Обществознание":
                        exam_3 = "social_science";
                        break;
                    case "История":
                        exam_3 = "history";
                        break;
                    case "Иностранный язык":
                        exam_3 = "foreign_language";
                        break;
                    case "Литература":
                        exam_3 = "literature";
                        break;
                    case "География":
                        exam_3 = "geography";
                        break;
                }

                MySqlCommand commandCompetitionEntrants = new MySqlCommand("SELECT ent.surname, ent.name, ent.last_name, ex.russian_language, ex." + exam_2 + ", ex." + exam_3 + ", ex.personal_achievements, (ex.russian_language + " + exam_2 + " + " + exam_3 + " + ex.personal_achievements) AS sum_competition FROM entrant AS ent JOIN exams AS ex ON ent.document_number = ex.document_number WHERE ent.code_1 = @code OR ent.code_2 = @code OR ent.code_3 = @code ORDER BY sum_competition DESC", db.getConnection());
                commandCompetitionEntrants.Parameters.Add(new MySqlParameter("@code", code));
                MySqlDataReader readerEntrantsData = commandCompetitionEntrants.ExecuteReader();
                int number = 0;
                while (readerEntrantsData.Read())
                {
                    number++;
                    dataGridViewCompetition.Rows.Add(
                        number,
                        readerEntrantsData["surname"],
                        readerEntrantsData["name"],
                        readerEntrantsData["last_name"],
                        readerEntrantsData["russian_language"],
                        readerEntrantsData[exam_2],
                        readerEntrantsData[exam_3],
                        readerEntrantsData["personal_achievements"],
                        readerEntrantsData["sum_competition"]
                        );
                }
                readerEntrantsData.Close();

                MySqlCommand getSpecialityName = new MySqlCommand("SELECT speciality_name FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityName.Parameters.Add(new MySqlParameter("@code", code));
                object value_name = getSpecialityName.ExecuteScalar();
                textBoxSpecialityName.Text = value_name.ToString();

                MySqlCommand getSpecialityPlaces = new MySqlCommand("SELECT number_of_places FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityPlaces.Parameters.Add(new MySqlParameter("@code", code));
                object value_places = getSpecialityPlaces.ExecuteScalar();
                textBoxSpecialityPlaces.Text = value_places.ToString();

                MySqlCommand getSpecialityPassing = new MySqlCommand("SELECT passing_score FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityPassing.Parameters.Add(new MySqlParameter("@code", code));
                object value_passing = getSpecialityPassing.ExecuteScalar();
                textBoxSpecialityPassing.Text = value_passing.ToString();

                if (dataGridViewCompetition.RowCount == 1)
                    textBoxCurrentPassingScore.Text = "0";
                else if (dataGridViewCompetition.RowCount <= Convert.ToInt32(value_places))
                    textBoxCurrentPassingScore.Text = dataGridViewCompetition.Rows[dataGridViewCompetition.RowCount - 2].Cells[dataGridViewCompetition.ColumnCount - 1].Value.ToString();
                else
                    textBoxCurrentPassingScore.Text = dataGridViewCompetition.Rows[Convert.ToInt32(value_places) - 1].Cells[dataGridViewCompetition.ColumnCount - 1].Value.ToString();

                if (dataGridViewCompetition.RowCount == 1)
                    textBoxAverageScore.Text = "0";
                else
                {
                    for (int i = 0; i < dataGridViewCompetition.RowCount - 1; i++)
                        sum += Convert.ToInt32(dataGridViewCompetition.Rows[i].Cells[dataGridViewCompetition.ColumnCount - 1].Value);
                    textBoxAverageScore.Text = (Math.Round((float)sum / (float)(dataGridViewCompetition.RowCount - 1))).ToString();
                }

                MySqlCommand getSpecialityCost = new MySqlCommand("SELECT cost FROM speciality WHERE speciality_code = @code", db.getConnection());
                getSpecialityCost.Parameters.Add(new MySqlParameter("@code", code));
                object value_cost = getSpecialityCost.ExecuteScalar();
                textBoxCost.Text = value_cost.ToString().Substring(0, value_cost.ToString().Length - 3) + " " + value_cost.ToString().Substring(value_cost.ToString().Length - 3, 3) + " ₽";

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

        // событие: нажатие на кнопку поиска во вкладке "Направления подготовки (специальности)"
        private void buttonSpecialitySearch_Click(object sender, EventArgs e)
        {
            toSearch(dataGridViewSpecialities, textBoxSpecialityForSearch, 0);
        }

        // событие: нажатие на кнопку поиска во вкладке "Результаты вступительных испытаний"
        private void buttonScoresSearch_Click(object sender, EventArgs e)
        {
            toSearch(dataGridViewScores, textBoxDocumentForSearch, 0);
        }

        // событие: нажатие на кнопку поиска во вкладке "Абитуриенты"
        private void buttonSearchEntrants_Click(object sender, EventArgs e)
        {
            toSearch(dataGridViewEntrants, textBoxSurnameEntrantsForSearch, 1);
        }

        // событие: нажатие на кнопку поиска во вкладке "Сотрудники"
        private void buttonSearchWorkers_Click(object sender, EventArgs e)
        {
            toSearch(dataGridViewWorkers, textBoxSurnameWorkersForSearch, 3);
        }

        // событие: нажатие на кнопку поиска во вкладке "Конкурсные списки"
        private void buttonSearchCompetition_Click(object sender, EventArgs e)
        {
            toSearch(dataGridViewCompetition, textBoxSurnameForCompetitionSearch, 1);
        }

        // функция: поиск в таблице по заданному параметру
        private void toSearch(DataGridView dataGridView, TextBox textBox, int j)
        {
            try
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                    dataGridView.Rows[i].Selected = false;

                if (textBox.Text == "")
                {
                    MessageBox.Show("Введите данные для поиска.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int index = 0;
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                        {
                            dataGridView.Rows[i].Selected = true;
                            if (index != 0) continue;
                            else index = i;
                        }
                }

                dataGridView.FirstDisplayedScrollingRowIndex = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // функция (перегруженная): поиск в таблице по заданному параметру
        private void toSearch(DataGridView dataGridView, MaskedTextBox textBox, int j)
        {
            try
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                    dataGridView.Rows[i].Selected = false;

                if (textBox.Text == "__.__.__")
                {
                    MessageBox.Show("Введите данные для поиска.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                        if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                            dataGridView.Rows[i].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // событие: нажатие на кнопку "Очистить поля" во вкладке "Конкурсные списки"
        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridViewCompetition.Rows.Clear();
            textBoxCodeForResult.Text = "";
            textBoxSpecialityName.Text = "";
            textBoxSpecialityPlaces.Text = "";
            textBoxSpecialityPassing.Text = "";
            textBoxCurrentPassingScore.Text = "";
            textBoxAverageScore.Text = "";
            textBoxCost.Text = "";
            textBoxSurnameForCompetitionSearch.Text = "";
        }

        // функция: заполнение полей и таблицы личного кабинета сотрудника
        public void toFillCabinetWorker()
        {
            DataBase db = new DataBase();

            dataGridViewDataWorker.Rows.Clear();
            try
            {
                db.openConnection();

                MySqlCommand commandFillCabinet = new MySqlCommand("SELECT worker_id, password, hiring_date, phone_number, email FROM worker WHERE worker_id = @id", db.getConnection());
                commandFillCabinet.Parameters.Add(new MySqlParameter("@id", login));
                MySqlDataReader reader = commandFillCabinet.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewDataWorker.Rows.Add(
                        reader["worker_id"],
                        reader["password"],
                        reader["hiring_date"],
                        reader["phone_number"],
                        reader["email"]
                        );
                }
                reader.Close();

                MySqlCommand getSurname = new MySqlCommand("SELECT surname FROM worker WHERE worker_id = @code", db.getConnection());
                MySqlCommand getName = new MySqlCommand("SELECT name FROM worker WHERE worker_id = @code", db.getConnection());
                MySqlCommand getLastName = new MySqlCommand("SELECT last_name FROM worker WHERE worker_id = @code", db.getConnection());
                getSurname.Parameters.Add(new MySqlParameter("@code", login));
                getName.Parameters.Add(new MySqlParameter("@code", login));
                getLastName.Parameters.Add(new MySqlParameter("@code", login));
                object value_surname = getSurname.ExecuteScalar();
                object value_name = getName.ExecuteScalar();
                object value_last_name = getLastName.ExecuteScalar();
                labelNameWorker.Text = value_surname.ToString() + " " + value_name.ToString() + " " + value_last_name.ToString();

                MySqlCommand getUserTypeName = new MySqlCommand("SELECT u_t.type_name FROM users_type AS u_t JOIN worker AS w ON w.user_type = u_t.type_id WHERE w.worker_id = @code", db.getConnection());
                getUserTypeName.Parameters.Add(new MySqlParameter("@code", login));
                object value_type_name = getUserTypeName.ExecuteScalar();
                labelUserTypeWorker.Text = value_type_name.ToString();

                MySqlCommand getUserType = new MySqlCommand("SELECT user_type FROM worker WHERE worker_id = @code", db.getConnection());
                getUserType.Parameters.Add(new MySqlParameter("@code", login));
                object value_type = getUserType.ExecuteScalar();
                if (Convert.ToInt32(value_type) == 1) pictureBoxWorker.Image = Properties.Resources.admin;
                else if (Convert.ToInt32(value_type) == 2) pictureBoxWorker.Image = Properties.Resources.oper;

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

        // функция: заполнение полей и таблицы личного кабинета абитуриента
        public void toFillCabinetEntrant()
        {
            DataBase db = new DataBase();

            dataGridViewDataEntrant.Rows.Clear();
            dataGridViewScoresEntrant.Rows.Clear();
            try
            {
                db.openConnection();

                MySqlCommand commandFillCabinet = new MySqlCommand("SELECT entrant_id, birthday, phone_number, email, passport, document_number, date_of_issue, code_1, code_2, code_3, oper_id, filing_date FROM entrant WHERE entrant_id = @id", db.getConnection());
                commandFillCabinet.Parameters.Add(new MySqlParameter("@id", login));
                MySqlDataReader reader = commandFillCabinet.ExecuteReader();
                while (reader.Read())
                {
                    dataGridViewDataEntrant.Rows.Add(
                        reader["entrant_id"],
                        reader["birthday"],
                        reader["phone_number"],
                        reader["email"],
                        reader["passport"],
                        reader["document_number"],
                        reader["date_of_issue"],
                        reader["code_1"],
                        reader["code_2"],
                        reader["code_3"],
                        reader["oper_id"],
                        reader["filing_date"]
                        );
                }
                reader.Close();

                MySqlCommand commandFillScores = new MySqlCommand("SELECT * FROM exams AS ex JOIN entrant AS ent ON ex.document_number = ent.document_number WHERE ent.entrant_id = @id", db.getConnection());
                commandFillScores.Parameters.Add(new MySqlParameter("@id", login));
                MySqlDataReader readerScores = commandFillScores.ExecuteReader();
                while (readerScores.Read())
                {
                    dataGridViewScoresEntrant.Rows.Add(
                        readerScores["russian_language"],
                        readerScores["maths"],
                        readerScores["information_technologies"],
                        readerScores["physics"],
                        readerScores["chemistry"],
                        readerScores["biology"],
                        readerScores["social_science"],
                        readerScores["history"],
                        readerScores["foreign_language"],
                        readerScores["literature"],
                        readerScores["geography"],
                        readerScores["personal_achievements"],
                        readerScores["comments"]
                        );
                }
                readerScores.Close();

                MySqlCommand getSurname = new MySqlCommand("SELECT surname FROM entrant WHERE entrant_id = @code", db.getConnection());
                MySqlCommand getName = new MySqlCommand("SELECT name FROM entrant WHERE entrant_id = @code", db.getConnection());
                MySqlCommand getLastName = new MySqlCommand("SELECT last_name FROM entrant WHERE entrant_id = @code", db.getConnection());
                getSurname.Parameters.Add(new MySqlParameter("@code", login));
                getName.Parameters.Add(new MySqlParameter("@code", login));
                getLastName.Parameters.Add(new MySqlParameter("@code", login));
                object value_surname = getSurname.ExecuteScalar();
                object value_name = getName.ExecuteScalar();
                object value_last_name = getLastName.ExecuteScalar();
                labelNameEntrant.Text = value_surname.ToString() + " " + value_name.ToString() + " " + value_last_name.ToString();

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

        // событие: нажатие на кнопку "Изменить данные" в личном кабинете сотрудника
        private void buttonChangeDataWorker_Click(object sender, EventArgs e)
        {
            string id = dataGridViewDataWorker.Rows[0].Cells[0].Value.ToString();
            string password = dataGridViewDataWorker.Rows[0].Cells[1].Value.ToString();
            string telNo = dataGridViewDataWorker.Rows[0].Cells[3].Value.ToString();
            string email = dataGridViewDataWorker.Rows[0].Cells[4].Value.ToString();
            ChangingWorkerData changingWorkerData = new ChangingWorkerData(this, userType, id, password, telNo, email);
            changingWorkerData.Show(this);
        }

        // событие: нажатие на кнопку "Изменить данные" в личном кабинете абитуриента
        private void buttonChangeEntrantData_Click(object sender, EventArgs e)
        {
            string id = dataGridViewDataEntrant.Rows[0].Cells[0].Value.ToString();
            string telNo = dataGridViewDataEntrant.Rows[0].Cells[2].Value.ToString();
            string email = dataGridViewDataEntrant.Rows[0].Cells[3].Value.ToString();
            ChangingEntrantData changingEntrantData = new ChangingEntrantData(this, userType, id, telNo, email);
            changingEntrantData.Show(this);
        }

        // событие: однократное нажатие мышью на поле для ввода кода направления подготовки (специальности) (__.__.__) (MaskedTextBox)
        private void textBoxCodeForResult_MouseClick(object sender, MouseEventArgs e)
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
        private void textBoxSpecialityForSearch_MouseClick(object sender, MouseEventArgs e)
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