using System.Collections.Generic;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public interface ISimilarityCalculator
    {
        double Percentage(double a, double b);

        double CalculateSimilarity(Game checkGame, Game templateGame, double[,] relationshipUniverses,
            double[,] relationshipCharacters, double importanceUniverse, double importanceCharacter);

        void RecalculateWithUsersChoice(List<Game> games);
    }
}


