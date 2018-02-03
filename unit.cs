using System;
using System.Collections.Generic;

public class Unit : Entity {
    int health = 100;
    // reference toeither player or AI
    
    public void receiveDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            die();
        } else {
            Printer.printEntity(this);
        }
    }
    void die() {
        foreach(Weapon w in weapons) {
            w.removeFromQueue();
        }
        weapons.Clear();
        delete();
        if(!getTeam()) {
            Test.spawn();
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
    public Unit(int pos_x, int pos_y, int delay, bool team, string textureKey) : 
    base(pos_x, pos_y, delay, team, textureKey) {
        weapons = new List<Weapon>();
        Printer.printEntity(this);
    }
}
// bullets are Entitys in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
public class Bullet : Entity {
    readonly int attackDamage;

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

        if(team) {
            horizontalSpeed = 1;
        } else {
            horizontalSpeed = -1;
        }
    }
}