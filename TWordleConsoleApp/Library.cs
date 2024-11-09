using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWordleConsoleApp
{
    public class Library
    {
        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }


        public static void WriteMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }


        public static void Pause()
        {
            Console.WriteLine("Press the ENTER key to continue...");
            Console.ReadKey();
        }


        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
