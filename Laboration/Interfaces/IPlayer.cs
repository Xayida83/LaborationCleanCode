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
        int NumberOfGames { get; set;}
        int TotalGuess { get; set;}

        void UpdateGuess(int guesses);
		double ScoreAverage();
        bool Equals(Object p);
        int GetHashCode();
    }
}
