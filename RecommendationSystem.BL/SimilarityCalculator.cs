using System;
using System.Collections.Generic;
using BoardGamesExtractor;
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
            GameParams checkGame,
            GameParams templateGame, 
            double[,] relationshipUniverses, 
            double[,] relationshipCharacters, 
            double importanceUniverse, 
            double importanceCharacter)
        {
            var checkAgeCategory = true;

            double coefficientOfSimilarity = 0;

            if (checkGame.Age.MinAge > templateGame.Age.MinAge)
            {
                checkAgeCategory = false;
            }

            //coefficientOfSimilarity += importanceUniverse * relationshipUniverses[(int) checkGame.Universe, (int) templateGame.Universe];
            //coefficientOfSimilarity += importanceCharacter * relationshipCharacters[(int)checkGame.Character, (int)templateGame.Character];

            coefficientOfSimilarity += Relations.MaxPartOfMinGameTime * Percentage(checkGame.Timing.MinTime, templateGame.Timing.MinTime);
            coefficientOfSimilarity += Relations.MaxPartOfComplexity * Percentage(checkGame.Complexity, templateGame.Complexity);
            coefficientOfSimilarity += Relations.MaxPartOfActivity * Percentage(checkGame.Activity, templateGame.Activity);
            
            foreach(string s in checkGame.Tags)
            {
                if (templateGame.Tags.Contains(s))
                {
                    coefficientOfSimilarity += Relations.MaxPartOfTag;
                }
            }
            foreach (string s in checkGame.Series)
            {
                if (templateGame.Series.Contains(s))
                {
                    coefficientOfSimilarity += Relations.MaxPartOfSeries;
                }
            }
            foreach (string s in checkGame.Thematic)
            {
                if (templateGame.Thematic.Contains(s))
                {
                    coefficientOfSimilarity += Relations.MaxPartOfThematic;
                }
            }
            foreach (string s in checkGame.Categories)
            {
                if (templateGame.Categories.Contains(s))
                {
                    coefficientOfSimilarity += Relations.MaxPartOfCategories;
                }
            }

            return checkAgeCategory == false ? 0 : Math.Round(coefficientOfSimilarity, 3);
        }
    }
}
