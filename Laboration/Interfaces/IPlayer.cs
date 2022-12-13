using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }    
        int NumberOfGames { get; }
        int TotalGuess { get; }
        void SavePlayerData(string userName, int numberOfGuesses);
        string TakeUserGuess();

        void UpdateGuess(int guesses);
		double ScoreAverage();
        bool Equals(Object p);
        int GetHashCode();
    }
}
