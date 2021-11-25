using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwordsNBastard_improved
{
    public class Title
    {
        public void MainTitle()
        {
            bool menuLoop = true;
            while (menuLoop)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine(@"                                         ");
                Console.WriteLine(@"                  LELAS                  ");
                Console.WriteLine(@"           ____ ____ ____ ____           ");
                Console.WriteLine(@"          ||G |||A |||M |||E ||          ");
                Console.WriteLine(@"          ||__|||__|||__|||__||          ");
                Console.WriteLine(@"          |/__\|/__\|/__\|/__\|          ");
                Console.WriteLine(@"                                         ");
                Console.WriteLine(@"              -> New Game                ");
                Console.WriteLine(@"              -> Load Game               ");
                Console.WriteLine(@"              -> Exit                    ");
                Console.Write("\nInput: ");

                Player player = new Player();
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "NEW GAME":
                        player.CreatePlayer();
                        break;

                    case "LOAD GAME":
                        player.LoadPlayer();
                        break;

                    case "EXIT":
                        menuLoop = false;
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        Console.ReadLine();
                        break;
                }

            }
        }


    }
}
