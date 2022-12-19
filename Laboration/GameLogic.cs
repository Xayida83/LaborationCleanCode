using Laboration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration
{
    public class GameLogic : IGameLogic
    {
        public GameLogic() {}

		public string GenerateGoalNumber()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}
		

		public string CheckBullsAndCows(string goal, string guess)
		{
			
			guess += "";
			int numBulls = 0, numCows = 0;
			foreach (var (guessNumber, goalNumber) in goal.Zip(guess, (guessNumber, goalNumber) => (guessNumber, goalNumber)))
			{
				if (guessNumber == goalNumber)
				{
					numBulls++;
				}
				else if (goal.Contains(goalNumber))
				{
					numCows++;
				}
			}

			return "BBBB".Substring(0, numBulls) + "," + "CCCC".Substring(0, numCows);
		}


		public bool ContinueGame(int numberOfGuesses)
		{
			bool playOn = true;
			Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
			string answer = Console.ReadLine();
			if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			{
				playOn = false;

			}
			return playOn;
		}
	}
}
