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
        public double Percentage(double a, double b)
        {
            if (a >= b)
            {
                return Math.Round(b / a, 2);
            }

            return Math.Round(a / b, 2);
        }

        public double CalculateSimilarity(Game checkGame, Game templateGame)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.AgeCategory > templateGame.AgeCategory)
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += Percentage(checkGame.AvgGameTimeInMinutes, templateGame.AvgGameTimeInMinutes);

            coefficientOfSimilarity += Percentage(checkGame.Difficulty, templateGame.Difficulty);

            if (checkAgeCategory == false)
            {
                return 0;
            }

            return coefficientOfSimilarity;
        }
    }
}
