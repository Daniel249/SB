using GameLibrary.Interface;
using GameLibrary.Graphics;
using SB.Objects;

namespace SB {
class MapInterface : GUInterface {
    Map map;

    // overrides to print as Entity too
    // already prints to interface frame
    public override void print(IPrintable printable) {
        base.print(printable);

        // cast to unit to print hitbox
        Unit u = printable as Unit;
        if(u != null) {
            Render.print(u.hitbox, printable.Position_x, printable.Position_y, map);
        }
    }
    public override void delete(IPrintable printable) {
        base.delete(printable);

        Unit u = printable as Unit;
        if(u != null) {
            Render.delete(u.hitbox, printable.Position_x, printable.Position_y, map);
        }
    }
     // contructor
    public MapInterface(Map mapp, Screen screen, int pos_x, int pos_y,int  size_x, int size_y) 
        : base(screen, pos_x, pos_y, size_x, size_y) {
        map = mapp;
    }
}
}
