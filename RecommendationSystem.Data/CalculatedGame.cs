using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.Data
{
    public class CalculatedGame
    {
        private Game Game;
        private double CoefSimilarity;

        public Game GetGame()
        {
            return Game;
        }

        public double GetCoef()
        {
            return CoefSimilarity;
        }

        public void SetGame(Game game)
        {
            Game = game;
        }

        public void SetCoef(double coef)
        {
            CoefSimilarity = coef;
        }
    }
}
