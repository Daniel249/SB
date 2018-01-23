using System;
public class Filereader {
    string path;
    string[] textureFile;
    // methods
    // print
    public void printTexture(string identifier) {
        try {
            foreach(string line in textureFile) {
                Console.WriteLine(line);
            }
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }
    // process textures
    void processTextures() {

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
