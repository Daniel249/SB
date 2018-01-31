using System;

public class Texture {
    // color
    ConsoleColor ForegroundColor;
    ConsoleColor BackgroundColor;

    // get set
    public ConsoleColor getBackgroundColor() {
        return BackgroundColor;
    }
    public ConsoleColor getForegroundColor() {
        return ForegroundColor;
    } 
    public void setBackgroundColor(ConsoleColor _backgroundColor) {
        BackgroundColor = _backgroundColor;
    }
    public void setForegroundColor(ConsoleColor _foregroundColor) {
        ForegroundColor = _foregroundColor;
    }


    // ascii code
    // nont '\0' spaces printed and deleted
    char[,] code;

    // get set
    public void setCode(char[,] newCode) {
        code = newCode;
    }
    public char[,] getCode() {
        return code;
    }
    // get at certain coordinates
    public char getCode(int coord_y, int coord_x) {
        return code[coord_y, coord_x];
    }

    public int GetLength(int dimension) {
        return code.GetLength(dimension);
    }

    // change
    // transform string array to 2d char array
     public static char[,] parseTexture(string[] stringAray) {
         return null;
     }
     // change get texture from texture file
     public static char[,] processTexture(string[] file, string addressName) {
         return null;
     }


    // constructor
    public Texture(char[,] _code, ConsoleColor bcolor, ConsoleColor fcolor) {
        code = _code;
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}