using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreText : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public string prefix;
    public string suffix;
    // Start is called before the first frame update
    void Start()
    {
        tmp = transform.GetComponent<TextMeshProUGUI>();
        tmp.text = prefix + ScoreBoardScript.score + suffix;
    }
}
