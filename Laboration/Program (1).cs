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
            .BuildServiceProvider();

            var gameLogic = serviceProvider.GetService<IGameLogic>();
            var player = serviceProvider.GetService<IPlayer>();

            GameBoard gameBoard = new(gameLogic, player);
            //gameBoard.RunTheGame();
            //bool playOn = true;

            while (gameBoard.RunTheGame())
            {
                gameBoard.RunTheGame();
            }




          
