using System;

// interface to control units. player and AI inherit
interface IAgent {
    bool getConstantMove();
    bool getcConstantFire();
}

static class Test {
    public static char[,] test(Entity entity, int x, int y) {
        char [,] testCode;
        // test code for units. 3x3 asterisks
        if(entity is Unit) {
            testCode = new char[x,y];
            for (int i = 0; i < y; i++) {
                for (int j = 0; j < x; j++) {
                    testCode[j,i] = '*';
                }
            }
            return testCode;
        } else if(entity is Bullet) {
        // test code for bullets 'abc'
            testCode = new char[,] {
            {'a','b','c'} 
        };
        } else {
            testCode = new char[,] { {'O'} };
        }
        return testCode;
    }

    // minigame. spawn 5 enemies
        // used on Main
    public static void test(int num) {
        for(int i = 0; i < num; i++) {
            spawn();
        }
    }
    // used on test and on unit death
    static Random generator = new Random();
    public static void spawn() {
        
        int limit_x = Game.getMap().getSize_x() - 5;
        int limit_y = Game.getMap().getSize_y() - 5;

        int x = generator.Next(10, limit_x);
        int y = generator.Next(0, limit_y);

        Unit u = new Unit(x, y, 1, false, "minor");
        Weapon.loadUnit(u, 0, 45, false);
    }
    // spawn a single enemy
    public static void spawn(string textureKey) {
        Unit u = new Unit(Game.getMap().getSize_x() - 50, Game.getMap().getSize_y()/2, 1, false, "major");
    }
}