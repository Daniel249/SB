using System.Collections.Generic;
using GameLibrary.Platform;
using GameLibrary.Services;

namespace SB {

// constains other parts of the game 
// and initializes them on contruction
public class Battle : IPlayable { // can run
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
    public Player getPlayer() {
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

    public void endGame() {
        // run at end game
    }

    // constructor
    public Battle(int size_x, int size_y) {
        // initialize map, queue 
        // set global reference before Player initialization
        map = new Map(size_x, size_y, 5, 5);
        new MapInterface(map, Game.getMainScreen(), 5, 5, size_x, size_y);
        queue = new Queue();
        Game.setBattle(this);
        // toggle shooting to true
        player = new Player(true);
    }
}
}