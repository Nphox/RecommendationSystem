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
    public class RecommendationProviderTest
    {

        private readonly IRecommendationProvider _provider = new RecommendationProvider();

        [Test]
        public void RecommendGames_a_b_c()
        {
            //arrange
            var t = new Game(0, "ABC", 4, 2, 90, 17, 7);

            var a = new Game(1, "a", 4, 2, 90, 16, 7);
            var b = new Game(2, "b", 4, 2, 90, 17, 7);
            var c = new Game(3, "c", 4, 2, 90, 17, 7);
            var d = new Game(4, "d", 4, 2, 90, 17, 7);
            var e = new Game(5, "e", 4, 2, 90, 17, 7);
            var f = new Game(6, "f", 4, 2, 90, 17, 7);

            //act


            //assert
        }

    }
}
