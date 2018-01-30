using System;
using System.IO;
using UnityEngine;

public class SubtitleParser
{
    public static string[] Get(SubtitleDef sub)
    {
        string fileName = Enum.GetName(typeof(SubtitleDef), sub);
        return File.ReadAllLines(Application.dataPath + @"\Subtitles\" + fileName + ".txt");
    }
}