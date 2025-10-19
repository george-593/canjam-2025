using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private TimerManager timerManager;
    private LivesManager livesManager;
    public void OnWin()
    {
        // Toggle the win UI and pause the game
        timerManager.UpdateWinUI();
        livesManager.UpdateWinUI();
        if (target) target.SetActive(true);
        Time.timeScale = 0;
    }

    void Start()
    {
        timerManager = GameObject.Find("AdditionalsHolder").GetComponent<TimerManager>();
        livesManager = GameObject.Find("AdditionalsHolder").GetComponent<LivesManager>();
        if (target) target.SetActive(false);
    }
}
