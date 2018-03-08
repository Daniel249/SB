using GameLibrary.Graphics;
using SB.Objects;
namespace SB {
class MapInterface : AbstractForm {
    Map map;


    // IUpdateable implementation
    public override void updateprint(IPrintable printable, int relative_x, int relative_y) {
        Parent.updateprint(printable, Position_x + relative_x, Position_y + relative_y);

        // cast to unit to print hitbox
        Unit u = printable as Unit;
        if(u != null && u.hitbox != null) {
            Render.print(u.hitbox, printable.Position_x, printable.Position_y, map);
            // map.flaggedRows.Clear();
        }
    }
    public override void updatedelete(IPrintable printable, int relative_x, int relative_y) {
        Parent.updatedelete(printable, Position_x + relative_x, Position_y + relative_y);

         Unit u = printable as Unit;
        if(u != null && u.hitbox != null) {
            Render.delete(u.hitbox, printable.Position_x, printable.Position_y, map);
        }
    }
    // constructor
    public MapInterface(Map mapp, IUpdateable screen, int pos_x, int pos_y)
    : base(screen, pos_x, pos_y) {
        map = mapp;
    }
}
}