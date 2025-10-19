using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TMP_Text winLivesText;

    static public int currentStrikes = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!winLivesText)
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
    }

    // Called by EnemyController when the player makes an incorrect choice
    public void addStrike()
    {
        currentStrikes += 1;
    }

    // Called by WinManager when it wants life related win UI to be updated
    public void UpdateWinUI()
    {
        winLivesText.text = $"Incorrect Choices: {currentStrikes}";
    }
}
