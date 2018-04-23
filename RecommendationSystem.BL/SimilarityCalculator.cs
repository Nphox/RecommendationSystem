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
            return a >= b ? Math.Round(b / a, 2) : Math.Round(a / b, 2);
        }

        public double SimilarityUniverses(Universe check, Universe template)
        {
            if (check == template)
            {
                return 0.2;
            }

            if (check == Universe.Pirates && template == Universe.Vikings)
            {
                return 0.12;
            }

            if (check == Universe.Vikings && template == Universe.Pirates)
            {
                return 0.12;
            }

            return 0;
        }

        public double CalculateSimilarity(Game checkGame, Game templateGame)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.AgeCategory > templateGame.AgeCategory)
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += SimilarityUniverses(checkGame.Universe, templateGame.Universe);

            coefficientOfSimilarity += Percentage(checkGame.AvgGameTimeInMinutes, templateGame.AvgGameTimeInMinutes);

            coefficientOfSimilarity += Percentage(checkGame.Difficulty, templateGame.Difficulty);

            return checkAgeCategory == false ? 0 : coefficientOfSimilarity;
        }
    }
}
