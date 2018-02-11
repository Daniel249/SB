using System;
using System.Collections.Generic;

using GameLibrary;
using GameLibrary.Graphics.Printer;
using GameLibrary.Services.Chronometrics;
using GameLibrary.Platform.Game;

namespace SB {
public class Unit : Entity {
    int healthPoints;
    public int getHealth() {
        return healthPoints;
    }
    // reference toeither player or AI
    
    public void receiveDamage(int damage) {
        healthPoints -= damage;
        if(healthPoints <= 0) {
            die();
        }
    }
    void die() {
        foreach(Weapon w in weapons) {
            w.removeFromQueue();
        }
        weapons.Clear();
        delete();
        if(!getTeam()) {
            Test.check();
        }
    }

    // reference to weapon
    readonly List<Weapon> weapons;
    public void setWeapon(Weapon weapon) {
        weapons.Add(weapon);
    }
    public List<Weapon> getWeapon() {
        return weapons;
    }
    public void toggleWeapon(bool isFiring) {
        foreach(Weapon w in weapons) {
            w.toggle(isFiring);
        }
    }
    public void toggleWeapon() {
        foreach(Weapon w in weapons) {
            w.toggle();
        }
    }

    // IChronometric implementation
    protected override void everyTime() {}
    protected override void everyTick() {}

    // constructor
    // with texture
    public Unit(int pos_x, int pos_y, int delay, bool team, string textureKey, int health) : 
    base(pos_x, pos_y, delay, team, textureKey) {
        weapons = new List<Weapon>();
        Printer.printEntity(this);
        healthPoints = health;

    }
}
// bullets are Entitys in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
public class Bullet : Entity {
    readonly int attackDamage;
    // check for reference in map
    public bool checkCollision() {
        Entity target = Game.getMap().getMap(position_x, position_y);
        // map populated only by units, no bullets
        if(target != null && target.getTeam() != this.getTeam()) {
            ((Unit)target).receiveDamage(attackDamage);
            delete();
            return true;
        } else {
            return false;
        }
    }

    // IChronometric implementation
    protected override void everyTime() {}
    protected override void everyTick() {
        checkCollision();
    }

    // constructor
    public Bullet(int pos_x, int pos_y, int attackDmg, bool team, string textureKey) : 
    base(pos_x, pos_y, 1, team, textureKey) {
        attackDamage = attackDmg;
        verticalSpeed = 0;
        // movement to left or right
        if(team) {
            horizontalSpeed = 1;
        } else {
            horizontalSpeed = -1;
        }
    }
}
}