using System;
using System.Collections.Generic;


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        Terminal.setSize();
        Battle bat = new Battle(Terminal.getSize_x() - 75, Terminal.getSize_y() - 10);
        test(5);
        bat.run();

        // test reader
        // Filereader f = new Filereader("./textures.txt");
        // f.printTexture("main");
    }
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

        Unit u = new Unit(x, y, 1);
    }
}

