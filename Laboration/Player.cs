using Laboration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration
{
    public class Player : IPlayer
    {
		public string Name { get; set; }
		public int NumberOfGames { get; private set; }
		
		public int TotalGuess { get; private set; }


		public Player(string name, int guesses)
		{
			Name = name;
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
			return p is Player data && Name.Equals(data.Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public void SavePlayerData(string userName, int numberOfGuesses)
		{
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(userName + "#&#" + numberOfGuesses);
			output.Close();
		}

        public string TakeUserGuess()
        {
            string userGuess = Console.ReadLine();
            return userGuess;
        }
    }
}
