using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text winLivesText;
    [SerializeField] private TMP_Text HUDLivesText;

    static public int currentStrikes = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!winLivesText || !HUDLivesText)
        {
            Debug.LogError("Required fields are not set!");
            enabled = false;
            return;
        }

        // Reset strikes if we're on level1
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            currentStrikes = 0;
        }

        UpdateUI();
    }

    // Called by EnemyController when the player makes an incorrect choice
    public void AddStrike()
    {
        currentStrikes += 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        HUDLivesText.text = $"Strikes: {currentStrikes}";
    }

    // Called by WinManager when it wants life related win UI to be updated
    public void UpdateWinUI()
    {
        winLivesText.text = $"Incorrect Choices: {currentStrikes}";
    }
}
