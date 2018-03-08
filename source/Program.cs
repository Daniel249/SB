using GameLibrary.Graphics.Display;
using GameLibrary.Graphics;
using GameLibrary.Platform;
using SB.MiniGame;

namespace SB {
static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        SBGame Game = new SBGame();
        Game.setUp();

        // test
        // define between legacy- and lineprinter

        bool definer = false;
        Printer MainPrinter;
        if(definer) {
            MainPrinter = new LegacyPrinter();
        } else {
            MainPrinter = new LinePrinter();
        }
        
        // set screen
        // map interface is created at 0,0
        Screen screen = new Screen(Terminal.Size_x - 75, Terminal.Size_y - 10, MainPrinter);
        SBGame.setScreen(screen);
        
        Map map = new Map(Terminal.Size_x - 75, Terminal.Size_y - 10, 5, 5);
        Battle bat = new Battle(map);

        AbstractForm abstractForm = new MapInterface(map, screen, 0, 0);
        bat.guiMap = abstractForm;
        

        // set player and print it 
        bat.setPlayer(new Player(true));

        Test.check();
        bat.run();
    }
}
    
}

