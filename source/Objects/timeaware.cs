using GameLibrary.Platform;
using GameLibrary.Services.Chronometrics;
namespace SB.Objects {

// Interface implementation + add and remove from queue
// has a chronometer with a certain interval
// aplicable to Entitys and weapons. all of which are referenced in Queue.List<IChronometric>
public abstract class TimeAware : IChronometric {
    Chronometer cronometro;
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
    public void addToQueue() {
        SBGame.getQueue().addToQueue(this);
    }
    public bool removeFromQueue() {
        return SBGame.getQueue().removeFromQueue(this);
    }

    // constructor
    public TimeAware(int delay) {
        cronometro = new Chronometer(delay, true);
        addToQueue();
    }
}
}