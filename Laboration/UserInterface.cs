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

        private readonly Player _player;
		private readonly GameLogic _logic;

        public UserInterface(Player player, GameLogic logic)
        {
            _player = player;
			_logic = logic;
        }
		public static void GamePlay(string[] args)
		{
            GameLogic logic = new GameLogic();

            bool playOn = true;
			Console.WriteLine("Enter your user name:\n");
			string userName = Console.ReadLine();

			while (playOn)
			{
				// change "goal" name everyname that has goal in it 
				string goal = logic.GenerateGoalNumber();
				


				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				string userGuess = Console.ReadLine();

				int numberOfGuesses = 1;
				string bbcc =  logic.CheckBC(goal, userGuess);
				Console.WriteLine(bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					numberOfGuesses++;
					userGuess = Console.ReadLine();
					Console.WriteLine(userGuess + "\n");
					bbcc = logic.CheckBC(goal, userGuess);
					Console.WriteLine(bbcc + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(userName + "#&#" + numberOfGuesses);
				output.Close();
				ShowTopList();
				Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
				string answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
				{
					playOn = false;
				}
			}
		}
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
