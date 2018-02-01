
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


    // set reference to this weapon in a unit
    public static void loadUnit(Unit u, int attackDamage, int attackDelay, bool direction) {
        Weapon w = new Weapon(u.getTexture().GetLength(1), 0, attackDelay, direction);
        w.attackDamage = attackDamage;
        u.setWeapon(w);
        w.ship = u;
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
