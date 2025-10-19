using System;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text totalTimeText;
    [SerializeField] private TMP_Text totalStrikesText;
    [SerializeField] private TMP_Text finalScoreText;

    [Header("Score Settings")]
    [SerializeField] private float mistakeWeight = 10.0f;

    private float totalTime;
    private int totalStrikes;
    private LeaderboardManager leaderboardManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leaderboardManager = GameObject.Find("LeaderboardManager").GetComponent<LeaderboardManager>();

        totalTime = TimerManager.previousTime;
        totalStrikes = LivesManager.currentStrikes;

        if (!totalStrikesText || !totalTimeText || !finalScoreText)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        int finalScore = CalculateScore();

        totalTimeText.text = $"Total Time: {Utils.FormatTime(totalTime)}";
        totalStrikesText.text = $"Num of Strikes: {totalStrikes}";
        finalScoreText.text = $"Final Score: {finalScore}";
        leaderboardManager.AddEntry(DateTime.Now.ToString("dd:MM:HH:mm"), finalScore);
    }

    private int CalculateScore()
    {
        return (int)Math.Round(totalTime + (mistakeWeight * totalStrikes));
    }
}
