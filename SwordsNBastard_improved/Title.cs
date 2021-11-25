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
                Console.Write("Input: ");

                Player player = new Player();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "new game":
                        player.CreatePlayer();
                        break;

                    case "load game":
                        Console.WriteLine("To be implemented!");
                        Console.ReadLine();
                        break;

                    case "exit":
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
