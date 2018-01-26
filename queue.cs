using System.Collections.Generic;
using System.Threading;

public class Queue {
    // unit bullet and weapon lists
    List<Thing> unitsQueue;
    public List<Bullet> bulletQueue;
    public List<Weapon> weaponQueue;

    // turn length in ms
    int turnDuration = 50;
    // number of cycles to reset to 0
    int intervalDelay = 30;

    // generics test
    public void addQueue<T>(List<T> list) {
        if(typeof(T) == typeof(Bullet)) {

        }
    }


    public bool run() {
    // iterate through copy of queue
    // if unit still on original queue run turn on unit
    // unit might have died or something idk
        
        // turn Length
        Thread.Sleep(turnDuration);
        for(int i = 0; i < bulletQueue.Count; i++) {
            Bullet u = bulletQueue[i];
                // check if atackspeed 
                if(modCounter(u.getMS(true))) {
                    u.travel();
                }
        }

        // weapon fire
        for(int i = 0; i < weaponQueue.Count; i++) {
            Weapon u = weaponQueue[i];
            u.checkFire();
        }

        passTime();
        return true;
    }


    int timeUnit = 30;

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
        }
    }
    

    // constructor
    public Queue() {
        unitsQueue = new List<Thing>();
        bulletQueue = new List<Bullet>();
        weaponQueue = new List<Weapon>();
    }
}


// attackSpeed mechanic
public class Cronometer {
    // number of cycles to reset to 0
    int intervalDelay;
    // present number of cycles
    int timeUnit;
    // return true when timeUnit reaches intervalDelay


    public bool tick() {
        timeUnit++;
        if(timeUnit == intervalDelay) {
            timeUnit = 0;
            return true;
        }
        return false;
    }


    // contructor
    public Cronometer(int delay) {
        intervalDelay = delay;
        timeUnit = 0;
    }
}
