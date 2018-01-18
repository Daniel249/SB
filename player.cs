using System;
using System.Collections.Generic;

public class Player {
    Unit ship;
    // 0: iddle. 1: left. 2: right
    int direction;
    bool constantMove;
    public void runTurn() {
        if(Console.KeyAvailable) {
            ConsoleKeyInfo letter = Console.ReadKey(true);
            proKey(letter);
        }
        if(constantMove) {
            moveShip();
        }
    }
    void proKey(ConsoleKeyInfo key) {
        if(Game.processKey(key)) {
            return;
        }
        if(key.Key == ConsoleKey.LeftArrow) {
            direction = 1;
            Console.WriteLine("izq");
            Console.WriteLine("nonstop");
        } else if(key.Key == ConsoleKey.RightArrow) {
            direction = 2;
            Console.WriteLine("der");
        } else if(key.Key == ConsoleKey.DownArrow) {
            direction = 0;
            Console.WriteLine("stop");
        }
        switch(key.Key) {
            case ConsoleKey.LeftArrow:
                direction = 1;
                goto case ConsoleKey.RightArrow;
            case ConsoleKey.RightArrow:
                direction = 2;
                goto case ConsoleKey.DownArrow;
            case ConsoleKey.DownArrow:
                direction = 0;
                goto case ConsoleKey.Backspace;
            // if any of the above
            case ConsoleKey.Backspace:
                if(!constantMove) {
                    moveShip();
                }
            break;
        }
    }
    void moveShip() {

    }
}
