using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Quit button functionality
    public void QuitGame()

    {
        Debug.Log("Quit Game");
        // This won't actually work I don't believe until the game is compiled. 
        Application.Quit();
    }

    // Start game button functionality

    public void StartGame()
    {
        Debug.Log("Game starting...");
        // Needs to be changed to level 1 once it's added. 
        SceneManager.LoadScene("SampleScene");
    }   


    // Leaderboard button functionality

    public void OpenLeaderboard()
    {
        Debug.Log("Leaderboard does not currently exist or link is not setup in the code.");
        // Example once we finally build leadeboard: SceneManager.LoadScene("LeaderboardScene");
    }
}
