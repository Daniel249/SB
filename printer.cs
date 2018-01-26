using System;

public class Printer {
    // print and delete methods
    // both use printdelete targeted at certain point to print either a char o a space
    public static void deleteThing(Thing thi) {
        printdelete(thi, false, Terminal.getDefaultBack(), Terminal.getDefaultFore());
    }
    public static void printThing(Thing thi) {
        printdelete(thi, true, thi.getBColor(), thi.getFColor());
    }

    // main print method
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

        // loop and limit start as values for a normal for-loop,
        // equal to 0 and max value respectively.
        // they change based on offset to only print code inside map
        int loop_x = 0;
        int loop_y = 0;
        int limit_x = reference.getCode().GetLength(0);
        int limit_y = reference.getCode().GetLength(1);

        // calc offset
        // negative when
        int offset_x = calcOffset(map.getSize_x(), pos_x, limit_x);
        int offset_y = calcOffset(map.getSize_y(), pos_y, limit_y);

        // offset applied to loop and limit
        if(offset_x < 0) {
            loop_x = (-1)*offset_x;
        } else if(offset_x > 0) {
            limit_x -= offset_x;
        }
        if(offset_y < 0) {
            loop_y = (-1)*offset_y;
        } else if(offset_y > 0) {
            limit_y -= offset_y;
        }
        
        // loop from loop_x to limit. at most on changes based on offset 
        for(int y = loop_y; y < limit_y; y++) {
            for(int x = loop_x; x < limit_x; x++) {
                char codechar = reference.getCode()[loop_x, loop_y];

                // if something to print and print(vs delete)
                if(codechar != '\0') {
                    // delete instead if !print
                    if(!print) {
                        codechar = ' ';
                    }

                    // if print and bullet, then dont print reference
                    if(!(print && reference is Bullet)) {
                        map.setMap(printThing, pos_x + x, pos_y + y);
                    }

                    Terminal.PrintChar(codechar, console_x + x, console_y + y, bcolor, fcolor);
                }
            }
        }
    }


    // cut parts of code[,] which are out of map
    // offset<0 => out of map to the left
    static int calcOffset(int mapSize, int thingLocation, int thingSize) {
        int offset = 0;
        int outBound = thingLocation + thingSize - mapSize;

        if(thingLocation < 0){
            offset = thingLocation;
        } else if(outBound > 0) {
            offset = outBound;
        }
        return offset;
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
