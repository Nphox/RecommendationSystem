using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class RecommenderProvider : IRecommendationProvider
    {
        public Game[] RecommendGames(Game[] games, Game templateGame, int numberSimilarGames)
        {
            throw new NotImplementedException();
        }
    }
}
