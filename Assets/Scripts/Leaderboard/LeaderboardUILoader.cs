using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardUILoader : MonoBehaviour
{
    // Public Variables
    public GameObject entryPrefab;

    // Private Variables
    private LeaderboardManager leaderboardManager;
    private GameObject targetParent;
    Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        leaderboardManager = GetComponent<LeaderboardManager>();
        targetParent = gameObject;

        LoadLapTimes();
    }

    // Load the lap times from leaderboard manager and display them on UI
    private void LoadLapTimes()
    {
        // Stop a null reference error
        if (!leaderboardManager || !targetParent)
            return;

        // Return all children to the pool
        foreach (Transform child in targetParent.transform)
        {
            child.gameObject.SetActive(false);
            pool.Enqueue(child.gameObject);
        }

        // Load lap times from the leaderboard manager
        List<LeaderboardEntry> leaderboardEntries = leaderboardManager.GetTopEntries();

        // Load each leaderboard entry into UI
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            // Get the lap time
            LeaderboardEntry lap = leaderboardEntries[i];

            // If there is anything in the pool use that, otherwise create a new object
            GameObject entry;
            if (pool.Count > 0)
            {
                entry = pool.Dequeue();
            } else
            {
                entry = Instantiate(entryPrefab, targetParent.transform);
            }

            // Enable the text object
            entry.SetActive(true);

            // Set the text fields
            TextMeshProUGUI nameText = entry.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI timeText = entry.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            nameText.text = lap.playerName;
            timeText.text = string.Format("{0:.00}", lap.score) + "s";
        }
    }
}
