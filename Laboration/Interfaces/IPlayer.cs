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
        int TotalGuess { get; }
        void SavePlayer(string userName, int numberOfGuesses);
        string TakeUserGuess();
    }
}
