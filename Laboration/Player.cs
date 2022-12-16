using Laboration.Interfaces;
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
		public int TotalGuess { get; set; }


		public Player(string name, int guesses)
		{
			this.Name = name;
			NumberOfGames = 1;
			TotalGuess = guesses;
		}
		public Player(){}

		public void UpdateGuess(int guesses)
		{
			TotalGuess += guesses;
			NumberOfGames++;
		}
		public double ScoreAverage()
		{
			return (double)TotalGuess / NumberOfGames;
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
