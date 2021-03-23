using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace Framework
{
    public static class FileOPS
    {
        public static void SaveJson(string path, string name, object content)
        {
            name += ".json";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string FullPath = Path.Combine(path, name);
            StreamWriter sw = File.Exists(FullPath) ? new StreamWriter(FullPath) : File.CreateText(FullPath);
            sw.Write(JsonConvert.SerializeObject(content));
            sw.Close();
            Debug.Log("Write Json File to " + FullPath);
        }

        public static void SaveJson(string name, object content)
        {
            SaveJson(Application.streamingAssetsPath, name, content);
        }

        public static T LoadJson <T> (string Path)
        {
            StreamReader sr = new StreamReader(Path);
            T temp = (T)JsonConvert.DeserializeObject(sr.ReadToEnd());
            sr.Close();
            return temp;
        }
    }
}