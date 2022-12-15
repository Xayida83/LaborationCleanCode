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
            .AddSingleton<IPlayer, Player>()
            .AddSingleton<ILeaderboard, Leaderboard>()
            .BuildServiceProvider();

            var gameLogic = serviceProvider.GetService<IGameLogic>();
            var player = serviceProvider.GetService<IPlayer>();
            var leaderboard = serviceProvider.GetService<ILeaderboard>();


            GameBoard gameBoard = new(gameLogic, player, leaderboard);
            //gameBoard.RunTheGame();
            bool playOn = true;

            while (playOn)
            {
                playOn = gameBoard.RunTheGame();
            }
        }
    }
}




          
