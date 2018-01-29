using System;
using System.Collections.Generic;

public class Unit : Thing {
    int health = 100;
    // reference toeither player or AI
    
    public void receiveDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            die();
        }
    }
    void die() {
        foreach(Weapon w in weapons) {
            w.removeFromQueue();
        }
        weapons.Clear();
        delete();
        if(!getTeam()) {
            Program.spawn();
        }
    }



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

    // IChronometric implementation
    protected override void everyTime() {}
    protected override void everyTick() {}

    // constructor
    public Unit(int pos_x, int pos_y, int delay, bool team) : base(pos_x, pos_y, delay, team) {
        weapons = new List<Weapon>();
        Printer.printThing(this);
    }
}
// bullets are Things in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
public class Bullet : Thing {
    int attackDamage;


    public bool checkCollision() {
        Thing target = Game.getMap().getMap(position_x, position_y);
        // map populated only by units, no bullets
        if(target != null && target.getTeam() != this.getTeam()) {
            ((Unit)target).receiveDamage(attackDamage);
            delete();
            return true;
        } else {
            return false;
        }
    }


    // IChronometric implementation
    protected override void everyTime() {}
    protected override void everyTick() {
        checkCollision();
    }
 
    // constructor
    public Bullet(int pos_x, int pos_y, int attackDmg, bool team) : base(pos_x, pos_y, 1, team) {
        bounded = true;
        attackDamage = attackDmg;
        verticalSpeed = 0;
        setCode(new char[,] {
            {'a','b','c'} 
        });
        if(team) {
            horizontalSpeed = 1;
        } else {
            horizontalSpeed = -1;
        }
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
    bool direction = false;
    public bool getTeam() {
        return direction;
    }

    // color
    ConsoleColor bcolor;
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
    public bool bounded = false;
    protected int verticalSpeed; // opposite
    protected int horizontalSpeed; // adjacent
    public void move(int dir_x, int dir_y) {
        horizontalSpeed = dir_x;
        verticalSpeed = dir_y;
    }
    public void printMove() {
        if(horizontalSpeed != 0 || verticalSpeed != 0) {
                Printer.deleteThing(this);
                position_x += horizontalSpeed;
                position_y += verticalSpeed;
                Printer.printThing(this);
        }
    }
    public void delete() {
        Printer.deleteThing(this);
        removeFromQueue();
    }
    public void turn() {
        
    }


    public override bool tick() {
        everyTime();
        if(_tick()) {
            printMove();
            everyTick();
            return true;
        } else {
            return false;
        }
    }
    protected abstract void everyTime();
    protected abstract void everyTick();


    //constructor
    #region
    public Thing(int pos_x, int pos_y, int moveDelay, bool team) :
    base(moveDelay) {
        position_x = pos_x;
        position_y = pos_y;
        // remove test
        test(3, 3);   
        direction = team;
        if(team) {
            bcolor = ConsoleColor.Cyan;
        } else {
            bcolor = ConsoleColor.Magenta;
        }

    }

    void test(int x, int y) {
        code = new char[x,y];
        for (int i = 0; i < y; i++) {
            for (int j = 0; j < x; j++) {
                code[j,i] = '*';
            }
        }
    }
#endregion
}