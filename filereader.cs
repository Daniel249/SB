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


    // search in dictionary. if not found, return null
    static public List<string> getRawTexture(string name) {
        List<string> returnString;
        rawTextures.TryGetValue(name, out returnString);
        return returnString;
    }
    // main method. called in gameplay
    // reads and then processes text file. output is saved in dictionary
    public static void processTextures() {
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
