using System;
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
public static class Game {
    
    public static void runTurn() {
        // run algorithm avery battle cycle
    }
    public static void setUp() {
        loadGraphics();
    }

    // read textures.txt and process data
    static bool loadGraphics() {
        Filereader.processTextures();
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
