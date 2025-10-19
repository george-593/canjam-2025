using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public void OnWin()
    {
        // Toggle the win UI and pause the game
        if (target) target.SetActive(true);
        Time.timeScale = 0;
    }

    void Start()
    {
        if (target) target.SetActive(false);
    }
}
