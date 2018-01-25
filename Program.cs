using System;
using System.Collections.Generic;


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Terminal.setSize(237, 72);
        Battle bat = new Battle(100, 60);
        foreach(Thing thi in bat.getList()) {
            Printer.printThing(thi);
        }
        // remove test
        bat.run();


        // test reader
        // Filereader f = new Filereader("./textures.txt");
        // f.printTexture("main");
    }
}

