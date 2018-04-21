using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class RecommendationProvider : IRecommendationProvider
    {
        public Game[] RecommendGames(List<Game> games, Game templateGame, int numberSimilarGames)
        {
            ISimilarityCalculator calculator = new SimilarityCalculator();

            foreach (var game in games)
            {
                game.CoefSimilarity = calculator.CalculateSimilarity(game, templateGame);
            }

            //сортировка по коэффициентам
            games.Sort();

            var countGames = numberSimilarGames < games.Count ? numberSimilarGames : games.Count;

            var similarGames = new Game[countGames];

            var j = 0;
            foreach (var game in games)
            {
                similarGames[j++] = game;
            }

            return similarGames;
        }
    }
}
