using System;
using System.Collections.Generic;
using GameLibrary;
using GameLibrary.User.Interface;
using GameLibrary.Graphics.Printer;

namespace SB {
// can be referenced in map
// inherited by Unit and Bullet
public abstract class Entity : IChronometric{
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
        //if(horizontalSpeed != 0 || verticalSpeed != 0) {
            // if inside bounds
            if(checkBounded()) {
                Printer.deleteEntity(this);
                position_x += horizontalSpeed;
                position_y += verticalSpeed;
                Printer.printEntity(this);
            } else if(this is Bullet) {
                // if it would fall off map. and is a bullet destroy
                delete();
            }
    // }
    }
    // return false and move if it wouldnt leave map
    bool checkBounded() {
        int new_x = position_x + horizontalSpeed;
        int new_y = position_y + verticalSpeed;
        int dimension_y = texture.GetLength(false);
        if(new_x < 0 || new_x >= Game.getMap().getSize_x()) {
            return false;
        } else if(new_y < 0 || new_y + dimension_y > Game.getMap().getSize_y()) {
            // main ship will stop before lower part of texture
            return false;
        } else {
            return true;
        }
    }
    // end references
    public void delete() {
        Printer.deleteEntity(this);
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
    // with texture
    protected Entity(int pos_x, int pos_y, int moveDelay, bool team, string textureKey) :
    base(moveDelay) {
        position_x = pos_x;
        position_y = pos_y;
        ConsoleColor fcolor;
        ConsoleColor bcolor = ConsoleColor.Black;
        if(team) {
            fcolor = ConsoleColor.Cyan;
        } else {
            fcolor = ConsoleColor.Magenta;
        }
        // initialize texture based on key and parameter colors
        texture = new Texture(Database.assignTexture(textureKey), bcolor, fcolor); 
        direction = team;
    }
}
}