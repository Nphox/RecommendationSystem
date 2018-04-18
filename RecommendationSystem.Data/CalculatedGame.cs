using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.Data
{
    public class CalculatedGame : IComparable<CalculatedGame>
    {
        public Game Game { get; set; }
        public double CoefSimilarity { get; set; }

        public CalculatedGame(Game game, double coef)
        {
            Game = game;
            CoefSimilarity = coef;
        }

        public int CompareTo(CalculatedGame other)
        {
            return other.CoefSimilarity.CompareTo(CoefSimilarity);
        }
    }
}
