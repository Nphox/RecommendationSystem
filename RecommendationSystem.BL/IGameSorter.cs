using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public interface IGameSorter
    {
        void QuickSort(CalculatedGame[] games, int left, int right);
    }
}
