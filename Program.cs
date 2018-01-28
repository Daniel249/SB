﻿using System;
using System.Collections.Generic;


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        Terminal.setSize();
        Battle bat = new Battle(200, 60);
        foreach(Thing thi in bat.getList()) {
            Printer.printThing(thi);
        }
        // remove test
        test(5);
        bat.run();

        // test reader
        // Filereader f = new Filereader("./textures.txt");
        // f.printTexture("main");
    }
    public static void test(int num) {
        Random generator = new Random();
        int limit_x = Game.getMap().getSize_x() - 5;
        int limit_y = Game.getMap().getSize_y() - 5;

        for(int i = 0; i < num; i++) {
            int x = generator.Next(0, limit_x);
            int y = generator.Next(0, limit_y);

            Unit u = new Unit(x, y, 1);
            Game.getBattle().getList().Add(u);
        }
    }
}

