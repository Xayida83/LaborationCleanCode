using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboration.Interfaces;

namespace Laboration
{
    public class Leaderboard : ILeaderboard
    {
		public void ShowTopScoreList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<Player> results = new List<Player>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				Player playerData = new Player(name, guesses);
				int position = results.IndexOf(playerData);
				if (position < 0)
				{
					results.Add(playerData);
				}
				else
				{
					results[position].UpdateGuess(guesses);
				}


			}
			results.Sort((p1, p2) => p1.ScoreAverage().CompareTo(p2.ScoreAverage()));
			Console.WriteLine("Player   games average");
			foreach (Player p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.ScoreAverage()));
			}
			input.Close();
		}

		 public void SavePlayerData(string userName, int numberOfGuesses)
		{
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(userName + "#&#" + numberOfGuesses);
			output.Close();
		}
	}
}
