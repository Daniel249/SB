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
}