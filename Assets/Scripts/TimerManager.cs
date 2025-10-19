using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text timerHUDText;
    [SerializeField] private TMP_Text winElapsedTime;
    [SerializeField] private TMP_Text winCurrentTime;

    static public float previousTime;
    private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Null value checks
        if (!timerHUDText || !winElapsedTime || !winCurrentTime)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        // Reset previous time if we're on level1
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            previousTime = 0f;
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
        timerHUDText.text = $"Time: {Utils.FormatTime(currentTime)}";
    }

    // Called by WinManager when it wants time related win UI to be updated
    public void UpdateWinUI()
    {
        previousTime += currentTime;

        winElapsedTime.text = $"Total Time: {Utils.FormatTime(previousTime)}";
        winCurrentTime.text = $"This Level Time: {Utils.FormatTime(currentTime)}";
    }
}
