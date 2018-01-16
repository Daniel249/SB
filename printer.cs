using System;

public class Printer {
    // main print mechanic
    public static void PrintText(string msg, int pos_x, int pos_y, ConsoleColor bcolor) {

    }
    // print thing on console based on position and map
    public static void printThing(Thing thi) {
        char[,] code = thi.getCode();
        // actual position on console
        int console_x = thi.getPos_x() + thi.getMap().getLocation_x();
        int console_y = thi.getPos_y() + thi.getMap().getLocation_y();
        // thing's dimensions to be printed
        int limit_x = code.GetLength(0);
        int limit_y = code.GetLength(1);
        // offset of code based on location on map and map size
        int offset_x = calcOffset(thi.getMap().getSize_x(), thi.getPos_x(), limit_x);
        int offset_y = calcOffset(thi.getMap().getSize_y(), thi.getPos_y(), limit_y);
        // initial value for loop variables and loop condition tuned to reflect offset
        // substracted to loop variable if negative and to loop condition if positive
        int loop_x = 0;
        int loop_y = 0;
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
        for(; loop_y < limit_y; loop_y++) {
            for(; loop_x < limit_x; loop_x++) {
                Terminal.PrintChar(code[loop_x, loop_y], console_x, console_y,
                    thi.getBColor(), thi.getFColor());
            }
        }
    }
    // cut parts out of map
    // offset<0 => out of map to the left
    static int calcOffset(int mapSize, int thingLocation, int thingSize) {
        int offset = 0;
        int outBound = thingLocation + thingSize - mapSize;
        if(thingLocation < 0){
            offset = thingLocation;
        } else if(outBound < 0) {
            offset = outBound;
        }
        return offset;
    }
}
