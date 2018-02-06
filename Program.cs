using System;
using System.Collections.Generic;


static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        Game.setUp();
        
        Battle bat = new Battle(Terminal.getSize_x() - 75, Terminal.getSize_y() - 10);
        Test.check();
        bat.run();
    }
}

