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
        public Game[] RecommendGames(Game[] games, Game templateGame, int numberSimilarGames)
        {
            var calculatedGames = new ArrayList();

            ISimilarityCalculator calculator = new SimilarityCalculator();

            for (var i = 0; i < games.Length; i++)
            {
                calculatedGames.Add(new CalculatedGame(games[i], calculator.CalculateSimilarity(games[i], templateGame))); 
            }

            var countGames = numberSimilarGames < games.Length ? numberSimilarGames : games.Length;

            var similarGames = new Game[countGames];



            var j = 0;
            foreach (CalculatedGame game in calculatedGames)
            {
                similarGames[j++] = game.Game;
            }

            return similarGames;
        }
    }
}
