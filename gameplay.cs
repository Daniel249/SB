using System;

public static class Game {
    
    public static void runTurn() {

    }
    public static void setUp() {
        
    }
    public static bool loadGraphics() {

        return true;
    }
    // if false end game
    static bool continueGame = true;
    public static bool getContinueGame() {
        return continueGame;
    }
    public static bool processKey(ConsoleKeyInfo key) {
        if(key.Key == ConsoleKey.Escape) {
            endGame();
        }
        return false;
    }
    static void endGame() {
        continueGame = false;
    }
    // map and battle references
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
}
