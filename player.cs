using System;
using System.Collections.Generic;

public class Player {
    readonly Unit ship;
    public int getHealth() {
        return ship.getHealth();
    }
    // save movement direction until movement method
    int vertDirection;
    int horDirection;
    
    
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
            default:
                // Terminal.PrintString("unsupportd key", 80, 0, ConsoleColor.Black, ConsoleColor.White);
                break;
        }
    }


    void moveShip() {
        ship.move(horDirection, vertDirection);
    }


    // constructor
    public Player(bool fire) {
        // instantiate ship and load a weapon to it
        ship = new Unit(0, Game.getMap().getSize_y()/2, 5, true, "main", 1000);
        // load weapon to ship. shoots every 15 cronometer ticks
        Weapon.loadUnit(ship, 20, 15, true, 3);
        // start shooting
        ship.toggleWeapon(fire);
        // set movement variable defaults
        vertDirection = 0;
        horDirection = 0;
    }
}
