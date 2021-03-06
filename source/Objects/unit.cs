using System;
using System.Collections.Generic;

using GameLibrary.Graphics;
using GameLibrary.Services;
using GameLibrary.Services.Chronometrics;
using GameLibrary.Platform;
using SB.MiniGame;

namespace SB.Objects {
class Unit : Entity {
    public int Health { get; private set; }


    // receive an ammount of damage. if enough to kill try to end references for GC
    public void receiveDamage(int damage) {
        Health -= damage;
        if(Health <= 0) {
            die();
        }
    }
    void die() {
        foreach(Weapon w in weapons) {
            w.removeFromQueue();
        }
        weapons.Clear();
        delete();
        if(!this.Team) {
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

    // hitbox
    public ITexture<Entity> hitbox { get; protected set; }

    

    // IChronometric implementation
    protected override void everyTime() {}
    protected override void everyTick() {}

    // constructor
    // with texture
    public Unit(int pos_x, int pos_y, int delay, bool team, string textureKey, int health) : 
    base(pos_x, pos_y, delay, team, textureKey) {
        weapons = new List<Weapon>();
        Health = health;

        // derive hitbox from texture
        int size_y = Texture.GetLength(false);
        Entity [][] _hitbox = new Entity[size_y][];
        for(int y = 0; y < size_y; y++) {
            _hitbox[y] = new Entity[Texture.GetLength(y)];
            _hitbox[y].Fill(this);
        }
        hitbox = new ITexture<Entity>(_hitbox);

    }
}
}