using BoardGamesExtractor;
using RecommendationSystem.Data;
using System.Collections.Generic;

namespace RecommendationSystem.BL
{
    public interface IRecommendationProvider
    {
        List<Game> RecommendGames(
            List<GameParams> games, 
            GameParams templateGame, 
            int numberSimilarGames,
            Dictionary<string, int> tagDict);
    }
}
