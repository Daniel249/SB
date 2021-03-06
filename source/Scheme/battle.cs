using System.Collections.Generic;
using GameLibrary.Platform;
using GameLibrary.Services;
using GameLibrary.Graphics;

namespace SB {

// constains other parts of the game 
// and initializes them on contruction
class Battle : IPlayable { // can run
    // references
    readonly Map map;
    readonly Queue queue;
    Player player;

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
    public void setPlayer(Player pl) {
        player = pl;
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
            SBGame.printScreen();
        }
    }
    // run queue
    public void turn() {
        queue.run();
    }

    public void endGame() {
        // run at end game
    }

    public AbstractForm guiMap { get; set; }
    // constructor
    public Battle(Map mapp) {
        // initialize map, queue 
        // set global reference before Player initialization
        map = mapp;
        queue = new Queue();
        SBGame.setBattle(this);
    }
}
}