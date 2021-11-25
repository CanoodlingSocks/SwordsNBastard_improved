using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwordsNBastard_improved
{
    public class Player
    {
        public static List<Player> PlayerInfo = new List<Player>();
        public string _currentPlayer;

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        private string[] _inventory;
        public string[] Inventory 
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        private string _weapon;
        public string Weapon 
        {
            get { return _weapon; }
            set { _weapon = value; }
        }

        public void CreatePlayer()
        {
            Player newPlayer = new Player();

            bool loop = true;
            while (loop)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Ah a new Hero! Welcome!  What's your name?\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                newPlayer.PlayerName = Console.ReadLine().ToUpper();
                if (PlayerName == String.Empty)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Hmm what's that? I didn't hear you. I shall repeat myself. ..     Press any key to continue");
                    Console.ReadKey();

                    continue;

                }

                _currentPlayer = PlayerName; //To be able to get player info from List withouth showing all entries

                //Add Player name to .txt file (Only used for Looading players) 

                string fileName = "player.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"Player\", fileName);

                File.AppendAllText(fileName, newPlayer.PlayerName.ToString() + Environment.NewLine);

                //Add Player name to List (to use in the actual game)

                newPlayer.Weapon = "Dull dagger"; //TODO <-- Starter weapon, Add attributes later!
                newPlayer.Inventory = null; // <-- No inventory at the beginning

                PlayerInfo.Add(newPlayer);

                //Add list to ListPlayer.txt

                using(FileStream fs = File.OpenWrite("ListPlayer.txt")) 
                {
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach(var element in PlayerInfo)
                        {
                            string info = newPlayer.PlayerName + "£" + newPlayer.Weapon + "£" + newPlayer.Inventory;
                            sw.WriteLine(info);
                        }
                    }
                }

                //File.WriteAllLines(@"Player\ListPlayer.txt", newPlayer); //? HELP

                break; //TODO <-- the rest of the fuking game
            }
        }

        public static void PrintPlayerInfo(Player player)
        {
            Console.WriteLine("Name: " + player.PlayerName);
            Console.WriteLine("Active weapon: " + player.Weapon);
            Console.WriteLine("Inventory: " + player.Inventory);
        }

        public void ListPlayers()
        {
            //if(PlayerInfo.Contains(currentPlayer))

            //if (!NemesisList.Contains(nemesis))  Example code
            //{
            //    NemesisList.Add(nemesis);
            //}
        }

        public void LoadPlayer()
        {
            foreach (string player in File.ReadLines("player.txt"))
            {
                if(new FileInfo("player.txt").Length == 0) 
                {
                    Console.WriteLine("                       ");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("|     LOAD PLAYER     |");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("        No Data!       ");
                    break;
                }
                Console.WriteLine("                       ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("|     LOAD PLAYER     |");
                Console.WriteLine("-----------------------");
                Console.WriteLine(player);

                Console.WriteLine("\nInput player name to load. Press enter if you want to go back");
                Console.Write("Input: ");

                string input = Console.ReadLine().ToUpper();
                if(input == null)
                {
                    break;
                }
                else if(input == player) // <-- PLACEHOLDER CODE PLZ DO NOT JUDGE
                {
                    Console.WriteLine($"\nLoading {player}");
                    Console.ReadLine();

                    //TODO Start game with this player's stats
                }

            }
        }

    }
}

