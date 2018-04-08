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
            bool checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.GetAgeCategory() > templateGame.GetAgeCategory())
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += checkGame.GetAvgGameTimeInMinutes() / Math.Abs(checkGame.GetAvgGameTimeInMinutes() - templateGame.GetAvgGameTimeInMinutes());

            coefficientOfSimilarity += checkGame.GetDifficulty() / Math.Abs(checkGame.GetDifficulty() - templateGame.GetDifficulty());

            if (checkAgeCategory == false)
            {
                return 0;
            }

            return coefficientOfSimilarity;
        }
    }
}
