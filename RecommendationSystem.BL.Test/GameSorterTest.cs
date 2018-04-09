using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL.Test
{   
    [TestFixture]
    public class GameSorterTest
    {
        [Test]
        public void QuickSort_SortedGames()
        {
            //arrange
            IGameSorter sorter = new GameSorter();

            Game[] gamesActual = new Game[3];
            gamesActual[0].SetID(0);
            gamesActual[1].SetID(1);
            gamesActual[2].SetID(2);

            Game[] gamesExpected = new Game[3];
            gamesExpected[0].SetID(2);
            gamesExpected[1].SetID(1);
            gamesExpected[2].SetID(0);

            double[] coefsSimilarityGamesActual = new double[3];
            coefsSimilarityGamesActual[0] = 0.0;
            coefsSimilarityGamesActual[1] = 1.0;
            coefsSimilarityGamesActual[2] = 2.0;

            //act
            sorter.QuickSort(coefsSimilarityGamesActual, gamesActual, 0, gamesActual.Length - 1);

            //assert
            Assert.AreEqual(gamesActual, gamesExpected);
        }
    }
}
