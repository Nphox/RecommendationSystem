using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL.Test
{   
    [TestFixture]
    public class SortGamesTest
    {
        [Test]
        public void Sort_SortedGames()
        {
            //arrange
            #region Define actual objects

            var gamesActual = new List<Game>
            {
                new Game(),
                new Game(),
                new Game()
            };

            gamesActual[0].ID = 0;
            gamesActual[1].ID = 1;
            gamesActual[2].ID = 2;

            gamesActual[0].CoefSimilarity = 0;
            gamesActual[1].CoefSimilarity = 1;
            gamesActual[2].CoefSimilarity = 2;

            #endregion

            #region Define expected objects

            var gamesExpected = new List<Game>
            {
                new Game(),
                new Game(),
                new Game()
            };

            gamesExpected[0].ID = 2;
            gamesExpected[1].ID = 1;
            gamesExpected[2].ID = 0;

            gamesExpected[0].CoefSimilarity = 2;
            gamesExpected[1].CoefSimilarity = 1;
            gamesExpected[2].CoefSimilarity = 0;

            #endregion

            //act
            gamesActual.Sort();

            //assert
            Assert.AreEqual(gamesExpected.Count, gamesActual.Count);

            for (var i = 0; i < gamesExpected.Count; i++)
            {
                Assert.AreEqual(gamesExpected[i].ID, gamesActual[i].ID);
                Assert.AreEqual(gamesExpected[i].CoefSimilarity, gamesActual[i].CoefSimilarity);
            }
        }
    }
}
