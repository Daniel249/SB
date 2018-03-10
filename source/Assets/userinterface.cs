using System;

using SB;
using GameLibrary.Graphics;

namespace SB.Assets {

class UserInterface {
    // references
    public static Label HealthLabel { get; private set; }
    public static Label InstructionsLabel { get; private set; }
    public static Label FPSLabel { get; private set; }
    // main method
    public static void setInterface() {
        AbstractForm userInterface = new AbstractForm(
            SBGame.getMainScreen(), SBGame.getMainScreen().Size_x - 50, 0);

        InstructionsLabel = new Label(userInterface, 5, 5, 
            "move: up down keys, left key to stop", 
            "toggle fire: F",
            "exit esc");

        HealthLabel = new Label(userInterface, 5, 15, new String(' ', 13));

        FPSLabel = new Label(userInterface, 5, 20, new String(' ', 35));
        // initialize in frame
        InstructionsLabel.Print();
    }
}
}