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
            var t = new Game(0, "ABC", 4, 2, 90, 17, 7, Universe.Pirates);


            //act


            //assert
        }

    }
}
