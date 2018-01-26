using System;
public class Unit : Thing {
    int health = 100;
    int moveSpeed = 1;
    Weapon weapon;

    
    public void setWeapon(Weapon _weapon) {
        weapon = _weapon;
    }

    public void fireWeapon() {
        weapon.fire();
    }


    // constructor
    public Unit(int pos_x, int pos_y) : base(pos_x, pos_y) {
        
    }
}
// bullets are Things in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
public class Bullet : Thing {
    int attackDamage;
    // used in queue 
    int moveSpeed;
    // triangular opposite and adjacent
    int verticalSpeed; // opposite
    int horizontalSpeed; // adjacent

    // return veritcal- or horizontalSpeed based on bool parameter
    public int getMS(bool isHorizontal) {
        if(isHorizontal) {
            return horizontalSpeed;
        } else {
            return verticalSpeed;
        }
    }


    // move bullet. rn only to the right
    // change to include angled travel
    public void travel() {
        printMove(1,0);
    }


    // constructor
    public Bullet(int pos_x, int pos_y) : base(pos_x, pos_y) {
        attackDamage = 1;
        moveSpeed = 1;
        horizontalSpeed = 1;
        verticalSpeed = 0;
        setCode(new char[1,1] {{'o'}});
        Game.getQueue().bulletQueue.Add(this);
    }
}

// can be referenced in map
// inherited by Unit and Bullet
public abstract class Thing {
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
    public void move(int dir_x, int dir_y) {
        position_x += dir_x;
        position_y += dir_y;
    }
    public void printMove(int dir_x, int dir_y) {
        Printer.deleteThing(this);
        move(dir_x, dir_y);
        Printer.printThing(this);
    }
    public void turn() {
        
    }
    //constructor
    #region
    public Thing(int pos_x, int pos_y) {
        position_x = pos_x;
        position_y = pos_y;
        // remove test
        test(3, 3);   
    }
    public Thing(int pos_x, int pos_y, ConsoleColor _bcolor) {
        position_x = pos_x;
        position_y = pos_y;
        bcolor = _bcolor;
        // remove test
        test(3, 3);   
    }
    public Thing(int pos_x, int pos_y, ConsoleColor _bcolor, ConsoleColor _fcolor) {
        position_x = pos_x;
        position_y = pos_y;
        bcolor = _bcolor;
        fcolor = _fcolor;
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