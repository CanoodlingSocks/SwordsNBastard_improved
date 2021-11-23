using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SwordsNBastard_improved
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main title screen

            Title title = new Title();
            title.MainTitle();
            Player player = new Player();

            player.CreatePlayer();
            
            Console.ReadLine();
        }
    }
}
