using System;
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
public static class Game {
    // run algorithm avery battle cycle
    public static void runTurn() {

    }
    // change
    // start of game set up
    public static void setUp() {
        
    }
    // change
    // read textures.txt and process data
    public static bool loadGraphics() {

        return true;
    }


    // if false end game
    static bool continueGame = true;
    public static bool getContinueGame() {
        return continueGame;
    }
    // if escape key is pressed, end game
    public static bool processKey(ConsoleKeyInfo key) {
        if(key.Key == ConsoleKey.Escape) {
            endGame();
        }
        return false;
    }
    // set game to end on next battle cycle
    static void endGame() {
        continueGame = false;
    }

    
    // map battle queue references
    static Battle battle;
    public static Battle getBattle() {
        return battle;
    }
    public static void setBattle(Battle bat) {
        battle = bat;
    }
    public static Map getMap() {
        return battle.getMap();
    }
    public static Queue getQueue() {
        return battle.getQueue();
    }
}
