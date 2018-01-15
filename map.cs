
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

    // 2d array 150*80
    Unit[,] mapp;
    // get map reference
    public Unit[,] getMap() {
        return mapp;
    }
    // get unit in map
    public Unit getMap(int pos_x, int pos_y) {
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
}