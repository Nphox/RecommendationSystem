using System.Collections.Generic;
using BoardGamesExtractor;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public interface ISimilarityCalculator
    {
        double Percentage(double a, double b);

        double CalculateSimilarity(
            GameParams checkGame, 
            GameParams templateGame, 
            double[,] relationshipUniverses,
            double[,] relationshipCharacters, 
            double importanceUniverse, 
            double importanceCharacter);

        void RecalculateWithUsersChoice(List<GameParams> games);
    }
}


