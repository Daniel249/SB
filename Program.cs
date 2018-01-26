using System;
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
        bat.run();


        // test reader
        // Filereader f = new Filereader("./textures.txt");
        // f.printTexture("main");
    }
}

