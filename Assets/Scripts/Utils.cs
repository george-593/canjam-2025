using UnityEngine;

static public class Utils
{
    public static string FormatTime(float time)
    {
        int mins = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}.{2:00}", mins, seconds, milliseconds/10);
    }
}
