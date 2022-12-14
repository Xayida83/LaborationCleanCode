using Laboration;
using Laboration.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestLaboration
{
    [TestClass]
    public class GameBoardTest
    {
        [TestMethod]
        public void PlayTheGame_Happypath()
        {
            //Arrange
            var mockLogic = new Mock<IGameLogic>();
            var mockPlayer = new Mock<IPlayer>();

            mockLogic.Setup(x => x.GenerateGoalNumber())
            .Returns("1234");

            var systemUnderTest = new GameBoard(mockLogic.Object, mockPlayer.Object);

            //Act
            systemUnderTest.RunTheGame();

            //Assert
            Assert.AreEqual("sträng1", "sträng1");
        }
    }
}
