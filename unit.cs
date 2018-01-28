using System;
using System.Collections.Generic;

public class Unit : Thing {
    int health = 100;
    // reference toeither player or AI

    
    // reference to weapon
    List<Weapon> weapons;
    public void setWeapon(Weapon weapon) {
        weapons.Add(weapon);
    }
    public List<Weapon> getWeapon() {
        return weapons;
    }
    public void toggleWeapon(bool isFiring) {
        foreach(Weapon w in weapons) {
            w.toggle(isFiring);
        }
    }
    public void toggleWeapon() {
        foreach(Weapon w in weapons) {
            w.toggle();
        }
    }


    // constructor
    public Unit(int pos_x, int pos_y, int delay) : base(pos_x, pos_y, delay) {
        weapons = new List<Weapon>();
    }
}
// bullets are Things in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
public class Bullet : Thing {
    int attackDamage;
    // used in queue 
    int moveSpeed;

    

    // return veritcal- or horizontalSpeed based on bool parameter
    public int getMS(bool isHorizontal) {
        if(isHorizontal) {
            return horizontalSpeed;
        } else {
            return verticalSpeed;
        }
    }



    // constructor
    public Bullet(int pos_x, int pos_y) : base(pos_x, pos_y, 1) {
        attackDamage = 1;
        horizontalSpeed = 1;
        verticalSpeed = 0;
        setCode(new char[,] {
            {'a','b','c'}, 
        });
        // char[,] c = new char[2,1];
        // c[0,0] = 'a';
        // c[1,0] = 'b';
        // setCode(c);
    }
}

// can be referenced in map
// inherited by Unit and Bullet
public abstract class Thing : IChronometric{
    // position in map
    protected int position_x;
    protected int position_y;
    // get set
    public int getPos_x() {
        return position_x;
    }
    public int getPos_y() {
        return position_y;
    }
    
    // pointing direcion. true to the right for player
    bool direction = true;

    // color
    ConsoleColor bcolor = ConsoleColor.Cyan;
    ConsoleColor fcolor;
    // get set
    public ConsoleColor getBColor() {
        return bcolor;
    }
    public ConsoleColor getFColor() {
        return fcolor;
    } 
    public void setBColor(ConsoleColor _bcolor) {
        bcolor = _bcolor;
    }
    public void setFColor(ConsoleColor _fcolor) {
        fcolor = _fcolor;
    }

    // ascii code
    // non '\0' spaces printed and deleted
    char[,] code;

    // get set
    public char[,] getCode() {
        return code;
    }
    public void setCode(char[,] newCode) {
        code = newCode;
    }

    
    // movement
    // triangular opposite and adjacent
    protected int verticalSpeed; // opposite
    protected int horizontalSpeed; // adjacent
    public void move(int dir_x, int dir_y) {
        horizontalSpeed = dir_x;
        verticalSpeed = dir_y;
    }
    public void printMove() {
        Printer.deleteThing(this);
        position_x += horizontalSpeed;
        position_y += verticalSpeed;
        Printer.printThing(this);
    }
    public void turn() {
        
    }

    // implementation of IChronometric
    Cronometer cronometro;
    public override bool tick() {
        if(_tick()) {
            printMove();
            return true;
        } else {
            return false;
        }
    }

    //constructor
    #region
    public Thing(int pos_x, int pos_y, int moveDelay) :
    base(moveDelay) {
        position_x = pos_x;
        position_y = pos_y;
        // remove test
        test(3, 3);   
    }

    void test(int x, int y) {
        code = new char[x,y];
        for (int i = 0; i < y; i++) {
            for (int j = 0; j < x; j++) {
                code[j,i] = '*';
            }
        }
        // code[0,0] = 'o';
        // code[1,0] = 'u';
        // code[2,0] = 'i';
        
        // code = new char[1,3];
        // code[0,0] = 'o';
        // code[0,1] = 'u';
        // code[0,2] = 'i';
    }
#endregion
}