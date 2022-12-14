using Laboration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration
{
	public class GameBoard
	{
        private readonly IGameLogic _logic;
        private readonly IPlayer _player;
        //public Leaderboard _leaderboard;
        Leaderboard leader = new Leaderboard();

        public GameBoard(IGameLogic logic, IPlayer player/* Leaderboard leaderboard*/)
        {
            //_leaderboard = leaderboard;
            _player = player;
            _logic = logic;
        }

        public bool RunTheGame()
        {
            Console.WriteLine("Enter your user name:\n");
            string userName = Console.ReadLine();

            
            string goal = _logic.GenerateGoalNumber();

            Console.WriteLine("New game:\n");
            Console.WriteLine("For practice, number is: " + goal + "\n");
            string userGuess = _player.TakeUserGuess();
        

            //string goal = GenerateAndWriteOutGoalNumber();

            //string userGuess = string.Empty;
            int numberOfGuesses = 1;
            string bbcc = _logic.CheckBullsAndCows(goal, userGuess);
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                userGuess = _player.TakeUserGuess();
                bbcc = _logic.CheckBullsAndCows(goal, userGuess);
                Console.WriteLine(bbcc + "\n");
            }

           _player.SavePlayerData(userName, numberOfGuesses);
            
            leader.ShowTopScoreList();

            return _logic.ContinueGame(numberOfGuesses);
                        
        }
       
    }
}

