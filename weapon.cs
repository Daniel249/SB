
public class Weapon {
    // position in unit
    int position_x;
    int position_y;
    // reference to unit
    Unit ship;
    int attackDamage;
    // timer. attackSpeed mechanic
    Cronometer cronometer;


    // spawn bullet. can be accessed directly altough build for checkFire with cronometer
    public void fire() {
        Bullet bl = new Bullet(position_x + ship.getPos_x(), position_y + ship.getPos_y());
        // attackDamage = 5;
    }
    // check cronometer to fire
    public void checkFire() {
        // check constantFire first
        if(cronometer.tick()) {
            fire();
        }
    }
    public void toggleFire(bool toggle) {
        cronometer.toggle(toggle);
    }


    // set reference to this weapon in a unit
    public static void loadUnit(Unit u, int AS) {
        Weapon w = new Weapon(u.getCode().GetLength(0), 0, AS);
        u.setWeapon(w);
        w.ship = u;
    }


    // constructor
    public Weapon(int pos_x, int pos_y, int AS) {
        Game.getQueue().weaponQueue.Add(this);
        position_x = pos_x;
        position_y = pos_y;
        cronometer = new Cronometer(AS);
    }
}
// change
// types of weapons
