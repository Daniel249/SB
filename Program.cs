using System;


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Terminal.setSize(237, 72);
        Battle bat = new Battle(100, 60);
        // remove test
        for(int i = 0; i < bat.getMap().getSize_y(); i++) {
            bat.spawnThing(30,i);
        }
        foreach(Thing thi in bat.getList()) {
            Printer.printThing(thi);
        }
        // remove test
        bat.run();
        
    }
}

