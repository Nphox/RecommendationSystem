using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class SimilarityCalculator : ISimilarityCalculator
    {
        public double CalculateSimilarity(Game checkGame, Game templateGame)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.AgeCategory > templateGame.AgeCategory)
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += checkGame.AvgGameTimeInMinutes / Math.Abs(checkGame.AvgGameTimeInMinutes - templateGame.AvgGameTimeInMinutes);

            coefficientOfSimilarity += checkGame.Difficulty / Math.Abs(checkGame.Difficulty - templateGame.Difficulty);

            if (checkAgeCategory == false)
            {
                return 0;
            }

            return coefficientOfSimilarity;
        }
    }
}
