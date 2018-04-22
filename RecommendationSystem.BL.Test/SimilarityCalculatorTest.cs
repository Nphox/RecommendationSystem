using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using RecommendationSystem.Data;

namespace RecommendationSystem.BL.Test
{
    [TestFixture]
    public class SimilarityCalculatorTest
    {
        private readonly ISimilarityCalculator _calculator = new SimilarityCalculator();

        [Test]
        public void CalculateSimilarity_0()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 17, 7);
            double expexted = 0;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_2()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 16, 7);
            double expexted = 2;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_1_75()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7);
            Game checkGame =    new Game(1, "ABC", 4, 2, 120, 16, 7);
            double expexted = 1.75;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_1_78()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 16, 9);
            double expexted = 1.78;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_75()
        {
            //arrange
            double expexted = 0.75;

            //act
            double actual = _calculator.Percentage(90, 120);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_25()
        {
            //arrange
            double expexted = 0.25;

            //act
            double actual = _calculator.Percentage(50, 200);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_33()
        {
            //arrange
            double expexted = 0.33;

            //act
            double actual = _calculator.Percentage(90, 30);

            //assert
            Assert.AreEqual(expexted, actual);
        }
    }
}
