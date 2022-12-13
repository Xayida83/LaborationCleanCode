using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration
{
    public class Player
    {
		public string Name { get; set; }
		public int NumberOfGames { get; set; }
		
		int totalGuess;


		public Player(string name, int guesses)
		{
			Name = name;
			NumberOfGames = 1;
			totalGuess = guesses;
		}
		
		public void UpdateGuess(int guesses)
		{
			totalGuess += guesses;
			NumberOfGames++;
		}
		public double ScoreAverage()
		{
			return (double)totalGuess / NumberOfGames;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((Player)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
