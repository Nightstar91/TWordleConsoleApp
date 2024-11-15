using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWordleConsoleApp
{
    public class Player
    {
        // Declaring class variable
        public string? name { get; set; }
        public int attempt;

        public Player(string _name)
        {
            name = _name;
            attempt = 6;
        }


        public void DecreaseAttempt()
        {
            attempt--;
        }


        public void ResetAttempt()
        {
            attempt = 6;
        }
    }
}
