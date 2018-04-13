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
            CalculatedGame[] calculatedGames = new CalculatedGame[games.Length];

            ISimilarityCalculator calculator = new SimilarityCalculator();

            for (int i = 0; i < games.Length; i++)
            {
                calculatedGames[i].SetGame(games[i]);
                calculatedGames[i].SetCoef(calculator.CalculateSimilarity(games[i], templateGame)); 
            }

            int countGames = numberSimilarGames < games.Length ? numberSimilarGames : games.Length;

            Game[] similarGames = new Game[countGames];

            GameSorter gameSorter = new GameSorter();

            gameSorter.QuickSort(calculatedGames, 0, calculatedGames.Length);

            for (int i = 0; i < countGames; i++)
            {
                similarGames[i] = calculatedGames[i].GetGame();
            }

            return similarGames;
        }
    }
}
