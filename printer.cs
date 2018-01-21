using System;

public class Printer {
    // main print mechanic
    public static void PrintText(string msg, int pos_x, int pos_y, ConsoleColor bcolor) {

    }
    // print and erase
    public static void printTo(int pos_x, int pos_y, string code, ConsoleColor fcolor, ConsoleColor bcolor) {
        Printer.PrintText(code, pos_x, pos_y, bcolor);
    }
    public static void eraseFrom(int pos_x, int pos_y, ConsoleColor bcolor) {
        Printer.PrintText(" ", pos_x, pos_y, bcolor);
    }
    public static void deleteThing(Thing thi) {
        int pos_x = thi.getPos_x();
        int pos_y = thi.getPos_y();
        Map map = Game.getMap();
        int console_x = pos_x + map.getLocation_x();
        int console_y = pos_y + map.getLocation_y();
        int size_x = thi.getCode().GetLength(0);
        int size_y = thi.getCode().GetLength(1);
        for(int y = 0; y < size_y; y++) {
        for(int x = 0; x < size_x; x++) {
            char codechar = thi.getCode()[x,y];
            // if something to print and inside map
            if(codechar != '\0') {
                map.setMap(null, pos_x + x, pos_y + y);
                Terminal.PrintChar(' ', console_x + x, console_y + y, Terminal.getDefaultBack(), Terminal.getDefaultFore());
            }
        }
        }
    }
    public static void printThing(Thing thi) {
        int pos_x = thi.getPos_x();
        int pos_y = thi.getPos_y();
        Map map = Game.getMap();
        int console_x = pos_x + map.getLocation_x();
        int console_y = pos_y + map.getLocation_y();
        int size_x = thi.getCode().GetLength(0);
        int size_y = thi.getCode().GetLength(1);
        for(int y = 0; y < size_y; y++) {
        for(int x = 0; x < size_x; x++) {
            char codechar = thi.getCode()[x,y];
            // if something to print and inside map
            if(codechar != '\0') {
                map.setMap(thi, pos_x + x, pos_y + y);
                Terminal.PrintChar(codechar, console_x + x, console_y + y, thi.getBColor(), thi.getFColor());
            }
        }
        }
    }
}
