using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class GameSorter : IComparer<CalculatedGame>
    {
        public int Compare(CalculatedGame x, CalculatedGame y)
        {
            if (x.CoefSimilarity < y.CoefSimilarity)
            {
                return 1;
            }

            if (x.CoefSimilarity > y.CoefSimilarity)
            {
                return -1;
            }

            return 0;
        }
    }
}
