using Laboration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestLaboration
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void ShouldUpdateGuesses()
        {
            //Arrage
            var player = new Player();

            //Act
            player.TotalGuess = 5;
            player.NumberOfGames = 2;

            player.UpdateGuess(2);

            //Assert
            Assert.AreEqual(player.TotalGuess, 7);
            Assert.AreEqual(player.NumberOfGames, 3);
        }

        [TestMethod]
        public void ShouldGetScoreAverage()
        {
            //Arrage
            var player = new Player();

            //Act
            player.TotalGuess = 20;
            player.NumberOfGames = 5;

            double average = player.ScoreAverage();

            //Assert
            Assert.AreEqual(average, 4);

        }

    }
}
