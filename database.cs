using System.Collections.Generic;
static class Database {
    // statics
    // textures dictionary
    static Dictionary<string, char[][]> textures;
    // vertical positons of weapons in marked textures 
    static Dictionary<string, List<int>> weaponsLocation;
    public static void setTextures(Dictionary<string, char[][]> _textures, Dictionary<string, List<int>> _weaponsLocation) {
        textures = _textures;
        weaponsLocation = _weaponsLocation;
    }

    // where load weapons
    public static List<int> assignWeaponLocation(string addressName) {
        List<int> locations;

        if(weaponsLocation != null && weaponsLocation.TryGetValue(addressName, out locations)) {
            // dont do else
        } else {
            char[][] justInCase = assignTexture(addressName);
            locations = new List<int>() {
                justInCase.Length/2
            };
        }
    return locations;
    }

     // main texture finder
     public static char[][] assignTexture(string addressName) {
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
}