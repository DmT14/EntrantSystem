using MySql.Data.MySqlClient;

namespace EntrantSystem
{
    // Класс DataBase — класс для работы с БД
    class DataBase
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password='';database=entrant");

        // функция: открытие соединения с БД
        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
        }

        // функция: закрытие соединения с БД
        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        }

        // функция: получение соединения с БД
        public MySqlConnection getConnection()
        {
            return conn;
        }
    }
}