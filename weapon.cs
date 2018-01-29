
public class Weapon : IChronometric {
    // position in unit
    int position_x;
    int position_y;
    // reference to unit
    Unit ship;
    int attackDamage;


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
        Bullet bl = new Bullet(position_x + ship.getPos_x(), position_y + ship.getPos_y(), 20);
    }


    // set reference to this weapon in a unit
    public static void loadUnit(Unit u, int attackDamage, int attackDelay) {
        Weapon w = new Weapon(u.getCode().GetLength(1), 0, attackDelay);
        w.attackDamage = attackDamage;
        u.setWeapon(w);
        w.ship = u;
    }


    // constructor
    public Weapon(int pos_x, int pos_y, int attackDelay) : 
    base(attackDelay) {
        position_x = pos_x;
        position_y = pos_y;
    }
}
// change
// types of weapons
