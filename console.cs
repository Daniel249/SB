using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

static class Terminal {
    // numbers based on testing
    // not in use
    static int size_x = 273;
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
        // ShowWindow(ThisConsole, MAXIMIZE);
        Console.Clear();
        Console.CursorVisible = false;
        //Console.SetWindowPosition(0, 0);
    }

// [DllImport("kernel32.dll", ExactSpelling = true)]
// private static extern IntPtr GetConsoleWindow();
// private static IntPtr ThisConsole = GetConsoleWindow();

// //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

// private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

// private const int HIDE = 0;
// private const int MAXIMIZE = 3;
// private const int MINIMIZE = 6;
// private const int RESTORE = 9;


    // main print to console method
    public static void PrintChar(char cha, int pos_x, int pos_y, ConsoleColor bcolor, ConsoleColor fcolor) {
        Console.SetCursorPosition(pos_x, pos_y);
        Console.ForegroundColor = fcolor;
        Console.BackgroundColor = bcolor;
        Console.Write(cha);
        Console.ResetColor();
    }


    // default console colors
    static ConsoleColor bcolor = ConsoleColor.Black;
    static ConsoleColor fcolor = ConsoleColor.White;
    
    // get set
    public static ConsoleColor getDefaultBack() {
        return bcolor;
    }
    public static ConsoleColor getDefaultFore() {
        return fcolor;
    }
}