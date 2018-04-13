using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL
{
    public class GameSorter : IGameSorter
    {
        private void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private int Partition(CalculatedGame[] games, int left, int right)
        {
            double pivot = games[(left + right) / 2].GetCoef();
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (games[i].GetCoef() < pivot) { i++; }
                while (games[j].GetCoef() > pivot) { j--; }
                if (i <= j)
                {
                    Swap<CalculatedGame>(ref games[i], ref games[j]);
                    i++;
                    j--;
                }
            }
            return i;
        }

        public void QuickSort(CalculatedGame[] games, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(games, 0, games.Length - 1);

                QuickSort(games, left, p - 1);
                QuickSort(games, p, right);
            }
        }
    }
}
