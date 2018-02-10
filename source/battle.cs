using System.Collections.Generic;
public class Battle {
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
        }
    }
    // run queue
    public bool turn() {
        return queue.run();
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