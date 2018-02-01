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

     // main texture finder
     public static char[,] assignTexture(string addressName) {
         // search name on dictionary
         List<string> rawTexture = Filereader.getRawTexture(addressName);
         char[,] newTexture = defaultTexture;
         // if rawText
         if(rawTexture != null) {
             newTexture = parseTexture(rawTexture);
         }
         return newTexture;
     }
    // transform string array to 2d char array
    static char[,] parseTexture(List<string> stringList) {
         char[,] newCode;
         int dimension_x = 0;
         int dimension_y = stringList.Count;
         // set horizontal length
         foreach(string str in stringList) {
             if(str.Length > dimension_x) {
                 dimension_x = str.Length;
             }
         }
        newCode = new char[dimension_y, dimension_x];
        for (int y = 0; y < dimension_y; y++) {
            char[] actualString = stringList[y].ToCharArray();
            for(int x = 0; x < dimension_x; x++) {
                // set char array location to a character or '\0'
                if(x >= actualString.Length || actualString[x] == ' ') {
                    newCode[y,x] = '\0';
                } else {
                    newCode[y,x] = actualString[x];
                }
            }
        }
         return newCode;
     }

    // default texture. used when no name found on texture dictionary
    static char[,] defaultTexture = new char[,] {
        {'*','*','*'},
        {'*','*','*'},
        {'*','*','*'},
    };
    // constructor
    public Texture(char[,] _code, ConsoleColor bcolor, ConsoleColor fcolor) {
        code = _code;
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}