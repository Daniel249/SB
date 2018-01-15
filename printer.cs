using System;

public class Printer {
    int location_x;
    int location_y;
    // main print mechanic
    public void PrintText(string msg, int pos_x, int pos_y, ConsoleColor bcolor) {

    }
    // constructor. object location as parameter
    public Printer(int loc_x, int loc_y) {
        location_x = loc_x;
        location_y = loc_y;
    }
}
