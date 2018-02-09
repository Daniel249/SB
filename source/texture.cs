using System;
// using System.Collections.Generic;

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
    // non '\0' spaces printed and deleted
    char[][] code;

    // get set
    public void setCode(char[][]newCode) {
        code = newCode;
    }
    public char[][] getCode() {
        // not used
        return code;
    }
    // get at certain coordinates
    public char getCode(int coord_y, int coord_x) {
        return code[coord_y][coord_x];
    }
    public char[] getCode(int coord_y) {
        return code[coord_y];
    }
    // for compatibility with 2d char array times
    // horizontal length of texture
    public int GetLength(int dimension_y) {
        return code[dimension_y].Length;
    }
    int rank_x;
    // return max x length or y length
    public int GetLength(bool isRank) {
        if(isRank) {
            return rank_x;
        } else {
            return code.Length;
        }
    }
    void calcRank() {
        int maxRank = 0;
        for(int y = 0; y < code.Length; y++) {
            if(maxRank < code[y].Length) {
                maxRank = code[y].Length;
            }
        }
        rank_x =  maxRank;
     }


    // constructor
    public Texture(char[][]_code, ConsoleColor bcolor, ConsoleColor fcolor) {
        code = _code;
        calcRank();
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}