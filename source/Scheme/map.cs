using System;
using System.Collections.Generic;
using SB.Objects;
using GameLibrary.Services;

namespace SB {

public class Map {
    // map size
    // readonly
    public int Size_x {get;}
    public int Size_y {get;}


    // map location
    // readonly
    public int Position_x {get;}
    public int Position_y {get;}


    // 2d array first dimension y. second dimension x
    readonly Entity[][] mapp;

    // get unit in map
    public Entity getMap(int pos_x, int pos_y) {
        if(!checkPosition(pos_x, pos_y)) {
            return null;
        }
        return mapp[pos_y][pos_x];
    }

    // set unit in map
    public void setMap(Entity u, int pos_x, int pos_y) {
        if(!checkPosition(pos_x, pos_y)) {
            return;
        }
        mapp[pos_y][pos_x] = u;
    }


    // avoid not in array exception
    // checks existance of coordinates
    bool checkPosition(int pos_x, int pos_y) {
        if(pos_x < 0 || pos_x >= Size_x) {
            return false;
        }
        if(pos_y < 0 || pos_y >= Size_y) {
            return false;
        }
        return true;
    }


    // constructor
    // map size and location as parameter
    public Map(int _size_x, int _size_y, int loc_x, int loc_y) {
        Size_x = _size_x;
        Size_y = _size_y;
        Position_x = loc_x;
        Position_y = loc_y;
        mapp = MapInitializer.CreateArray<Entity>(Size_y, Size_x);
    }
}
}