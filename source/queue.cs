using System.Collections.Generic;
using System.Threading;
using GameLibrary;
using GameLibrary.User.Interface;
using GameLibrary.Graphics.Printer;

namespace SB {
public class Queue {
    // list of units, bullets and weapons
    readonly List<IChronometric> chronoQueue;
    // turn length in ms. Process sleeps that ammoung once per run
    const int sleepDuration = 10;
    // number of cycles to reset to 0
    const int intervalDelay = 30;

    public void addToQueue(IChronometric chrono) {
        chronoQueue.Add(chrono);
    }
    public bool removeFromQueue(IChronometric chrono) {
        return chronoQueue.Remove(chrono);
    }

    public bool run() {
        // turn Length
        // Thread.Sleep(sleepDuration);

        // all bullets move
        for(int i = 0; i < chronoQueue.Count; i++) {
            IChronometric u = chronoQueue[i];
            // check chronometer
            u.tick();               
        }
        passTime();
        return true;
    }


    int timeUnit = 0;
    public bool modCounter(int AS) {
        if(timeUnit % AS == 0) {
            return true;
        }
        return false;
    }


    void passTime() {
        timeUnit++;
        if(timeUnit == intervalDelay) {
            timeUnit = 0;
            Terminal.PrintString(watch.getTime(), Terminal.getSize_x()-40, 0, Terminal.getDefaultBack(), Terminal.getDefaultFore());
            Terminal.PrintString("healt: " + Game.getPlayer().getHealth(), Terminal.getSize_x()-80, 0, Terminal.getDefaultBack(), Terminal.getDefaultFore());
        }
    }
    
    Watch watch;
    // constructor
    public Queue() {
        chronoQueue = new List<IChronometric>();
        watch = new Watch();
    }
}
}