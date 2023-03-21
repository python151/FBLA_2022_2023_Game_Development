using System.Runtime.Serialization.Formatters;
using System;

[Serializable]
public class Leaderboard_Item
{
    public string username;
    public int score;

    public Leaderboard_Item(string _username, int _score) {
        this.username = _username;
        this.score = _score;
    }
}