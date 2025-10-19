using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text totalTimeText;
    [SerializeField] private TMP_Text totalStrikesText;

    private float totalTime = TimerManager.previousTime;
    private int totalStrikes = LivesManager.currentStrikes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!totalStrikesText || !totalTimeText)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        totalTimeText.text = $"Total Time: {FormatTime(totalTime)}";
        totalStrikesText.text = $"Num of Strikes: {totalStrikes}";
    }

    public string FormatTime(float time)
    {
        int mins = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}.{2:00}", mins, seconds, milliseconds/10);
    }
}
