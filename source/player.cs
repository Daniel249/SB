using System;
using System.Collections.Generic;

using GameLibrary.Platform;
using GameLibrary.Agents;
using SB.Objects;

namespace SB {
public class Player : IAgent {
    readonly Unit ship;
    public int getHealth() {
        return ship.Health;
    }


    // save movement direction until movement method
    int vertDirection;
    int horDirection;

    // set directions in ship for next succesful tick
    void moveShip() {
        ship.move(horDirection, vertDirection);
    }
    
    
    // main player method. runs once per battle cycle
    public void runTurn() {
        //if(Console.KeyAvailable) {
            ConsoleKeyInfo letter = new ConsoleKeyInfo();
            // get last of all accumulated keys
            while (Console.KeyAvailable) {
                letter = Console.ReadKey(true);
            }
            proKey(letter);
       // }
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


    // constructor
    public Player(bool fire) {
        // instantiate ship and load a weapon to it
        ship = new Unit(0, Game.getMap().Size_y/2, 5, true, "main", 500);
        // load weapon to ship. shoots every 15 cronometer ticks
        Weapon.loadUnit(ship, 20, 15, true, "main");
        // start shooting
        ship.toggleWeapon(fire);
        // set movement variable defaults
        vertDirection = 0;
        horDirection = 0;
    }
}
}