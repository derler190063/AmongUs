using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AmongUs
{
    class MapCreator
    {
        private readonly Exception invalidFileExeption = new Exception("The File is not valid");
        private readonly Exception noPath = new Exception("No path");

        public string path;
        private int maxMapWidth = -1;
        public int MaxMapWidth
        {
            get { return maxMapWidth; }
        }

        public MapCreator(string path)
        {
            this.path = path;
        }

        public void CreateFile()
        {
            string generatedText =
                "\n<#end#end#end#>\n" +
                "wall:\n" +
                "emergency:\n";

            File.WriteAllText(path, generatedText);
        }

        public string GetMap()
        {
            if (path == null) throw noPath;

            string[] rawTextLines = File.ReadAllLines(path);
            string map = "";

            int index = 0;
            foreach (var item in rawTextLines)
            {
                if (item == "<#end#end#end#>") break;
                else index++;
            }
            index--;

            for (int i = 0; i <= index; i++)
            {
                map += rawTextLines[i];

                if (rawTextLines[i].Length > maxMapWidth)
                {
                    maxMapWidth = rawTextLines[i].Length;
                }
            }
            
            return map;
        }

        private string[] GetMapInfo()
        {
            if (path == null) throw noPath;

            List<string> mapInfo = new List<string>(); 
            string[] textLines = File.ReadAllLines(path);

            int indexOfInfo = 0;
            foreach (var item in textLines)
            {
                if (item == "<#end#end#end#>")
                {
                    indexOfInfo++;
                    break;
                }           
                else indexOfInfo++;
            }

            if (indexOfInfo + 1 >= textLines.Length) throw invalidFileExeption;

            for (int i = indexOfInfo; i < textLines.Length; i++)
            {
                string info =
                    textLines[i].Split(':')[0] +
                    textLines[i].Split(':')[1];

                mapInfo.Add(info);
            }

            if (mapInfo.Count() == 0) throw invalidFileExeption;

            return mapInfo.ToArray();
        }

        public List<GameObject> GetGameObjects()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            string map = GetMap();
            string[] info = GetMapInfo();
            for (int i = 0; i < map.Length; i++)
            {
                if (info[0].Contains(map[i]))
                {
                    int y = i / maxMapWidth;
                    int x = i - y;
                    gameObjects.Add(new Wall(x, y));
                }
            }

            return gameObjects;
        }
    }
}
