using GameLibrary.Graphics.Display;
using GameLibrary.Graphics;
using GameLibrary.Platform;

namespace SB {
static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        Game.setUp();
        Game.setScreen(
            new Screen(Terminal.Size_x - 75, Terminal.Size_y - 10, 
                new LegacyPrinter())
        );
        
        Battle bat = new Battle(Terminal.Size_x - 75, Terminal.Size_y - 10);
        Test.check();
        bat.run();
    }
}
    
}

