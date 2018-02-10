using System;
using System.Collections.Generic;

namespace SB {

public class Map {
    // map size
    readonly int size_x;
    readonly int size_y;
    // get set
    public int getSize_x() {
        return size_x;
    }
    public int getSize_y() {
        return size_y;
    }


    // map location
    readonly int location_x;
    readonly int location_y;
    public int getLocation_x() {
        return location_x;
    }
    public int getLocation_y() {
        return location_y;
    }


    // 2d array first dimension y. second dimension x
    readonly Entity[,] mapp;

    // get unit in map
    public Entity getMap(int pos_x, int pos_y) {
        if(!checkLocation(pos_x, pos_y)) {
            return null;
        }
        return mapp[pos_x, pos_y];
    }

    // set unit in map
    public void setMap(Entity u, int pos_x, int pos_y) {
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


    // constructor
    // map size and location as parameter
    public Map(int _size_x, int _size_y, int loc_x, int loc_y) {
        size_x = _size_x;
        size_y = _size_y;
        location_x = loc_x;
        location_y = loc_y;
        mapp = new Entity[size_x, size_y];
    }
}
}