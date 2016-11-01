using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Console.WriteLine("Pick the game type...");
            Console.WriteLine("1. vs Human");
            Console.WriteLine("2. vs Random Computer Player");
            Console.WriteLine("3. vs Tactical Computer Player");
            while (!(input == "1" || input == "2" || input == "3"))
            {
                Console.Write("Your Choice(1/2/3): ");
                input = Console.ReadLine();
            }
            GameType gameType = (GameType)Convert.ToInt32(input);
            IGame game = new Game(gameType);
            game.Play();
            Console.ReadLine(); //to keep application window open
           
        }
    }
}
