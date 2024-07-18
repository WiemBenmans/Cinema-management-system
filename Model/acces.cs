using cinema.data;
using MySql.Data.MySqlClient;

namespace cinema.Model
{
    public class acces
    {
        private connexion connection;

        public acces(string connectionString)
        {
            connection = new connexion(connectionString);
        }

        public List<FilmDTO> GetFilms()
        {
            List<FilmDTO> films = new List<FilmDTO>();

            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand("SELECT * FROM Film");
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FilmDTO myModel = new FilmDTO();
                    myModel.idFilm = reader.GetInt32(0);
                    myModel.nom = reader.GetString(1);
                    myModel.categorie = reader.GetString(2);

                    films.Add(myModel);
                }
            }
            finally
            {
                connection.Close();
            }

            return films;
        }
    }
}
