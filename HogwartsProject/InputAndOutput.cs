using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject
{
    public class InputAndOutput
    {
        public static string setName(string msg)
        {
            string name;
            do
            {
                Console.Write(msg);
                Console.CursorVisible = true;
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Can't be empty, enter a name please");
                    Console.ResetColor();
                }

            } while (string.IsNullOrEmpty(name));
            return name;
        }
        public static int ReadIntFromConsole(string question)
        {
            Console.Write(question);
            int awnser;
            Console.CursorVisible = true;
            while (!int.TryParse(Console.ReadLine(), out awnser))
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("Input must be numbers, try again");
                Console.ResetColor();
            }
            return awnser;
        }
        public static void PressToContinue()
        {
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Saved()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved!");
            Console.ResetColor();
        }
        public static void NotSaved() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not saved!");
            Console.ResetColor();
        }
    }
}
