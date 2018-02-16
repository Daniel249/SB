using System;
using GameLibrary.Graphics.Display;
using GameLibrary.Graphics;
using GameLibrary.Platform;
namespace SB.Objects {
// can be referenced in map
// inherited by Unit and Bullet
public abstract class Entity : TimeAware, IPrintable {
    
    // IPrintable implementation
    // position in map
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }

    // ascii image
    // stored in 2d char array
    public Texture Texture { get; protected set; } 

    // screen reference
    public Screen Screen { get; private set; }

    
    // pointing direction. true to the right for player
    readonly bool direction = false;
    public bool Team {
        get {
            return direction;
        }
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
        // if(horizontalSpeed != 0 || verticalSpeed != 0) {
            // if inside bounds
            if(checkBounded()) {
                // delete, move, and print
                Screen.delete(this);
                Position_x += horizontalSpeed;
                Position_y += verticalSpeed;
                Screen.print(this);
            } else if(this is Bullet) {
                // if it would fall off map. and is a bullet destroy
                delete();
            }
        // }
    }
    // return false and move if it wouldnt leave map
    bool checkBounded() {
        int new_x = Position_x + horizontalSpeed;
        int new_y = Position_y + verticalSpeed;
        int dimension_y = Texture.GetLength(false);
        if(new_x < 0 || new_x >= Game.getMap().Size_x) {
            return false;
        } else if(new_y < 0 || new_y + dimension_y > Game.getMap().Size_y) {
            // main ship will stop before lower part of texture
            return false;
        } else {
            return true;
        }
    }

    // end references
    public void delete() {
        Screen.delete(this);
        removeFromQueue();
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
    protected Entity(int pos_x, int pos_y, int moveDelay, bool team, string textureKey) :
    base(moveDelay) {
        Position_x = pos_x;
        Position_y = pos_y;
        ConsoleColor fcolor;
        ConsoleColor bcolor = Terminal.DefaultBackColor;
        if(team) {
            fcolor = ConsoleColor.Cyan;
        } else {
            fcolor = ConsoleColor.Magenta;
        }
        // initialize texture based on key and parameter colors
        Texture = new Texture(Database.assignTexture(textureKey), bcolor, fcolor); 
        direction = team;
        Screen = Game.getMainScreen();
        Screen.print(this);
    }
}
}