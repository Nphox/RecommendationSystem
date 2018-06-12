using System.Collections.Generic;

namespace RecommendationSystem.Data
{
    public static class Relations
    {
        public const double MaxPartOfMinGameTime = 0.1;
        public const double MaxPartOfComplexity = 0.1;
        public const double MaxPartOfActivity = 0.1;

        public const double MaxPartOfTag = 0.2;
        public const double MaxPartOfSeries = 0.2;
        public const double MaxPartOfThematic = 0.2;
        public const double MaxPartOfCategories = 0.2;

        public static double[,] Tags =
        {
            {  0,    0,    0},
            {  0,   30,   15},
            {  0,   15,   30}
        };

        public static double[,] Universes = 
        {
            {0.25, 0.15,    0,    0,    0},
            {0.15, 0.25,    0,    0,    0},
            {   0,    0, 0.25, 0.15, 0.10},
            {   0,    0, 0.15, 0.25, 0.15},
            {   0,    0, 0.10, 0.15, 0.25}
        };

        public static double[,] Characters =
        {
            {0.25,    0,    0, 0.15},
            {   0, 0.25, 0.10, 0.10},
            {   0, 0.10, 0.25,    0},
            {0.15, 0.10,    0, 0.25}
        };

        public const double ImportanceUniverse = 1;
        public const double ImportanceCharacter = 1;

    }
}
