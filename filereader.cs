using System;
public class Filereader {
    // path to file 
    readonly string path;
    // holds each line of file
    string[] textureFile;


    // print whole file to console
    public void printTexture(string identifier) {
        try {
            foreach(string line in textureFile) {
                Console.WriteLine(line);
            }
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    void processTextures() {
    // process textures
    }

    
    // constructor
    public Filereader(string _path) {
        path = _path;
        try {
            textureFile = System.IO.File.ReadAllLines(@path);
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}
