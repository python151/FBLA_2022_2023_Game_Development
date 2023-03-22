using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardItemDisplay : MonoBehaviour
{
    public string username;
    public int score;
    public int rank;

    public GameObject usernameText;
    public GameObject scoreText;
    public GameObject rankText;

    private TextMeshProUGUI _username_tmp;
    private TextMeshProUGUI _score_tmp;
    private TextMeshProUGUI _rank_tmp;

    public void Awake() {
        this._username_tmp = usernameText.GetComponent<TextMeshProUGUI>();
        this._score_tmp = scoreText.GetComponent<TextMeshProUGUI>();
        this._rank_tmp = rankText.GetComponent<TextMeshProUGUI>();
    }

    public void configure(string _username, int _score, int _rank) {
        this.username = _username.Length < 14 ? _username : _username.Substring(0,10) + "...";
        this.score = _score;
        this.rank = _rank;

        this.Display();
    }

    public void Display() {
        this._username_tmp.text = this.username;
        this._score_tmp.text = this.score + "";
        this._rank_tmp.text = "#" + this.rank;
    }
}
