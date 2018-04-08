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

        private int Partition(double[] koefs, Game[] games, int left, int right)
        {
            double pivot = koefs[(left + right) / 2];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (koefs[i] < pivot) { i++; }
                while (koefs[j] > pivot) { j--; }
                if (i <= j)
                {
                    Swap<double>(ref koefs[i], ref koefs[j]);
                    Swap<Game>(ref games[i], ref games[j]);
                    i++;
                    j--;
                }
            }
            return i;
        }

        public void QuickSort(double[] coefs, Game[] games, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(coefs, games, 0, coefs.Length - 1);

                QuickSort(coefs, games, left, p - 1);
                QuickSort(coefs, games, p, right);
            }
        }
    }
}
