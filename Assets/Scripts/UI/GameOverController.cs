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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalTime = TimerManager.previousTime;
        totalStrikes = LivesManager.currentStrikes;

        if (!totalStrikesText || !totalTimeText || !finalScoreText)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        totalTimeText.text = $"Total Time: {Utils.FormatTime(totalTime)}";
        totalStrikesText.text = $"Num of Strikes: {totalStrikes}";
        finalScoreText.text = $"Final Score: {CalculateScore()}";
        // Save score to leaderboard (https://github.com/george-593/canjam-2025/issues/53)
    }

    private int CalculateScore()
    {
        return (int)Math.Round(totalTime + (mistakeWeight * totalStrikes));
    }
}
