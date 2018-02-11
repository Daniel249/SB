using GameLibrary.Services.Chronometrics;

namespace SB {
public class Weapon : IChronometric {
    // position in unit
    readonly int position_x;
    readonly int position_y;
    // reference to unit
    Unit ship;
    int attackDamage;

    readonly bool direction;

    // implementation of IChronometric
    public override bool tick() {
        // check with inner cronometer
        if(_tick()) {
            fire();
            return true;
        } else { 
            return false;
        }
    }
    
    // spawn bullet. can be accessed directly altough build for checkFire with cronometer
    void fire() {
        Bullet bl = new Bullet(position_x + ship.getPos_x(), position_y + ship.getPos_y(),
                                attackDamage, direction, "bullet");
    }


    // set reference to new weapon in a unit
    public static void loadUnit(Unit u, int attackDamage, int attackDelay, bool direction, int verticalPosition) {
        // if enemy unit place weapon on left side
        int horizontalPosition = -3;
        if(direction) {
            horizontalPosition = u.getTexture().GetLength(verticalPosition);
        }
        Weapon w = new Weapon(horizontalPosition, verticalPosition, attackDelay, direction);
        w.attackDamage = attackDamage;
        u.setWeapon(w);
        w.ship = u;
    }
    // main load weapon to unit. based on texture key
    public static void loadUnit(Unit u, int attackDamage, int attackDelay, bool direction, string key) {
        // location book is static in Texture
        foreach(int verticalLocation in Database.assignWeaponLocation(key)) {
            // enemies spawn bullets away. not necessary
            int horizontalPosition = -3;
            if(direction) {
                // player unit spawn furthest to the right on selected row
                horizontalPosition = u.getTexture().GetLength(verticalLocation);
            }
            Weapon w = new Weapon(horizontalPosition, verticalLocation, attackDelay, direction);
            w.attackDamage = attackDamage;
            u.setWeapon(w);
            w.ship = u;
        }
    }


    // constructor
    public Weapon(int pos_x, int pos_y, int attackDelay, bool dir) : 
    base(attackDelay) {
        position_x = pos_x;
        position_y = pos_y;
        direction = dir;
    }
}
// change
// types of weapons
}