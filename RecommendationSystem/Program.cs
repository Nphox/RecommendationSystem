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
        public static void ChangeObject(List<Game> games)
        {
            games[0].CoefSimilarity = 100;
        }

        static void Main(string[] args)
        {
            //List<Game> list = new List<Game>();
            //list.Add(new Game(0, "ABC", 4, 2, 90, 17, 7, Universe.Pirates, Character.Strategy));
            //list[0].CoefSimilarity = 50;
            //Console.WriteLine(list[0].CoefSimilarity);
            //ChangeObject(list);
            //Console.WriteLine(list[0].CoefSimilarity);
            //Console.ReadLine();
        }
    }
}
