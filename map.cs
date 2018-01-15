using System;
using System.Collections.Generic;

public class Map {
    // map size
    int size_x;
    int size_y;
    // get set
    public int getSize_x() {
        return size_x;
    }
    public int getSize_y() {
        return size_y;
    }
    // map location
    int location_x;
    int location_y;

    // 2d jagged array 150*80. first dimension y. second dimension x
    Thing[,] mapp;
    // get map reference
    public Thing[,] getMap() {
        return mapp;
    }
    // get unit in map
    public Thing getMap(int pos_x, int pos_y) {
        if(!checkLocation(pos_x, pos_y)) {
            return null;
        }
        return mapp[pos_x, pos_y];
    }
    // set unit in map
    public void setMap(Unit u, int pos_x, int pos_y) {
        if(!checkLocation(pos_x, pos_y)) {
            return;
        }
        mapp[pos_x, pos_y] = u;
    }


    // check coordinates
    bool checkLocation(int pos_x, int pos_y) {
        if(pos_x < 0 || pos_x >= size_x) {
            return false;
        }
        if(pos_y < 0 || pos_y >= size_y) {
            return false;
        }
        return true;
    }

    // print and erase
    public void printTo(int pos_x, int pos_y, string code, ConsoleColor fcolor, ConsoleColor bcolor) {
        printer.PrintText(code, pos_x, pos_y, bcolor);
    }
    public void eraseFrom(int pos_x, int pos_y, ConsoleColor bcolor) {
        printer.PrintText(" ", pos_x, pos_y, bcolor);
    }
    // reference to printer
    Printer printer;

    // constructor
    // map size and location as parameter
    public Map(int _size_x, int _size_y, int location_x, int location_y) {
        size_x = _size_x;
        size_y = _size_y;
        mapp = new Thing[size_x, size_y];
        printer = new Printer(location_x, location_y);
    }
}