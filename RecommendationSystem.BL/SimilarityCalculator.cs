using System;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class SimilarityCalculator : ISimilarityCalculator
    {
        public double Percentage(double a, double b)
        {
            return a >= b ? Math.Round(b / a, 2) : Math.Round(a / b, 2);
        }

        public double CalculateSimilarity(Game checkGame, Game templateGame, double[,] relationshipUniverses, double[,] relationshipCharacters, double importanceUniverse, double importanceCharacter)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.AgeCategory > templateGame.AgeCategory)
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += importanceUniverse * relationshipUniverses[(int) checkGame.Universe, (int) templateGame.Universe];

            coefficientOfSimilarity += importanceCharacter * relationshipCharacters[(int)checkGame.Character, (int)templateGame.Character];

            coefficientOfSimilarity += Percentage(checkGame.AvgGameTimeInMinutes, templateGame.AvgGameTimeInMinutes);

            coefficientOfSimilarity += Percentage(checkGame.Difficulty, templateGame.Difficulty);

            return checkAgeCategory == false ? 0 : coefficientOfSimilarity;
        }
    }
}
