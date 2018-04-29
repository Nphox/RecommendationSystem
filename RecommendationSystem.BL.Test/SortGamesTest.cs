using System.Collections.Generic;
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

            gamesActual[0].Id = 0;
            gamesActual[1].Id = 1;
            gamesActual[2].Id = 2;

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

            gamesExpected[0].Id = 2;
            gamesExpected[1].Id = 1;
            gamesExpected[2].Id = 0;

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
                Assert.AreEqual(gamesExpected[i].Id, gamesActual[i].Id);
                Assert.AreEqual(gamesExpected[i].CoefSimilarity, gamesActual[i].CoefSimilarity);
            }
        }
    }
}
