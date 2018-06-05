using System.Collections.Generic;
using BoardGamesExtractor;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class RecommendationProvider : IRecommendationProvider
    {
        public GameParams[] RecommendGames(List<GameParams> games, GameParams templateGame, int numberSimilarGames, bool usersChoice)
        {
            ISimilarityCalculator calculator = new SimilarityCalculator();

            foreach (var game in games)
            {
                game.CoefSimilarity = calculator.CalculateSimilarity(game, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);
            }

            if (usersChoice)
            {
                calculator.RecalculateWithUsersChoice(games);
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
