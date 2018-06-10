using BoardGamesExtractor;
using System;

namespace RecommendationSystem.Data
{
    public class Game : IComparable<Game>
    {
        public GameParams GameParams { get; set; }
        public double CoefSimilarity { get; set; }
  
        public Game()
        {
            GameParams = new GameParams(false);
        }
        public Game(GameParams gameParams, double coefSimilarity)
        {
            GameParams = gameParams;
            CoefSimilarity = coefSimilarity;
        }
        public int CompareTo(Game other)
        {
            return other.CoefSimilarity.CompareTo(CoefSimilarity);
        }
    }
}
