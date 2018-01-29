using System;
using System.Collections.Generic;

public class Player {
    Unit ship;
    // save movement direction until movement method
    int vertDirection;
    int horDirection;

    // if constantMove holding key not needed for movement
    //bool constantMove;
    
    
    // main player method. runs once per battle cycle
    public void runTurn() {
        if(Console.KeyAvailable) {
            ConsoleKeyInfo letter = Console.ReadKey(true);
            proKey(letter);
        }
            moveShip();
    }


    // process input key
    void proKey(ConsoleKeyInfo key) {
        if(Game.processKey(key)) {
            return;
        }
        
        switch(key.Key) {
            // left arrow : stop moving
            case ConsoleKey.LeftArrow:
                horDirection = 0;
                vertDirection = 0;
                break;
                
            // right arrow
            case ConsoleKey.RightArrow:
                
                break;

            // down arrow : move down
            case ConsoleKey.DownArrow:
                vertDirection = 1;
                break;
                
            // up arrow : move up
            case ConsoleKey.UpArrow:
                vertDirection = -1;
                break;

            // f key : togle fire
            case ConsoleKey.F:
                ship.toggleWeapon();
                break;
        }
    }


    void moveShip() {
        ship.move(horDirection, vertDirection);
    }


    // constructor
    public Player(bool fire) {
        // instantiate ship and load a weapon to it
        ship = new Unit(0, Game.getMap().getSize_y()/2, 1, true);
        // load weapon to ship. shoots every 15 cronometer ticks
        Weapon.loadUnit(ship, 1, 15, true);
        // start shooting
        ship.toggleWeapon(fire);
        // set movement variable defaults
        vertDirection = 0;
        horDirection = 0;
        ship.bounded = true;
    }
}
