using System.Collections.Generic;
using GameLibrary.Platform.Game;
using GameLibrary.Services;
using GameLibrary.Platform;

namespace SB {
public class Battle : IPlayable {
    // references
    readonly Map map;
    readonly Queue queue;
    readonly Player player;

    // get set
    public Queue getQueue() {
        return queue;
    }
    public Map getMap() {
        return map;
    }
    public Player GetPlayer() {
        return player;
    }

    // main battle method on loop
    public void run() {
        while(true) {
            if(!Game.getContinueGame()) {
                endGame();
                break;
            }
            // run player and AI turn
            player.runTurn();
            turn();
            Game.printScreen(0);
        }
    }
    // run queue
    public void turn() {
        queue.run();
    }

    void endGame() {
        // run at end game
    }

    // constructor
    public Battle(int size_x, int size_y) {
        map = new Map(size_x, size_y, 5, 5);
        queue = new Queue();
        Game.setBattle(this);
        // toggle shooting to true
        player = new Player(true);
    }
}
}