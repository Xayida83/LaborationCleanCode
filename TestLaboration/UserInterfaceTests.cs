using Laboration;
using Laboration.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestLaboration
{
    [TestClass]
    public class UserInterfaceTests
    {
        [TestMethod]
        public void GamePlay_Happypath()
        {
            //Arrange
            var mockLogic = new Mock<IGameLogic>();

            mockLogic.Setup(x => x.GenerateGoalNumber())
            .Returns("1234");            

            var systemUnderTest = new UserInterface(mockLogic.Object);

            //Act
            systemUnderTest.RunTheGame();

            //Assert
            Assert.AreEqual("sträng1","sträng1");
        }
    }
}
