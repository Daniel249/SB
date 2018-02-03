using System;
using System.IO;
using System.Collections.Generic;

static class Filereader {
    // path to file 
    const string path = "./textures.txt";
    // holds each line of file
    // static string[] textureFile;
    // holds textures
    static Dictionary<string, List<string>> rawTextures;
    // static Dictionary<string, char[,]> textures;

    // called in gameplay set up
    public static void processTextures() {
        processFileData();
        processRawTextures();
    }

    // processes rawTextures to a char[] dictionary
    // output to static in Texture
    static void processRawTextures() {
        Dictionary<string, char[,]> textures = new Dictionary<string, char[,]>();
        // get key and value and loop through them
        foreach(KeyValuePair<string, List<string>> pair in rawTextures) {
            textures.Add(key: pair.Key, value: parseTexture(pair.Value));
        }
        Texture.setTextures(textures);
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


    // reads and then processes text file. output is saved in rawTextures dictionary
    public static void processFileData() {
        // initialize dictionary
        rawTextures = new Dictionary<string, List<string>>();

        string[] textureFile = readFile();
        if(textureFile == null) {
            return;
        }
        string actualName = null;
        List<string> loadingTexture = new List<string>();

        for (int i = 0; i < textureFile.Length; i++) {
            string actual = textureFile[i];
            // if texture name
            if(actual.StartsWith(@"//")) {
                // loaded something
                if(loadingTexture.Count > 0) {
                    // save texture in dictionary only if it has name
                    if(actualName != "") {
                        rawTextures.Add(key: actualName, value: loadingTexture);
                    }
                    loadingTexture = new List<string>();
                }
                // parse
                actual = actual.Replace(@"/", string.Empty);
                actual = actual.Replace(" ", string.Empty);
                // save texture name
                actualName = actual;
            } else {
                // add to current texture
                loadingTexture.Add(actual);
            }
        }
    }

    // read file to string array
    static string[] readFile() {
        string[] code = null;
        try {
            code = System.IO.File.ReadAllLines(@path);
        } catch(Exception e) {
            Terminal.PrintString(e.Message, 0, 1);
        }
        return code;
    }



    // not in use
    // search in rawTextures. if not found, return null
    static public List<string> getRawTexture(string name) {
        List<string> returnString;
        rawTextures.TryGetValue(name, out returnString);
        return returnString;
    }
    // read and then print whole file to console
    static public void printTexture(string identifier) {
        string[] textureFile = readFile();
        try {
            foreach(string line in textureFile) {
                Console.WriteLine(line);
            }
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}
