using RecommendationSystem.Data;
using System;
using System.Collections.Generic;
using RecommendationSystem.BL;
using System.Data.SqlClient;
using BoardGamesExtractor;

namespace RecommendationSystem
{
    class Program
    {
        public static void GamesInit(List<Game> games)
        {
            var template = new Game(0, "***", 8, 2, 90, 16, 7, Universe.Pirates, Character.Strategy, 0);

            games.Add(new Game(1, "Pirates", 4, 2, 90, 16, 7, Universe.Pirates, Character.Strategy, 25));
            games.Add(new Game(2, "North Sea", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 50));
            games.Add(new Game(3, "Gold & Silver", 4, 2, 90, 16, 7, Universe.Pirates, Character.Detective, 25));

            games.Add(new Game(4, "Old World", 4, 2, 90, 16, 7, Universe.Vikings, Character.Strategy, 25));
            games.Add(new Game(5, "Cold Blood", 4, 2, 90, 16, 7, Universe.Vikings, Character.RolePlaying, 50));
            games.Add(new Game(6, "Two Swords", 4, 2, 90, 16, 7, Universe.Vikings, Character.Detective, 50));
        }

        public static void LoadGames(List<GameParams> list)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\RecommendationSystem\RecommendationSystem\Database1.mdf;Integrated Security=True; ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Games]", sqlConnection);
            try
            {
                sqlDataReader = command.ExecuteReader();
                int i = 0;
                while (sqlDataReader.Read())
                {
                    list.Add(new GameParams(false));
                    list[i].Title = Convert.ToString(sqlDataReader["Title"]);
                    list[i].Complexity = Convert.ToInt32(sqlDataReader["Complexity"]);
                    list[i].Activity = Convert.ToInt32(sqlDataReader["Complexity"]);
                    list[i].Planning = Convert.ToInt32(sqlDataReader["Planning"]);
                    list[i].Timing.MinTime = Convert.ToInt32(sqlDataReader["MinTime"]);
                    list[i].Timing.MaxTime = Convert.ToInt32(sqlDataReader["MaxTime"]);
                    list[i].Age.MinAge = Convert.ToInt32(sqlDataReader["MinAge"]);
                    list[i].Age.MaxAge = Convert.ToInt32(sqlDataReader["MaxAge"]);
                    list[i].Players.MinPlayers = Convert.ToInt32(sqlDataReader["MinPlayers"]);

                    SqlDataReader tagsReader = null;
                    SqlCommand tagsCmd = new SqlCommand("SELECT Tag FROM [Tags] where Title = " + Convert.ToString(list[i].Title), sqlConnection);
                    tagsReader = tagsCmd.ExecuteReader();

                    while (tagsReader.Read())
                    {
                        list[i].Tags.Add(Convert.ToString(tagsReader["Tag"]));
                    }
                   
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            sqlConnection.Close();
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
            List<GameParams> list = new List<GameParams>();
            LoadGames(list);    
            foreach(GameParams g in list)
            {
                Console.WriteLine(g.Title);
            }

            Console.WriteLine("Countt: " + list.Count);

            foreach(string s in list[0].Tags)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
