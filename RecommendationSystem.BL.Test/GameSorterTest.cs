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
            GameSorter sorter = new GameSorter();

            #region Define actual objects

            Game[] gamesActual = new Game[3];
            gamesActual[0] = new Game();
            gamesActual[1] = new Game();
            gamesActual[2] = new Game();

            gamesActual[0].SetID(0);
            gamesActual[1].SetID(1);
            gamesActual[2].SetID(2);

            CalculatedGame[] calculatedGamesActual = new CalculatedGame[3];
            calculatedGamesActual[0] = new CalculatedGame();
            calculatedGamesActual[1] = new CalculatedGame();
            calculatedGamesActual[2] = new CalculatedGame();

            calculatedGamesActual[0].SetGame(gamesActual[0]);
            calculatedGamesActual[1].SetGame(gamesActual[1]);
            calculatedGamesActual[2].SetGame(gamesActual[2]);
            calculatedGamesActual[0].SetCoef(0.0);
            calculatedGamesActual[1].SetCoef(1.0);
            calculatedGamesActual[2].SetCoef(2.0);

            #endregion

            #region Define expected objects

            Game[] gamesExpected = new Game[3];
            gamesExpected[0] = new Game();
            gamesExpected[1] = new Game();
            gamesExpected[2] = new Game();

            gamesExpected[0].SetID(2);
            gamesExpected[1].SetID(1);
            gamesExpected[2].SetID(0);

            CalculatedGame[] calculatedGamesExpected = new CalculatedGame[3];
            calculatedGamesExpected[0] = new CalculatedGame();
            calculatedGamesExpected[1] = new CalculatedGame();
            calculatedGamesExpected[2] = new CalculatedGame();

            calculatedGamesExpected[0].SetGame(gamesExpected[0]);
            calculatedGamesExpected[1].SetGame(gamesExpected[1]);
            calculatedGamesExpected[2].SetGame(gamesExpected[2]);
            calculatedGamesExpected[0].SetCoef(2.0);
            calculatedGamesExpected[1].SetCoef(1.0);
            calculatedGamesExpected[2].SetCoef(0.0);

            #endregion

            //act
           

            //assert
            Assert.AreEqual(calculatedGamesActual, calculatedGamesExpected);
        }
    }
}
