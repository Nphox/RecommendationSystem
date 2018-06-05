using BoardGamesExtractor;
using RecommendationSystem.Data;
using System.Collections.Generic;

namespace RecommendationSystem.BL
{
    public interface IRecommendationProvider
    {
        GameParams[] RecommendGames(
            List<GameParams> games, 
            GameParams templateGame, 
            int numberSimilarGames, 
            bool usersChoice);
    }
}
