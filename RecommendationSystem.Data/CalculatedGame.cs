using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.Data
{
    class CalculatedGame
    {
        private Game Game;
        private double Coef;

        public CalculatedGame(Game game, double coef)
        {
            Game = game;
            Coef = coef;
        }

        public Game GetGame()
        {
            return Game;
        }

        public double GetCoef()
        {
            return Coef;
        }
    }
}
