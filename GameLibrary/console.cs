using System;
namespace GameLibrary
{
    static class Terminal {
        // numbers based on testing
        // not in use
        static int size_x = 240;
        static int size_y = 72;

        // get set
        public static int getSize_x() {
            return size_x;
        }
        public static int getSize_y() {
            return size_y;
        }

        // methods
        // set console size
        public static void setSize() {
            size_x = Console.LargestWindowWidth;
            size_y = Console.LargestWindowHeight;
            // set buffer automatically
            Console.SetWindowSize(size_x, size_y);
            Console.SetBufferSize(size_x, size_y);

            Console.Clear();
            Console.CursorVisible = false;
            //Console.SetWindowPosition(0, 0);
        }


        // main print to console method. print strings
        public static void PrintString(string str, int pos_x, int pos_y, ConsoleColor bcolor, ConsoleColor fcolor) {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.ForegroundColor = fcolor;
            Console.BackgroundColor = bcolor;
            Console.Write(str);
            Console.ResetColor();
        }
        // print with defult colors
        public static void PrintString(string str, int pos_x, int pos_y) {
            PrintString(str, pos_x, pos_y, bcolor, fcolor);
        }


        public static void PrintChar(char cha, int pos_x, int pos_y, ConsoleColor bcolor, ConsoleColor fcolor) {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.ForegroundColor = fcolor;
            Console.BackgroundColor = bcolor;
            Console.Write(cha);
            Console.ResetColor();
        }


        // default console colors
        const ConsoleColor bcolor = ConsoleColor.Black;
        const ConsoleColor fcolor = ConsoleColor.White;
        
        // get set
        public static ConsoleColor getDefaultBack() {
            return bcolor;
        }
        public static ConsoleColor getDefaultFore() {
            return fcolor;
        }
    }
}