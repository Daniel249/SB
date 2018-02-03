using System;
using System.Collections.Generic;

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
    char[][] code;

    // get set
    public void setCode(char[][]newCode) {
        code = newCode;
    }
    public char[][]getCode() {
        return code;
    }
    // not used
    // get at certain coordinates
    public char getCode(int coord_y, int coord_x) {
        throw new System.NotSupportedException();
        //return code[coord_y][coord_x];
    }
    // for compatibility with 2d char array times
    // horizontal length of texture
    public int GetLength(int dimension_y) {
        return code[dimension_y].Length;
    }
    public int GetLength() {
        return code.Length;
    }

    // statics
    // textures dictionary
    static Dictionary<string, char[][]> textures;
    public static void setTextures(Dictionary<string, char[][]> _textures) {
        textures = _textures;
    }


     // main texture finder
     public static char[][]assignTexture(string addressName) {
         // search name on dictionary
         char[][]newTexture;
         // if textre dictinoary initialized, search it
         if(textures != null && textures.TryGetValue(addressName, out newTexture)) {
             return newTexture;
         } else if(addressName == "bullet") {
             return defaultBullet;
         } else {
             return defaultTexture;
         }
     }
    

    
    // default texture. used when no name found on texture dictionary
    static char[][]defaultTexture = new char[][]{
        new char[] {'*','*','*'},
        new char[] {'*','*','*'},
        new char[] {'*','*','*'}
    };
    static char[][]defaultBullet = new char[][]{
        new char[] {'a','b','c'}
    };
    // constructor
    public Texture(char[][]_code, ConsoleColor bcolor, ConsoleColor fcolor) {
        code = _code;
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}