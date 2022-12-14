using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboration.Interfaces;
using Laboration;

namespace TestLaboration
{
    [TestClass]
    public class TestGameLogic
    {
        [TestMethod]
        public void GenerateGoalNumber_ShouldGetAFourDidgetNumber()
        {
            // Arrange
            //sut = system under test namingkonvetion
            var sut = new GameLogic();

            // Act
            string goal = sut.GenerateGoalNumber();

            // Assert
            Assert.IsTrue(goal.Length==4);
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


    }
}
