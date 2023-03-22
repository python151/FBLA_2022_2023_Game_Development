using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverRankText : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public string prefix;
    public string suffix;
    // Start is called before the first frame update
    void Start()
    {
        tmp = transform.GetComponent<TextMeshProUGUI>();

        string[] ranking_suffix_mapping = {"st", "nd", "rd", "th"};
        int rank = _get_rank(UsernameInput.current_username);
        tmp.text = prefix + rank + (rank < 4 ? ranking_suffix_mapping[rank-1] : "th") + suffix;
    }

    private int _get_rank(string username) {
        return LeaderboardSaver.get_user_rank(UsernameInput.current_username);
    }
}
