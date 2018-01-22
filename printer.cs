using System;

public class Printer {
    // main print Thing
    public static void deleteThing(Thing thi) {
        printdelete(thi, false, Terminal.getDefaultBack(), Terminal.getDefaultFore());
    }
    public static void printThing(Thing thi) {
        printdelete(thi, true, thi.getBColor(), thi.getFColor());
    }
    static void printdelete(Thing reference, bool print, ConsoleColor bcolor, ConsoleColor fcolor) {
        // defining to print or delete thing
        Thing printThing = null;
        if(print) {
            printThing = reference;
        } 
        // references
        int pos_x = reference.getPos_x();
        int pos_y = reference.getPos_y();
        Map map = Game.getMap();
        int console_x = pos_x + map.getLocation_x();
        int console_y = pos_y + map.getLocation_y();
        // code dimensions
        int size_x = reference.getCode().GetLength(0);
        int size_y = reference.getCode().GetLength(1);
        for(int y = 0; y < size_y; y++) {
        for(int x = 0; x < size_x; x++) {
            char codechar = reference.getCode()[x,y];
            // if something to print and print(vs delete)
            if(codechar != '\0') {
                if(!print) {
                    codechar = ' ';
                }
                map.setMap(printThing, pos_x + x, pos_y + y);
                Terminal.PrintChar(codechar, console_x + x, console_y + y, bcolor, fcolor);
            }
        }
        }
    }
    // print and erase
    public static void PrintText(string msg, int pos_x, int pos_y, ConsoleColor bcolor) {

    }
    public static void printTo(int pos_x, int pos_y, string code, ConsoleColor fcolor, ConsoleColor bcolor) {
        Printer.PrintText(code, pos_x, pos_y, bcolor);
    }
    public static void eraseFrom(int pos_x, int pos_y, ConsoleColor bcolor) {
        Printer.PrintText(" ", pos_x, pos_y, bcolor);
    }
}
