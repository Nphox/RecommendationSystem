using RecommendationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.BL
{
    public interface IRecommendationProvider
    {
        Game[] RecommendGames(Game[] games, Game templateGame, int numberSimilarGames);
    }
}
