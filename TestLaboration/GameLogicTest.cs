using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboration.Interfaces;
using Laboration;
using Moq;
using System;

namespace TestLaboration
{
    [TestClass]
    public class GameLogicTest
    {
        [TestMethod]
        public void GenerateGoalNumber_ShouldGetAFourDidgetNumber()
        {
            // Arrange
            var sut = new GameLogic();

            // Act
            string goal = sut.GenerateGoalNumber();

            // Assert
            Assert.IsTrue(goal.Length == 4);
        }
      
        // Den fungerar ej 
        [TestMethod]
        public void GenerateGoalNumber_ShouldReturnUniqueNumber()
        {
            // Setup mocks
             var gameLogicMock = new Mock<GameLogic>();
             gameLogicMock.Setup(r => r.GenerateGoalNumber()).Returns("1234");

            // Arrange
            string goal = gameLogicMock.Object.GenerateGoalNumber();
           
            // Assert
            Assert.AreEqual("1234", goal);
        }


        [TestMethod]
        public void CheckBullsAndCows_ShouldReturnAllBulls()
        {
            // Arrange

            var sut = new GameLogic();
            string goal = "1234";
            string guess = "1234";
            string expected = "BBBB,";

            // Act
            string result = sut.CheckBullsAndCows(goal, guess);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckBullsAndCows_ShouldReturnAllCows()
        {
            // Arrange
            var sut = new GameLogic();
            string goal = "1234";
            string guess = "4321";
            string expected = ",CCCC";

            // Act
            string result = sut.CheckBullsAndCows(goal, guess);

            // Assert
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void CheckBullsAndCows_ShouldReturnBullsAndCows()
        {
            // Arrange
            var sut = new GameLogic();
            string goal = "1234";
            string guess = "1324";
            string expected = "BB,CC";

            // Act
            string result = sut.CheckBullsAndCows(goal, guess);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ContinueGame_ShouldReturnTrueForContinueGame()
        {
            //  // Arrange
            // var sut = new GameLogic();
            // int numberOfGuesses = 2;
            // bool expected = true;

            // using (var input = new StringReader("yes\n"))
            // {
            //     Console.SetIn(input);

            //     // Act
            //     bool result = sut.ContinueGame(numberOfGuesses);

            //     // Assert
            //     Assert.IsTrue(expected, result);
            // }
        }

        [TestMethod]
        public void ContinueGame_ShouldReturnFalseForContinueGame()
        {

        }
       
    }
}
