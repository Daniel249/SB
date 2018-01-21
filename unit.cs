using System;
public class Unit : Thing {
    int health;
    int moveSpeed;
    Weapon weapon;

    // constructor
    public Unit(int pos_x, int pos_y) : base(pos_x, pos_y) {
        
    }
}
public abstract class Thing {

    // position in map
    protected int position_x;
    protected int position_y;
    // color
    ConsoleColor bcolor;
    ConsoleColor fcolor = ConsoleColor.Cyan;
    public ConsoleColor getBColor() {
        return bcolor;
    }
    public ConsoleColor getFColor() {
        return fcolor;
    } 
    // ascii code
    char[,] code;
    public char[,] getCode() {
        return code;
    }
    //printer
    // protected Printer printer;
    public int getPos_x() {
        return position_x;
    }
    public int getPos_y() {
        return position_y;
    }

    // methods
    // movement
    public void move(int dir_x, int dir_y) {
        Printer.deleteThing(this);
        position_x += dir_x;
        position_y += dir_y;
        Printer.printThing(this);
    }
    public void turn() {
        
    }

    //constructor
    public Thing(int pos_x, int pos_y) {
        position_x = pos_x;
        position_y = pos_y;
        // remove test
        code = new char[3,1];
        code[0,0] = 'o';
        code[1,0] = 'u';
        code[2,0] = 'i';
        
        // code = new char[1,3];
        // code[0,0] = 'o';
        // code[0,1] = 'u';
        // code[0,2] = 'i';
    }


}