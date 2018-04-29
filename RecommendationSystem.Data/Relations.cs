namespace RecommendationSystem.Data
{
    public static class Relations
    {
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

        public const double importanceUniverse = 0.5;
        public const double importanceCharacter = 0.5;
    }
}
