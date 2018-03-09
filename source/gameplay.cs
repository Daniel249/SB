using System;
using System.Collections.Generic;

using GameLibrary.Graphics.Display;
using GameLibrary.Externals;
using GameLibrary.Graphics;
using GameLibrary.Services;
using GameLibrary.Platform;

namespace SB {
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
class SBGame : Game {

    // main set up
    public void setUp(bool printerdefiner) {
        loadGraphics(@"./textures.txt");

        //
        Printer MainPrinter;
        if(printerdefiner) {
            MainPrinter = new LegacyPrinter();
        } else {
            MainPrinter = new LinePrinter();
        }
        // set screen
        // screen position is 5,5 at screen constructor
        // map interface is created at 0,0
        Screen screen = new Screen(Terminal.Size_x - 10, Terminal.Size_y - 10, MainPrinter);
        SBGame.setScreen(screen);

        // initialize map

        Map map = new Map(getMainScreen().Size_x - 50, getMainScreen().Size_y, 5, 5);
        Battle bat = new Battle(map);

        AbstractForm abstractForm = new MapInterface(map, screen, 0, 0);
        bat.guiMap = abstractForm;
        //

        // set player and print it 
        bat.setPlayer(new Player(true));
        //

        setInterface();
    }

    //helpers 

    // read textures.txt and process data
    static bool loadGraphics(string address) {
        Filereader filereader = new Filereader(address);
        filereader.processTextures();
        return true;
    }

    // set up interface
    static void setInterface() {
        AbstractForm userInterface = new AbstractForm(getMainScreen(), getMainScreen().Size_x - 50, 0);
        Label label1 = new Label(userInterface, 5, 5, 
            "move: up down keys, left key to stop", 
            "toggle fire: F",
            "exit esc");

        // initialize in frame
        label1.Parent.updateprint(label1, label1.Position_x, label1.Position_y);
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