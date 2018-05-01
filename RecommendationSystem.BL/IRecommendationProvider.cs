using RecommendationSystem.Data;
using System.Collections.Generic;

namespace RecommendationSystem.BL
{
    public interface IRecommendationProvider
    {
        Game[] RecommendGames(List<Game> games, Game templateGame, int numberSimilarGames, bool usersChoice);
    }
}
