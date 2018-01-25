using System;
using System.Collections.Generic;

public class Player {
    Unit ship;
    int vertDirection;
    int horDirection;
    bool constantMove;
    // main player method. runs once per battle cycle
    public void runTurn() {
        if(Console.KeyAvailable) {
            ConsoleKeyInfo letter = Console.ReadKey(true);
            proKey(letter);
        }
        if(constantMove) {
            moveShip();
        }
    }
    // process input key
    void proKey(ConsoleKeyInfo key) {
        if(Game.processKey(key)) {
            return;
        }
        switch(key.Key) {
            // left arrow
            case ConsoleKey.LeftArrow:
                horDirection = 0;
                vertDirection = 0;
                Console.WriteLine("izq");
                goto case ConsoleKey.Backspace;
            // right arrow
            case ConsoleKey.RightArrow:
                
                goto case ConsoleKey.Backspace;
            // down arrow
            case ConsoleKey.DownArrow:
                vertDirection = 1;
                goto case ConsoleKey.Backspace;
            // up arrow
            case ConsoleKey.UpArrow:
                vertDirection = -1;
                goto case ConsoleKey.Backspace;
            // letter m. toogle constantMove
            case ConsoleKey.M:
                constantMove = !constantMove;
                goto case ConsoleKey.Backspace;
            // if any of the above, move ship
            case ConsoleKey.Backspace:
                if(!constantMove) {
                    moveShip();
                }
            break;
        }
    }
    void moveShip() {
        ship.printMove(horDirection, vertDirection);
        // vertDirection = 0;
        // horDirection = 0;
    }
    // constructor
    public Player() {
        ship = new Unit(0, Game.getMap().getSize_y()/2);
        Weapon.loadUnit(ship, 5);
        Game.getBattle().getList().Add(ship);
        constantMove = true;
        vertDirection = 0;
        horDirection = 0;
    }
}
