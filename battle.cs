using System.Collections.Generic;
public class Battle {
    Map map;
    Queue queue;
    Player player;
    List<Thing> list = new List<Thing>();
    
    // get set
    public Queue getQueue() {
        return queue;
    }
    public Map getMap() {
        return map;
    }
    public List<Thing> getList() {
        return list;
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
            // run gameplay extras
            // Game.runTurn();
        }
    }
    // run queue
    public bool turn() {
        return queue.run();
    }

    public void spawnThing(int pos_x, int pos_y) {
        Thing thi = new Unit(pos_x, pos_y);
        list.Add(thi);
    }

    void endGame() {

    }
    
    // constructor
    public Battle(int size_x, int size_y) {
        map = new Map(size_x, size_y, 5, 5);
        queue = new Queue();
        Game.setBattle(this);        
        player = new Player(true);
    }
}
