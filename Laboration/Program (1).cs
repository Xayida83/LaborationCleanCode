using Laboration;
using Laboration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGameLogic, GameLogic>()
            .AddSingleton<ILeaderboard, Leaderboard>()
            .AddSingleton<IUserInterface, ConsoleIO>()
            .BuildServiceProvider();

            var gameLogic = serviceProvider.GetService<IGameLogic>();
            var leaderboard = serviceProvider.GetService<ILeaderboard>();
            var ui = serviceProvider.GetService<IUserInterface>();


            GameBoard gameBoard = new(gameLogic, leaderboard, ui);
            gameBoard.RunTheGame();

        }
    }
}




          
