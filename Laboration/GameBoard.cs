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
        private readonly ILeaderboard _leader;

        public GameBoard(IGameLogic logic, ILeaderboard leader)
        {
            _leader = leader;
            _logic = logic;
        }

        public void RunTheGame()
        {
            Console.WriteLine("Enter your user name:\n");
            string userName = Console.ReadLine();

            bool playOn = true;
            while(playOn)
            {
                string goal = GetRandomNumber();

                Console.WriteLine("New game:\n");
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string userGuess = Console.ReadLine();

                int numberOfGuesses = 1;
                string bullOrCows = _logic.CheckBullsAndCows(goal, userGuess);
                System.Console.WriteLine(bullOrCows + "\n");

                while (bullOrCows != "BBBB,")
                {
                    numberOfGuesses++;
                    userGuess = Console.ReadLine();
                    bullOrCows = _logic.CheckBullsAndCows(goal, userGuess);
                    Console.WriteLine(bullOrCows + "\n");
                }

                _leader.SavePlayerData(userName, numberOfGuesses);

                _leader.ShowTopScoreList();

                playOn = _logic.ContinueGame(numberOfGuesses);

            }

        }

        public string GetRandomNumber()
        {
            return _logic.GenerateGoalNumber();
        }
    }
}

