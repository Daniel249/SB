using System;
using GameLibrary.Platform;
using SB.Objects;
namespace SB.MiniGame {

static class Test {
    // initialize phases
    static wave[] levels = new wave[] {
        // new wave(num, type, hp, dmg, as)
        new wave(10, "minor", 60, 3, 80),
        new wave(5, "middle", 160, 5, 50),
        new wave(2, "major", 400, 10, 60)
    };
    // current phase. resets at levels.Length
    static int counter = 0;
    // enemies left in current phase
    static int left = 0;
    // minigame. spawn 5 enemies
    public static void miniGame() {
        wave wave = levels[counter];
        // spawn num ammount of enemies with properties stored in w
        test(wave);
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
    public static void test(wave wave) {
        left = wave.num;
        for(int i = 0; i < wave.num; i++) {
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

        int limit_x = SBGame.getMap().Size_x - 5;
        int limit_y = SBGame.getMap().Size_y - 5;

        int x = generator.Next(10, limit_x);
        int y = generator.Next(0, limit_y);

        Unit u = new Unit(x, y, 50, false, type, hp);
        Weapon.loadUnit(u, damage, AS, false, wave.type);
    }
    // not used 
    // spawn a single enemy
    public static void spawn(string textureKey) {
        Unit u = new Unit(SBGame.getMap().Size_x - 50, SBGame.getMap().Size_y/2, 1, false, "major", 2000);
    }
}
// wave properties
class wave {
    public int num;
    public string type;
    public int damage;
    public int attackSpeed;
    public int hp;
    public wave(int _num, string _type, int _hp, int _dmg, int AS) {
        num = _num;
        type = _type;
        damage = _dmg;
        attackSpeed = AS;
        hp = _hp;
    }
}
}