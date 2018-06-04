using System;
using System.Collections.Generic;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class SimilarityCalculator : ISimilarityCalculator
    {
        public double Percentage(double a, double b)
        {
            return a >= b ? Math.Round(b / a, 2) : Math.Round(a / b, 2);
        }

        public double CalculateSimilarity(
            Game checkGame, 
            Game templateGame, 
            double[,] relationshipUniverses, 
            double[,] relationshipCharacters, 
            double importanceUniverse, 
            double importanceCharacter)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.AgeCategory > templateGame.AgeCategory)
            {
                checkAgeCategory = false;
            }

            coefficientOfSimilarity += importanceUniverse * relationshipUniverses[(int) checkGame.Universe, (int) templateGame.Universe];

            coefficientOfSimilarity += importanceCharacter * relationshipCharacters[(int)checkGame.Character, (int)templateGame.Character];

            coefficientOfSimilarity += Relations.MaxPartOfAvgGameTimeInMinutes * Percentage(checkGame.AvgGameTimeInMinutes, templateGame.AvgGameTimeInMinutes);

            coefficientOfSimilarity += Relations.MaxPartOfDifficulty * Percentage(checkGame.Difficulty, templateGame.Difficulty);

            return checkAgeCategory == false ? 0 : Math.Round(coefficientOfSimilarity, 3);
        }

        public void RecalculateWithUsersChoice(List<Game> games)
        {
            var maxRating = games[0].Rating;

            foreach (var game in games)
            {
                if (game.Rating > maxRating)
                {
                    maxRating = game.Rating;
                }
            }

            double percent = maxRating / 100;

            foreach (var game in games)
            {
                game.CoefSimilarity += game.Rating / percent / 1000;
            }
        }
    }
}
