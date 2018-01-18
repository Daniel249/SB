
public class Battle {
    Map map;
    Queue queue;
    Player player;
    
    // get set
    public Queue getQueue() {
        return queue;
    }
    public Map getMap() {
        return map;
    }
    // run battle
    public bool turn() {
        return queue.run();
    }
    public void run() {
        while(true) {
            if(!Game.getContinueGame()) {
                endGame();
                break;
            }
            // run player and AI turn
            player.runTurn();
            Game.runTurn();

            turn();
        }
    }
    void endGame() {

    }
    // constructor
    public Battle() {
        player = new Player();
        map = new Map(100, 60, 5, 5);
        queue = new Queue();
        
    }
}
