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
            Game templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            Game checkGame = new Game(1, "ABC", 4, 2, 90, 17, 7, Universe.CyberPunk, Character.Strategy, 10);
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
            var templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            var checkGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.CyberPunk, Character.Strategy, 10);
            const double expexted = 0.2;

            //act
            var actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_0_175()
        {
            //arrange
            var templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            var checkGame =    new Game(1, "ABC", 4, 2, 120, 16, 7, Universe.CyberPunk, Character.Strategy, 10);
            const double expexted = 0.175;

            //act
            var actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_0_178()
        {
            //arrange
            var templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            var checkGame = new Game(1, "ABC", 4, 2, 90, 16, 9, Universe.CyberPunk, Character.Strategy, 10);
            const double expexted = 0.178;

            //act
            var actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_0_7()
        {
            //arrange
            var templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            var checkGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.Pirates, Character.RolePlaying, 10);
            const double expexted = 0.7;

            //act
            var actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void CalculateSimilarity_0_55()
        {
            //arrange
            var templateGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.CyberPunk, Character.RolePlaying, 10);
            var checkGame = new Game(1, "ABC", 4, 2, 90, 16, 7, Universe.ZombieApocalypse, Character.RolePlaying, 10);
            const double expexted = 0.55;

            //act
            var actual = _calculator.CalculateSimilarity(checkGame, templateGame, Relations.Universes, Relations.Characters, Relations.ImportanceUniverse, Relations.ImportanceCharacter);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_75()
        {
            //arrange
            const double expexted = 0.75;

            //act
            var actual = _calculator.Percentage(90, 120);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_25()
        {
            //arrange
            const double expexted = 0.25;

            //act
            var actual = _calculator.Percentage(50, 200);

            //assert
            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void Percentage_0_33()
        {
            //arrange
            const double expexted = 0.33;

            //act
            var actual = _calculator.Percentage(90, 30);

            //assert
            Assert.AreEqual(expexted, actual);
        }
    }
}
