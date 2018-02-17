using GameLibrary.Graphics.Display;
using GameLibrary.Graphics;
using GameLibrary.Platform;
using GameLibrary.Interface;

namespace SB {
static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        Game.setUp();

        // define printer in main screen
        // Printer MainPrinter = new LegacyPrinter();
        Printer MainPrinter = new LinePrinter();
        
        Game.setScreen(
            new Screen(Terminal.Size_x - 75, Terminal.Size_y - 10, 
                MainPrinter)
        );
        
        Battle bat = new Battle(Terminal.Size_x - 75, Terminal.Size_y - 10);

        // set GUI. choose one based on LegacyPrinter or standard
        gUInterface = new MapInterface(Game.getMap(), Game.getMainScreen(), 0, 0, Terminal.Size_x - 75, Terminal.Size_y - 10);
        // gUInterface = new LegacyInterface(Game.getMap(), Game.getMainScreen(), 0, 0, Terminal.Size_x - 75, Terminal.Size_y - 10);

        bat.guinterface = gUInterface;
        bat.setPlayer(new Player(true));

        Test.check();
        bat.run();
    }
    public static GUInterface gUInterface;
}
    
}

