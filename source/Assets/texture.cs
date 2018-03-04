using System;
using GameLibrary.Graphics;
namespace SB.Assets {
public class LegacyTexture : ITexture<char> {
    // color
    public ConsoleColor ForegroundColor { get; private set; }
    public ConsoleColor BackgroundColor { get; private set; }


    // constructor
    public LegacyTexture(char[][] _code, ConsoleColor bcolor, ConsoleColor fcolor)
     : base(_code) {
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}
}