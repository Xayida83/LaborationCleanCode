﻿using Laboration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration
{
    public class UserInterface
    {
        // IO - input and output 

        //private readonly Player _player;
		private readonly IGameLogic _logic;

        public UserInterface(IGameLogic logic)//Player player,
		{
            //_player = player;
			_logic = logic;
        }


		public string TakeInUserName()
        {
			Console.WriteLine("Enter your user name:\n");
			string userName = Console.ReadLine();
			return userName;
		}

		public string GenerateAndWriteOutGoalNumber()
        {
			string goal = _logic.GenerateGoalNumber();

			Console.WriteLine("For practice, number is: " + goal + "\n");
			return goal;
			
		}

		public string TakeUserGuess()
        {
			string userGuess = Console.ReadLine();
			return userGuess;
		}

		public void SavePlayer(string userName, int numberOfGuesses)
        {
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(userName + "#&#" + numberOfGuesses);
			output.Close();
		}

		public bool ContinueGame(int numberOfGuesses)
        {
			Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
			bool playOn = true;
			string answer = Console.ReadLine();
			if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			{
				playOn = false;
			}
			return playOn;
		}

        public bool RunTheGame()
        {
            string userName = TakeInUserName();

            string goal = GenerateAndWriteOutGoalNumber();

            string userGuess = string.Empty;
            int numberOfGuesses = 1;
            string bbcc = _logic.CheckBC(goal, userGuess);
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                userGuess = TakeUserGuess();
                bbcc = _logic.CheckBC(goal, userGuess);
                Console.WriteLine(bbcc + "\n");
            }

            SavePlayer(userName, numberOfGuesses);

            return ContinueGame(numberOfGuesses);

            ShowTopList();
        }

  //      public void GamePlay()
		//{
  //          bool playOn = true;

		//	//Console.WriteLine("Enter your user name:\n");
		//	//string userName = Console.ReadLine();

		//	while (playOn)
		//	{
  //              //// change "goal" name everyname that has goal in it 
  //              //string goal = _logic.GenerateGoalNumber();



  //              //Console.WriteLine("New game:\n");
  //              ////comment out or remove next line to play real games!
  //              //Console.WriteLine("For practice, number is: " + goal + "\n");
  //              //string userGuess = Console.ReadLine();

  //              //int numberOfGuesses = 1;
		//		//string bbcc =  _logic.CheckBC(goal, userGuess);
		//		//Console.WriteLine(bbcc + "\n");
		//		//while (bbcc != "BBBB,")
		//		//{
		//		//	numberOfGuesses++;
		//		//	userGuess = Console.ReadLine();
		//		//	Console.WriteLine(userGuess + "\n");
		//		//	bbcc = _logic.CheckBC(goal, userGuess);
		//		//	Console.WriteLine(bbcc + "\n");
		//		//}

		//		//StreamWriter output = new StreamWriter("result.txt", append: true);
		//		//output.WriteLine(userName + "#&#" + numberOfGuesses);
		//		//output.Close();

		//		//ShowTopList();

		//		//Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");

		//		//string answer = Console.ReadLine();
		//		//if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
		//		//{
		//		//	playOn = false;
		//		//}
		//	}
		//}
		static void ShowTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<Player> results = new List<Player>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				Player pd = new Player(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}


			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (Player p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
			}
			input.Close();
		}

	}
}
//From chat
//public class GameBoard
//{
//	// Private instance field
//	private static GameBoard instance = null;

//	// Private constructor
//	private GameBoard()
//	{
//		// Initialize the game board here...
//	}

//	// Static method for getting the single instance of the game board
//	public static GameBoard GetInstance()
//	{
//		if (instance == null)
//		{
//			instance = new GameBoard();
//		}

//		return instance;
//	}

//	// Other methods and fields for the game board...
//}
