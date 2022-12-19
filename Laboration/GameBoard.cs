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
        private readonly IUserInterface _ui;

        public GameBoard(IGameLogic logic, ILeaderboard leader, IUserInterface ui)
        {
            _leader = leader;
            _logic = logic;
            _ui = ui;
        }

        public void RunTheGame()
        {
            _ui.PutString("Enter your user name:\n");
            string userName = _ui.GetString().Trim();

            bool playOn = true;
            while(playOn)
            {
                string goal = GetRandomNumber();

                _ui.PutString("New game:\n");
                
                //comment out or remove next line to play real games!
                _ui.PutString("For practice, number is: " + goal + "\n");
                string userGuess = _ui.GetString().Trim();

                int numberOfGuesses = 1;
                string bullOrCows = _logic.CheckBullsAndCows(goal, userGuess);
                _ui.PutString(bullOrCows + "\n");

                while (bullOrCows != "BBBB,")
                {
                    numberOfGuesses++;
                    userGuess =  _ui.GetString().Trim();
                    bullOrCows = _logic.CheckBullsAndCows(goal, userGuess);
                    _ui.PutString(bullOrCows + "\n");
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

