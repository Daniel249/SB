using System.Collections.Generic;
public class Queue {
    List<Thing> unitsQueue;
    public bool run() {
        foreach(Thing thi in unitsQueue) {
            thi.turn();
        }
        return true;
    }
    
    // constructor
    public Queue() {
        unitsQueue = new List<Thing>();
    }
}
