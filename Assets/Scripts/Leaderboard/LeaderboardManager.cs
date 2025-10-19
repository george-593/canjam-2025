using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class LeaderboardManager : MonoBehaviour
{
    public int maxEntries = 10;
    private string saveFilePath;
    private Leaderboard leaderboard;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
    }

    // Add a score to the global leaderboard
    public void AddEntry(string playerName, int score)
    {
        // Create and add the new entry
        LeaderboardEntry newEntry = new LeaderboardEntry(playerName, score);
        leaderboard.leaderboard.Add(newEntry);

        // Sort the list (lower scores first)
        leaderboard.leaderboard.Sort();

        // Keep only the top maxEntries
        if (leaderboard.leaderboard.Count > maxEntries)
        {
            leaderboard.leaderboard = leaderboard.leaderboard.GetRange(0, maxEntries);
        }

        // Save the updated data
        SaveLeaderboard();

        Debug.Log($"Added score {score} for {playerName}");
    }

    // Get the top entries
    public List<LeaderboardEntry> GetTopEntries()
    {
        return new List<LeaderboardEntry>(leaderboard.leaderboard);
    }

    // Get the top entry (best score)
    public LeaderboardEntry GetTopEntry()
    {
        if (leaderboard.leaderboard.Count > 0)
            return leaderboard.leaderboard[0];
        else
            return new LeaderboardEntry("No entry", int.MaxValue);
    }

    private void SaveLeaderboard()
    {
        try
        {
            string json = JsonUtility.ToJson(leaderboard, true);
            File.WriteAllText(saveFilePath, json);
            Debug.Log("Saved leaderboard to " + saveFilePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save leaderboard: " + e.Message);
        }
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(saveFilePath))
        {
            try
            {
                string json = File.ReadAllText(saveFilePath);
                leaderboard = JsonUtility.FromJson<Leaderboard>(json);
                if (leaderboard == null || leaderboard.leaderboard == null)
                    leaderboard = new Leaderboard();
                Debug.Log("Loaded leaderboard from " + saveFilePath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load leaderboard: " + e.Message + ". Creating new leaderboard.");
                leaderboard = new Leaderboard();
            }
        }
        else
        {
            Debug.Log("No leaderboard save file found. Creating new leaderboard");
            leaderboard = new Leaderboard();
        }
    }
}