using System;
using System.Collections.Generic;

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
    
    // pointing direction. true to the right for player
    readonly bool direction = false;
    public bool getTeam() {
        return direction;
    }


    // ascii image
    // stored in 2d char array
    protected Texture texture; 

    // get set
    public Texture getTexture() {
        return texture;
    }

    
    // movement
    // triangular opposite and adjacent
    protected int verticalSpeed; // opposite
    protected int horizontalSpeed; // adjacent
    // set
    public void move(int dir_x, int dir_y) {
        horizontalSpeed = dir_x;
        verticalSpeed = dir_y;
    }


    public void printMove() {
        if(horizontalSpeed != 0 || verticalSpeed != 0) {
            if(checkBounded()) {
                Printer.deleteThing(this);
                position_x += horizontalSpeed;
                position_y += verticalSpeed;
                Printer.printThing(this);
            } else if(this is Bullet) {
                // if it would fall off map. and is a bullet destroy
                delete();
            }
        }
    }
    bool checkBounded() {
        int new_x = position_x + horizontalSpeed;
        int new_y = position_y + verticalSpeed;
        int dimension_y = texture.GetLength(0);
        if(new_x < 0 || new_x >= Game.getMap().getSize_x()) {
            return false;
        } else if(new_y < 0 || new_y + dimension_y - 1>= Game.getMap().getSize_y()) {
            // main ship will stop before lower part of texture
            return false;
        } else {
            return true;
        }
    }
    public void delete() {
        Printer.deleteThing(this);
        removeFromQueue();
    }

    public void turn() {
        
    }

    // IChronometric implementation
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
    protected Thing(int pos_x, int pos_y, int moveDelay, bool team) :
    base(moveDelay) {
        position_x = pos_x;
        position_y = pos_y;
        ConsoleColor bcolor;
        ConsoleColor fcolor = ConsoleColor.Black;
        if(team) {
            bcolor = ConsoleColor.Cyan;
        } else {
            bcolor = ConsoleColor.Magenta;
        }
        // remove test
        texture = new Texture(test(3, 3), bcolor, fcolor);   
        direction = team;

    }

    char[,] test(int x, int y) {
        char [,] testCode;
        // test code for units. 3x3 asterisks
        if(this is Unit) {
            testCode = new char[x,y];
            for (int i = 0; i < y; i++) {
                for (int j = 0; j < x; j++) {
                    testCode[j,i] = '*';
                }
            }
            return testCode;
        } else if(this is Bullet) {
        // test code for bullets 'abc'
            testCode = new char[,] {
            {'a','b','c'} 
        };
        } else {
            testCode = new char[,] { {'O'} };
        }
        return testCode;
    }
#endregion
}