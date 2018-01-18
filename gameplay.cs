using System;

public static class Game {
    static Battle battle;
    public static Battle GetBattle() {
        return battle;
    }
    public static void runTurn() {

    }

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
}
