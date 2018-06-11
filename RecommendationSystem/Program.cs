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
        public static void PrintGame(Game game)
        {
            Console.WriteLine("Min age: " + game.GameParams.Age.MinAge);
            Console.WriteLine("Min time: " + game.GameParams.Timing.MinTime);
            Console.WriteLine("Activity: " + game.GameParams.Activity);
            Console.WriteLine("Complexity: " + game.GameParams.Complexity);
            Console.WriteLine("Tags: " );
            foreach(string s in game.GameParams.Tags)
            {
                Console.WriteLine(s);
            }
        }
        public static void LoadUniqueTags(List<string> conteiner, string nameTable, string nameAttribute)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\RecommendationSystem\RecommendationSystem\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT " + nameAttribute +" FROM [" + nameTable + "]", sqlConnection);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    conteiner.Add(Convert.ToString(sqlDataReader[nameAttribute]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            sqlConnection.Close();
        }
        public static void PrintGameParams(List<GameParams> list)
        {
            foreach (GameParams g in list)
            {
                Console.WriteLine(g.Title + " : " + g.Tags.Count + " tags");
                Console.WriteLine(g.Title + " : " + g.Categories.Count + " categories");
                Console.WriteLine(g.Title + " : " + g.Thematic.Count + " thematic");
                Console.WriteLine(g.Title + " : " + g.Series.Count + " series");
            }
            Console.WriteLine("Count of games: " + list.Count);
        }
        public static void PrintGames(List<Game> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine("Coef:       " + item.CoefSimilarity);
                Console.WriteLine("Title:      " + item.GameParams.Title);
                Console.WriteLine("MinAge:    " + item.GameParams.Age.MinAge);
                Console.WriteLine("MinTime:    " + item.GameParams.Timing.MinTime);
                Console.WriteLine("Complexity: " + item.GameParams.Complexity);
                Console.WriteLine("Activity:   " + item.GameParams.Activity);
                foreach (string s in item.GameParams.Tags)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
        }
        public static void PrintListString(List<string> list)
        {
            foreach(string s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Count tags: " + list.Count);
        }
        public static Game CreateTemplate(List<string> allTags, List<string> allCategories, List<string> allThematic, List<string> allSeries)
        {
            Game template = new Game();
            Console.Write("Min age: "); template.GameParams.Age.MinAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Min time: "); template.GameParams.Timing.MinTime = Convert.ToInt32(Console.ReadLine());
            Console.Write("Activity: "); template.GameParams.Activity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Complexity: "); template.GameParams.Complexity = Convert.ToInt32(Console.ReadLine());
            string[] arrayTags = allTags.ToArray();
            for(int i = 0; i < arrayTags.Length; i++)
            {
                Console.WriteLine(i + " " + arrayTags[i]);
            }
            int choice = 0;
            while(choice != -1)
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice != -1)
                {
                    template.GameParams.Tags.Add(arrayTags[choice]);
                }
            }
            return template;
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> tagDict = new Dictionary<string, int>();
            tagDict.Add("Игры для взрослых                                 ", 1);
            tagDict.Add("Игры для компании", 2);

            List<GameParams> list = new List<GameParams>(); LoadGames(list);
            List<string> allTags = new List<string>(); LoadUniqueTags(allTags, "Tags", "Tag");
            List<string> allCategories = new List<string>(); LoadUniqueTags(allCategories, "Categories", "Categories");
            List<string> allSeries = new List<string>(); LoadUniqueTags(allSeries, "Series", "Series");
            List<string> allThematic = new List<string>(); LoadUniqueTags(allThematic, "Thematic", "Thematic");

            IRecommendationProvider provider = new RecommendationProvider();
            Game template = CreateTemplate(allTags, allCategories, allThematic, allSeries);
            PrintGame(template);
            List<Game> result = provider.RecommendGames(list, template.GameParams, 10, tagDict);
            PrintGames(result);

            Console.ReadLine();
        }
    }
}
