using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private TimerManager timerManager;
    public void OnWin()
    {
        // Toggle the win UI and pause the game
        timerManager.UpdateWinUI();
        if (target) target.SetActive(true);
        Time.timeScale = 0;
    }

    void Start()
    {
        timerManager = GameObject.Find("TimerManagerHolder").GetComponent<TimerManager>();
        if (target) target.SetActive(false);
    }
}
