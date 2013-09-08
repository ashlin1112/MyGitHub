using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFighting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Text Fighting";
            Game gameStart = new Game();
            gameStart.fight();
        }
    }
}
