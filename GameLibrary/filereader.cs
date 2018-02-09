using System;
using System.IO;
using System.Collections.Generic;

namespace GameLibrary
{
    class Filereader {
        // path to file 
        readonly string path = "./textures.txt";
        // holds textures
        Dictionary<string, List<string>> rawTextures;
        Dictionary<string, List<int>> weaponLocation;


        // called in gameplay set up
        public void processTextures() {
            processFileData();
            processRawTextures();
        }

        // processes rawTextures to a char[] dictionary
        // output to static in Texture
        void processRawTextures() {
            Dictionary<string, char[][]> textures = new Dictionary<string, char[][]>();
            // get key and value and loop through them
            foreach(KeyValuePair<string, List<string>> pair in rawTextures) {
                textures.Add(key: pair.Key, value: parseTexture(pair.Value));
            }
            Database.setTextures(textures, weaponLocation);
        }
        // transform string array to 2d char array
        char[][] parseTexture(List<string> stringList) {
            // char dimension_y equals to list length
            int dimension_y = stringList.Count;
            char[][] newCode = new char[dimension_y][/*dimension_x*/];
            // set references in char[][]
            for (int y = 0; y < dimension_y; y++) {
                newCode[y] = stringList[y].ToCharArray(); 
            }
            return newCode;
        }


        // reads and then processes text file. output is saved in rawTextures dictionary
        public void processFileData() {
            // initialize dictionary
            rawTextures = new Dictionary<string, List<string>>();
            weaponLocation = new Dictionary<string, List<int>>();

            string[] textureFile = readFile();
            if(textureFile == null) {
                return;
            }
            // buffers
            string actualName = null;
            int actualWeapon = 0;
            // list of buffers to be eventually be saved in dictionary
            List<string> loadingTexture = new List<string>();
            List<int> loadingWeaponLocation = new List<int>();

            for (int i = 0; i < textureFile.Length; i++) {
                string actual = textureFile[i];
                // if texture name
                if(actual.StartsWith(@"//")) {
                    // loaded something
                    if(loadingTexture.Count > 0) {
                        // save texture in dictionary only if it has name
                        if(actualName != "") {
                            try {
                                rawTextures.Add(key: actualName, value: loadingTexture);
                                if(loadingWeaponLocation.Count > 0) {
                                    weaponLocation.Add(actualName, value: loadingWeaponLocation);
                                }
                            } catch (ArgumentException) {
                                // if key already in dictionary
                                // TODO communicate to user
                            }
                        }
                        // always reset
                        loadingTexture = new List<string>();
                        loadingWeaponLocation = new List<int>();
                    }

                    // parse name
                    actual = actual.Replace(@"/", string.Empty);
                    actual = actual.Replace(" ", string.Empty);
                    // save texture name
                    actualName = actual;
                    actualWeapon = 0;
                } else {
                    // check if weapon marked
                    if(processRow(ref actual)) {
                        loadingWeaponLocation.Add(actualWeapon);
                    }
                    actualWeapon++;
                    // add to current texture
                    loadingTexture.Add(actual.TrimEnd());
                }
            }
        }
        // checks for weapon mark in row
        bool processRow(ref string row) {
            if(row.Contains("W")) {
                row = row.Replace("W", string.Empty);
                return true;
            } else {
                return false;
            }
        }

        // read file to string array
        string[] readFile() {
            string[] code = null;
            try {
                code = System.IO.File.ReadAllLines(@path);
            } catch(Exception e) {
                Terminal.PrintString(e.Message, 0, 1);
            }
            return code;
        }


        public Filereader(string address) {
            path = address;
        }

        // not in use
        // search in rawTextures. if not found, return null
        public List<string> getRawTexture(string name) {
            List<string> returnString;
            rawTextures.TryGetValue(name, out returnString);
            return returnString;
        }
        // read and then print whole file to console
        public void printTexture(string identifier) {
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
}