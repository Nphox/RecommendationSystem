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
        public static void LoadGames(List<GameParams> list)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\RecommendationSystem\RecommendationSystem\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand gamesCmd = new SqlCommand("SELECT * FROM [Games]", sqlConnection);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                sqlDataReader = gamesCmd.ExecuteReader();
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

                    #region load tags
                    SqlDataReader tagsReader = null;
                    string valueAttribute = Convert.ToString(list[i].Title);
                    
                    int index = valueAttribute.IndexOf("'");
                    if (index > 0)
                    {
                        valueAttribute = valueAttribute.Insert(index, "'");
                        index = valueAttribute.IndexOf("'", index + 2);
                        if (index > 0)
                        {
                            valueAttribute = valueAttribute.Insert(index, "'");
                        }                         
                    }

                    string query = "SELECT Tag FROM [Tags] where Title = " + "N" + "'" + valueAttribute + "'";
                    SqlCommand tagsCmd = new SqlCommand(query, sqlConnection);
                    tagsReader = tagsCmd.ExecuteReader();
                    
                    while (tagsReader.Read())
                    {
                        list[i].Tags.Add(Convert.ToString(tagsReader["Tag"]));
                    }
                    #endregion

                    #region load categories
                    SqlDataReader categReader = null;

                    query = "SELECT Categories FROM [Categories] where Title = " + "N" + "'" + valueAttribute + "'";
                    SqlCommand categCmd = new SqlCommand(query, sqlConnection);
                    categReader = categCmd.ExecuteReader();

                    while (categReader.Read())
                    {
                        list[i].Categories.Add(Convert.ToString(categReader["Categories"]));
                    }
                    #endregion

                    #region load thematic
                    SqlDataReader thematicReader = null;

                    query = "SELECT Thematic FROM [Thematic] where Title = " + "N" + "'" + valueAttribute + "'";
                    SqlCommand thematicCmd = new SqlCommand(query, sqlConnection);
                    thematicReader = thematicCmd.ExecuteReader();

                    while (thematicReader.Read())
                    {
                        list[i].Thematic.Add(Convert.ToString(thematicReader["Thematic"]));
                    }
                    #endregion

                    #region load series
                    SqlDataReader seriesReader = null;

                    query = "SELECT Series FROM [Series] where Title = " + "N" + "'" + valueAttribute + "'";
                    SqlCommand seriesCmd = new SqlCommand(query, sqlConnection);
                    seriesReader = seriesCmd.ExecuteReader();

                    while (seriesReader.Read())
                    {
                        list[i].Series.Add(Convert.ToString(seriesReader["Series"]));
                    }
                    #endregion

                    i++;
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
                Console.WriteLine(g.Title + " : " + g.Tags.Count + " tags");
                Console.WriteLine(g.Title + " : " + g.Categories.Count + " categories"); 
                Console.WriteLine(g.Title + " : " + g.Thematic.Count + " thematic");
                Console.WriteLine(g.Title + " : " + g.Series.Count + " series");
            }

            Console.WriteLine("Count of games: " + list.Count);

            Console.ReadLine();
        }
    }
}
