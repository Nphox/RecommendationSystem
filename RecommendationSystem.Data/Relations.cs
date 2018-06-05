namespace RecommendationSystem.Data
{
    public static class Relations
    {
        public const double MaxPartOfMinGameTime = 0.1;
        public const double MaxPartOfComplexity = 0.1;

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
