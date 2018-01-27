// attackSpeed mechanic
public class Cronometer {
    // number of cycles to reset to 0
    readonly int intervalDelay;
    // present number of cycles
    int timeUnit;
    // if false, tick returns false
    bool isTicking;
    
    // set isTicking
    public void toggle(bool isTick) {
        isTicking = isTick;
    }
    
    // return true when timeUnit reaches intervalDelay
    public bool tick() {
        if(!isTicking) {
            return false;
        }
        // tick and check
        timeUnit++;
        if(timeUnit == intervalDelay) {
            timeUnit = 0;
            return true;
        } else {
            return false;
        }
    }


    // contructor
    public Cronometer(int delay) {
        intervalDelay = delay;
        timeUnit = 0;
    }
}


public class Texture {

}


// interface to control units. player and AI inherit
interface IAgent {
    bool getConstantMove();
    bool getcConstantFire();
}