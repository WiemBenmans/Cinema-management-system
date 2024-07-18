using MySql.Data.MySqlClient;

namespace cinema.data
{
    public class connexion
    {
        private string connectionString;
        private MySqlConnection connection;

        public connexion(string connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            this.connection.Open();
        }

        public void Close()
        {
            this.connection.Close();
        }

        public MySqlCommand CreateCommand(string commandText)
        {
            return new MySqlCommand(commandText, this.connection);
        }
    }
}

