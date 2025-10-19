using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text timerHUDText;
    [SerializeField] private TMP_Text winElapsedTime;
    [SerializeField] private TMP_Text winCurrentTime;

    [Header("Time Settings")]
    // Total elapsed time from the last level (0 if first level)
    [SerializeField] private float previousTime;
    [SerializeField] private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!timerHUDText || !winElapsedTime || !winCurrentTime)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        UpdateUI();
    }

    private void UpdateUI()
    {
        timerHUDText.text = $"Time: {FormatTime(currentTime)}";
    }
    
    private string FormatTime(float time)
    {
        int mins = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}.{2:00}", mins, seconds, milliseconds/10);
    }

    // Called by WinManager when it wants time related win UI to be updated
    public void UpdateWinUI()
    {
        previousTime += currentTime;

        winElapsedTime.text = $"Total Time: {FormatTime(previousTime)}";
        winCurrentTime.text = $"This Level Time: {FormatTime(currentTime)}";
    }
}
