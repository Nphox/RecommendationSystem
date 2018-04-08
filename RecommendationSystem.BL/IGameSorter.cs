using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    interface IGameSorter
    {
        void QuickSort(double[] coefs, Game[] games, int left, int right);
    }
}
