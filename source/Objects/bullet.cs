using System;
using System.Collections.Generic;

using GameLibrary;
using GameLibrary.Services.Chronometrics;
using GameLibrary.Platform;

namespace SB.Objects {

// bullets are Entitys in constant movement
// they are printed but not referenced in map, so nothing interacts with them
// they do interact with other things through references in map
class Bullet : Entity {
    readonly int attackDamage;
    // check for reference in map
    public bool checkCollision() {
        Entity target = SBGame.getMap().getMap(Position_x, Position_y);
        // map populated only by units, no bullets
        if(target != null && target.Team != this.Team) {
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