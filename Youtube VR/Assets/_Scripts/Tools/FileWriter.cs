using UnityEngine;

namespace Tools
{
    public static class FileWriter
    {
        public static void DebugFile(string response)
        {
            string path = Application.dataPath + "/TEST.txt";
            System.IO.File.WriteAllText(path, response);
        }
    }
}