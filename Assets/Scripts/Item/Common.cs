using UnityEngine;

public static class Common
{
    public static Character Player()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }
    public static Dialog Dialog()
    {
        return GameObject.FindGameObjectWithTag("Dialog").GetComponent<Dialog>();
    }
    public static GameObject Canvas()
    {
        return GameObject.FindGameObjectWithTag("Canvas");
    }
    public static GameObject FocusGroup()
    {
        return GameObject.FindGameObjectWithTag("FocusGroup");
    }
    public static FaderMask Fader(bool isWhite = false)
    {
        string tag = isWhite ? "WhiteFader" : "Fader";
        return GameObject.FindGameObjectWithTag(tag).GetComponent<FaderMask>();
    }
    public static BloodOverlay BloodOverlay()
    {
        return GameObject.FindGameObjectWithTag("BloodOverlay").GetComponent<BloodOverlay>();
    }
    public static GameMaster GameMaster()
    {
        return GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    public static GameObject Kathe()
    {
        return GameObject.FindGameObjectWithTag("Kathe");
    }
    public static ExitDream ExitDream()
    {
        return GameObject.FindGameObjectWithTag("ExitDream").GetComponent<ExitDream>();
    }
}