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
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }    
        
        
    }
}
