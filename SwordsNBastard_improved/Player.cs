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
        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }

        public void CreatePlayer()
        {
            Player newPlayer = new Player();

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ah a new Hero! Welcome!  What's your name?\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                string playerName = Console.ReadLine();
                if (playerName == String.Empty)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Hmm what's that? I didn't hear you. I shall repeat myself. ..     Press any key to continue");
                    Console.ReadKey();

                    continue;

                }

                //Add Player to .txt file

                // This was supposed to find the folder within the solution directly instead of
                // writing a long-ass directory path that won't work on other computersss
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Player\player.txt");

                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        newPlayer.PlayerName = playerName;
                        //string[] files = File.ReadAllLines(path);
                    }
                }
            }

        }
    }
}