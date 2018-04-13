using RecommendationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Game[] gamesActual = new Game[3];
            gamesActual[0].SetID(0);
            Console.WriteLine(gamesActual[0].GetID());
        }
    }
}
