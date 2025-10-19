using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text totalTimeText;
    [SerializeField] private TMP_Text totalStrikesText;

    private float totalTime;
    private int totalStrikes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalTime = TimerManager.previousTime;
        totalStrikes = LivesManager.currentStrikes;

        if (!totalStrikesText || !totalTimeText)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        totalTimeText.text = $"Total Time: {Utils.FormatTime(totalTime)}";
        totalStrikesText.text = $"Num of Strikes: {totalStrikes}";
    }
}
