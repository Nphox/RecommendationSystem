using System;
using System.Collections.Generic;
using System.Linq;
using BoardGamesExtractor;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class RecommendationProvider : IRecommendationProvider
    {
        public List<Game> RecommendGames(
            List<GameParams> games, 
            GameParams templateGame, 
            int numberSimilarGames, 
            Dictionary<string, int> tagDict)
        {
            ISimilarityCalculator calculator = new SimilarityCalculator();
            List<Game> boxingGames = new List<Game>();
            double coef;
            foreach (var game in games)
            {
                coef = calculator.CalculateSimilarity(
                    game,
                    templateGame,
                    Relations.Universes,
                    Relations.Characters,
                    Relations.ImportanceUniverse,
                    Relations.ImportanceCharacter,
                    tagDict);

                boxingGames.Add(new Game(game, coef));
            }
            boxingGames.Sort();       
            var countGames = numberSimilarGames < games.Count ? numberSimilarGames : games.Count;
            boxingGames = boxingGames.GetRange(0, countGames);
            return boxingGames;
        }
    }
}
