using System;
public class Unit : Thing {
    
}
public abstract class Thing {
    // reference to battle
    Battle battle;
    // position in map
    protected int position_x;
    protected int position_y;
    // color
    ConsoleColor bcolor;
    ConsoleColor fcolor;
    // ascii code
    char[,] code;
    //printer
    protected Printer printer;
    public int getPos_x() {
        return position_x;
    }
    public int getPos_y() {
        return position_y;
    }

    //constructor
    public Thing() {

    }


}