using RecommendationSystem.Data;
using System;
using System.Collections.Generic;
using RecommendationSystem.BL;
using System.Data.SqlClient;

namespace RecommendationSystem
{
    class Program
    {
        public static void GamesInit(List<Game> games)
        {
            games.Add(new Game(1, "Pirates", 4, 2, 90, 16, 7, Universe.Pirates, Character.Strategy, 25));
            games.Add(new Game(2, "North Sea", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 50));
            games.Add(new Game(3, "Gold & Silver", 4, 2, 90, 16, 7, Universe.Pirates, Character.Detective, 25));

            games.Add(new Game(4, "Old World", 4, 2, 90, 16, 7, Universe.Vikings, Character.Strategy, 25));
            games.Add(new Game(5, "Cold Blood", 4, 2, 90, 16, 7, Universe.Vikings, Character.RolePlaying, 50));
            games.Add(new Game(6, "Two Swords", 4, 2, 90, 16, 7, Universe.Vikings, Character.Detective, 50));
        }

        public static void Insert(List<Game> list)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\RecommendationSystem\RecommendationSystem\Database1.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [Games] (Id, Name, Difficulty)VALUES(@Id, @Name, @Difficulty)", sqlConnection);

            command.Parameters.AddWithValue("Id", list[0].Id);
            command.Parameters.AddWithValue("Name", list[0].Name);
            command.Parameters.AddWithValue("Difficulty", list[0].Difficulty);

            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);

            sqlConnection.Close();
        }

        public static void Select()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\RecommendationSystem\RecommendationSystem\Database1.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Games]", sqlConnection);
            try
            {
                sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine(Convert.ToString(sqlDataReader["Id"]) + " " + Convert.ToString(sqlDataReader["Name"]) + " " + Convert.ToString(sqlDataReader["Difficulty"]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            sqlConnection.Close();
        }

        static void Main(string[] args)
        {
            List<Game> list = new List<Game>();
            GamesInit(list);

            #region database
            //Insert(list);
            Select();
            #endregion

            #region main 

            var template = new Game(0, "***", 8, 2, 90, 16, 7, Universe.Pirates, Character.Strategy, 0);

            IRecommendationProvider provider = new RecommendationProvider();
            var sortedGames = provider.RecommendGames(list, template, 6, true);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(sortedGames[i].Id + " " + sortedGames[i].CoefSimilarity);
            }

            Console.ReadLine();

            #endregion

        }
    }
}
