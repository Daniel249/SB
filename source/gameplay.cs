using System;
using System.Collections.Generic;

using GameLibrary.Graphics.Display;
using GameLibrary.Externals;
//using GameLibrary.Graphics;
using GameLibrary.Services;
using GameLibrary.Platform;

namespace SB {
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
class SBGame : Game {
    public override void setUp() {
        loadGraphics("./textures.txt");
        // print instructions
        Terminal.PrintString(
            "move: up down keys, left key to stop    toggle fire: F    exit: esc", 
            5, 0
        );
    }

    // read textures.txt and process data
    static bool loadGraphics(string address) {
        Filereader filereader = new Filereader(address);
        filereader.processTextures();
        return true;
    }


    
    // map battle queue references
    static Battle battle;
    public static Player getPlayer() {
        return battle.getPlayer();
    }
    public static Battle getBattle() {
        return battle;
    }
    public static void setBattle(Battle bat) {
        battle = bat;
    }
    public static Map getMap() {
        return battle.getMap();
    }
    public static Queue getQueue() {
        return battle.getQueue();
    }
}
}