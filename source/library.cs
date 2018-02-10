using System;

// interface to control units. player and AI inherit
interface IAgent {
    bool getConstantMove();
    bool getcConstantFire();
}

static class Test {
    // initialize phases
    static wave[] levels = new wave[] {
        new wave(8, "minor", 2, 80, 60),
        new wave(5, "middle", 5, 40, 160),
        new wave(2, "major", 10, 60, 300)
    };
    // current phase. resets at levels.Length
    static int counter = 0;
    // enemies left in current phase
    static int left = 0;
     // minigame. spawn 5 enemies
    public static void miniGame() {
        wave w = levels[counter];
        left = w.num;
        test(left, w);
    }
    // used in Main
    // checks left enemies and moves to next phase
    public static void check() {
        left--;
        if(left <= 0) {
            miniGame();
            counter++;
            if(counter == levels.Length) {
                counter = 0;
            }
        }
    }
    // loop enemy spawn
    public static void test(int num, wave wave) {
        for(int i = 0; i < num; i++) {
            spawn(wave);
        }
    }
    // used on test and on unit death
    static Random generator = new Random();
    // spawn a single enemy based on wave properties
    public static void spawn(wave wave) {
        // values
        string type = wave.type;
        int damage = wave.damage;
        int AS = wave.attackSpeed;
        int hp = wave.hp;

        int limit_x = Game.getMap().getSize_x() - 5;
        int limit_y = Game.getMap().getSize_y() - 5;

        int x = generator.Next(10, limit_x);
        int y = generator.Next(0, limit_y);

        Unit u = new Unit(x, y, 1, false, type, hp);
        Weapon.loadUnit(u, damage, AS, false, wave.type);
    }
    // not used 
    // spawn a single enemy
    public static void spawn(string textureKey) {
        Unit u = new Unit(Game.getMap().getSize_x() - 50, Game.getMap().getSize_y()/2, 1, false, "major", 2000);
    }
}
// wave properties
class wave {
    public int num;
    public string type;
    public int damage;
    public int attackSpeed;
    public int hp;
    public wave(int _num, string _type, int _dmg, int AS, int _hp) {
        num = _num;
        type = _type;
        damage = _dmg;
        attackSpeed = AS;
        hp = _hp;
    }
}