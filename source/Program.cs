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

        bool definer = true;
        Printer MainPrinter;
        if(definer) {
            MainPrinter = new LegacyPrinter();
        } else {
            MainPrinter = new LinePrinter();
        }
        
        // set screen
        // map interface is created at 0,0
        SBGame.setScreen(
            new Screen(Terminal.Size_x - 75, Terminal.Size_y - 10, 
                MainPrinter)
        );
        
        Battle bat = new Battle(Terminal.Size_x - 75, Terminal.Size_y - 10);
        

        AbstractForm abstractForm;
        abstractForm = new MapInterface(SBGame.getMap(), SBGame.getMainScreen(), 0, 0);
        
        bat.guiMap = abstractForm;

        // set player and print it 
        bat.setPlayer(new Player(true));

        Test.check();
        bat.run();
    }
}
    
}

