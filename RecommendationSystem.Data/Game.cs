using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationSystem.Data
{
    public class Game : IComparable<Game>
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int MaxNumberGamers { get; set; }
        public int MinNumberGamers { get; set; }
        public int AvgGameTimeInMinutes { get; set; }
        public int AgeCategory { get; set; }
        public int Difficulty { get; set; }

        public double CoefSimilarity { get; set; }

        public int CompareTo(Game other)
        {
            return other.CoefSimilarity.CompareTo(CoefSimilarity);
        }
    }
}
