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
    public bool toggle() {
        isTicking = !isTicking;
        return isTicking;
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
    public Cronometer(int delay, bool isActive) {
        intervalDelay = delay;
        timeUnit = 0;
        isTicking = isActive;
    }
}



// has a chronometer with a certain interval
// aplicable to Things and weapons. all of which are referenced in Queue.List<IChronometric>
public abstract class IChronometric {
    Cronometer cronometro;
    // main method of IChronometrics
    public abstract bool tick();
    // ask cronometro
    protected bool _tick() {
        return cronometro.tick();
    }

    // toggle with and without parameter
    public void toggle(bool on_off) {
        cronometro.toggle(on_off);
    }
    public bool toggle() {
        return cronometro.toggle();
    }

    // Queue.List<IChronometric> interaction
    void addToQueue() {
        Game.getQueue().addToQueue(this);
    }
    public bool removeFromQueue() {
        return Game.getQueue().removeFromQueue(this);
    }

    // constructor
    public IChronometric(int delay) {
        cronometro = new Cronometer(delay, true);
        addToQueue();
    }
}