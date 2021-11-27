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

                using (FileStream fs = File.OpenWrite("ListPlayer.txt"))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var element in PlayerInfo)
                        {
                            string info = newPlayer.PlayerName + "£" + newPlayer.Weapon;

                            string inventory = "";
                            foreach (var item in inventory)
                            {
                                inventory = inventory + "&" + item;
                            }
                            sw.WriteLine(info);
                        }
                    }
                }

                //File.WriteAllLines(@"Player\ListPlayer.txt", newPlayer); //? HELP

                break; //TODO <-- the rest of the fuking game
            }
        }

        public static List<Player> PrintPlayerInfo(List<Player> PlayerInfo) //? Fix dis
        {
            Player player = new Player();
            string[] playerInventory = new string[3];

            using (StreamReader sr = new StreamReader("ListPlayer.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();

                    strArray = str.Split('£');
                    player.PlayerName = strArray[0];
                    player.Weapon = strArray[1];

                    string inventory = "";
                    foreach (string item in player.Inventory)
                    {
                        string[] strArray2;
                        strArray2 = str.Split('&');
                        inventory = inventory + "&" + item;
                    }

                }
            }
            return PlayerInfo;
            //Console.WriteLine("Name: " + player.PlayerName);
            //Console.WriteLine("Active weapon: " + player.Weapon);
            //Console.WriteLine("Inventory: " + player.Inventory);
        }

        public void ListPlayer() //Supposed to work on every individual profile 
        {
            //if(PlayerInfo.Contains(currentPlayer))

            //if (!NemesisList.Contains(nemesis))  Example code
            //{
            //    NemesisList.Add(nemesis);
            //}
        }

        public void LoadPlayer()
        {
            Console.WriteLine("                       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("|     LOAD PLAYER     |");
            Console.WriteLine("-----------------------");

            if (!File.Exists("player.txt")) //Bypassing error when trying to load before debug file been created
            {
                Console.WriteLine("\nNo saved data to load. . .");
                Console.ReadKey();
            }
            else if (File.Exists("player.txt"))
            {
                if (new FileInfo("player.txt").Length == 0) //When debug file been created but entries deleted
                {
                    Console.WriteLine("\nNo saved data to load. . .");
                    Console.ReadKey();
                }
                else
                {
                    foreach (string player in File.ReadLines("player.txt"))
                    {
                        Console.WriteLine(player);
                    }

                    Console.WriteLine("\nInput player name to load. Press enter if you want to go back");
                    Console.Write("Input: ");
                    var playerList = File.ReadAllLines("player.txt");
                    string input = Console.ReadLine().ToUpper();

                    if (playerList.Contains(input, StringComparer.OrdinalIgnoreCase))
                    {
                        //TODO Add ThreadSleep(300)
                        Console.WriteLine($"\nLoading {input}. . .");
                        Console.ReadKey();
                    }
                }

                //TODO Start game with this player's stats
            }


        }

        public void DeletePlayer()
        {
            Console.WriteLine("                       ");
            Console.WriteLine("-----------------------");
            Console.WriteLine("|     DELETE DATA     |");
            Console.WriteLine("-----------------------");

            if (!File.Exists("player.txt")) //Bypassing error when trying to Delete before debug file been created
            {
                Console.WriteLine("\nNo Data can be found. . .");
                Console.ReadKey();
            }
            else if (File.Exists("player.txt")) 
            {
                if (new FileInfo("player.txt").Length == 0) //When debug file been created but entries had been deleted
                {
                    Console.WriteLine("\nNo Data can be found. . .");
                    Console.ReadKey();
                }
                else
                {
                    foreach (string player in File.ReadLines("player.txt"))
                    {
                        Console.WriteLine(player);


                    }
                    Console.WriteLine("\nDo you want to delete a profile?");
                    Console.WriteLine("Input name of the profile you wish to delete, otherwise press enter to back out");
                    Console.Write("Input: ");
                    var playerList = File.ReadAllLines("player.txt");
                    string input = Console.ReadLine().ToUpper();

                    if (playerList.Contains(input))
                    {
                        Console.WriteLine($"\nAre you sure you wish to delete profile {input}? Y/N");
                        ConsoleKey confirm = Console.ReadKey(false).Key;

                        if (confirm == ConsoleKey.Y)
                        {
                            var newPlayerList = playerList.Where(line => !line.Contains(input));
                            File.WriteAllLines("player.txt", newPlayerList);
                            FileStream fs = new FileStream("player.txt", FileMode.Append);
                            fs.Close();
                        }
                    }
                    else if (!playerList.Contains(input))
                    {
                        Console.WriteLine("\n No entry with that name could be found. . .");
                        Console.ReadKey();
                    }
                }

                //TODO implement way to delete entry in stats-list

            }
        }
    }
}




