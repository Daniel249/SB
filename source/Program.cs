
using GameLibrary.Graphics;
using GameLibrary.Platform;
using SB.MiniGame;

namespace SB {
static class Program {
    static void Main(string[] args) {

        Terminal.setSize();
        SBGame Game = new SBGame();
        // bool ? LegacyPrinter : LinePrinter
        Game.setUp(false);

        Test.check();
        SBGame.getBattle().run();
    }
}
}