using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboration.Interfaces;

namespace Laboration
{
    public class ConsoleIO : IUserInterface
    {
        public void PutString(string s)
        {
            Console.WriteLine(s);
        }
        public string GetString()
        {
            return Console.ReadLine();
        }

    }
}