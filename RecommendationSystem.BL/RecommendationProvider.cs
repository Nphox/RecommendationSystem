using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class RecommendationProvider : IRecommendationProvider
    {
        public Game[] RecommendGames(Game[] games, Game templateGame, int numberSimilarGames)
        {
            double[] arrayCoefficientsSimilarity = new double[games.Length];

            ISimilarityCalculator calculator = new SimilarityCalculator();

            for (int i = 0; i < games.Length; i++)
            {
                arrayCoefficientsSimilarity[i] = calculator.CalculateSimilarity(games[i], templateGame);
            }

            int countGames = numberSimilarGames < games.Length ? numberSimilarGames : games.Length;

            Game[] similarGames = new Game[countGames];

            GameSorter gameSorter = new GameSorter();

            gameSorter.QuickSort(arrayCoefficientsSimilarity, games, 0, games.Length);

            for (int i = 0; i < countGames; i++)
            {
                similarGames[i] = games[i];
            }

            return similarGames;
        }
    }
}
