using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsProject.Menu
{
    public class MenuBuilder
    {
        string _prompt;
        string[] _Options;
        int _row,
            _column,
            _cursorPosition;

        public MenuBuilder(string prompt, string[] options, int row, int col)
        {
            _prompt = prompt;
            _Options = options;
            _row = row;
            _column = col;
        }
        public void ResetCursorVisible()
        {
            Console.CursorVisible = Console.CursorVisible = false;
        }
        public void SetPosition(int row, int col)
        {
            if (row >= 0)
            {
                Console.CursorTop = row;
            }

            if (col >= 0)
            {
                Console.CursorLeft = col;
            }
        }
        private void PrintMenu()
        {
            ResetCursorVisible();
            for (int i = 0; i < _Options.Length; i++)
            {
                string prefix = "   ";
                SetPosition(_row + i, _column);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                if (i == _cursorPosition)
                {
                    
                    prefix = "-->";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} {_Options[i]}");
                Console.ResetColor();
            }
            
        }
        public int Run()
        {
            bool run = true;
            //Console.Clear();
            Console.WriteLine(_prompt);
            while (run)
            {
                PrintMenu();
                
                var pressedKey = CheckPressedKey();
                
                if (pressedKey == 1)
                {
                    _cursorPosition--;
                    if (_cursorPosition == -1)
                    {
                        _cursorPosition = _Options.Length - 1;
                    }
                }
                else if (pressedKey == 2)
                {
                    _cursorPosition++;
                    if (_cursorPosition >= _Options.Length)
                    {
                        _cursorPosition = 0;
                    }
                }
                else if (pressedKey == 3)
                {
                    run = false;
                }
                else if (pressedKey == 4)
                {
                    return _Options.Length - 1;
                }
                //PrintMenu();
            }
            return _cursorPosition;
            
        }
        private int CheckPressedKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            do
            {
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    return 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    return 2;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    return 3;
                }
                else if (keyPressed == ConsoleKey.Escape)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }

            } while (true);
        }
    }
}
