using System;
using System.Collections.Generic;
using UnityEngine;

// Represents a single entry on the leaderboard
[Serializable]
public class LeaderboardEntry : IComparable<LeaderboardEntry>
{
    public string playerName;
    public int score;

    public LeaderboardEntry(string name, int s)
    {
        playerName = name;
        score = s;
    }

    // Lower scores are better (for lap times, etc.)
    public int CompareTo(LeaderboardEntry other)
    {
        if (other == null) return 1;
        return score.CompareTo(other.score);
    }
}

// The container that will be saved/loaded
[Serializable]
public class Leaderboard
{
    public List<LeaderboardEntry> leaderbord = new List<LeaderboardEntry>();
}
