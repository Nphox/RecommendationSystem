using NUnit.Framework;
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
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 17, 7, Universe.CyberPunk, Character.Strategy);
            double expexted = 0;
            
            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_2()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.CyberPunk, Character.Strategy);
            double expexted = 0.2;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_1_75()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying);
            Game checkGame =    new Game(1, "ABC", 4, 2, 120, 16, 7, Universe.CyberPunk, Character.Strategy);
            double expexted = 0.175;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_1_78()
        {
            //arrange
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 16, 9, Universe.CyberPunk, Character.Strategy);
            double expexted = 0.178;

            //act
            double actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

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
