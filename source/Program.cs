using GameLibrary.Graphics.Display;
using GameLibrary.Graphics;
using GameLibrary.Platform;
using GameLibrary.Interface;
using SB.MiniGame;

namespace SB {
static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        SBGame Game = new SBGame();
        Game.setUp();


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
        SBGame.setScreen(
            new Screen(Terminal.Size_x - 75, Terminal.Size_y - 10, 
                MainPrinter)
        );
        
        Battle bat = new Battle(Terminal.Size_x - 75, Terminal.Size_y - 10);
        
        // guinterface must be defined after battle, becuse 
        GUInterface gUInterface;
        AbstractForm abstractForm;
        if(definer) {
            gUInterface = new LegacyInterface(SBGame.getMap(), SBGame.getMainScreen(), 0, 0, Terminal.Size_x - 75, Terminal.Size_y - 10);
            abstractForm = null;
        } else {
            gUInterface = new MapInterface(SBGame.getMap(), SBGame.getMainScreen(), 0, 0, Terminal.Size_x - 75, Terminal.Size_y - 10);
            abstractForm = new newMapInterface(SBGame.getMap(), SBGame.getMainScreen(), 0, 0);
        }
        bat.guinterface = gUInterface;
        bat.guiMap = abstractForm;

        // set player and print it 
        bat.setPlayer(new Player(true));

        Test.check();
        bat.run();
    }
}
    
}

