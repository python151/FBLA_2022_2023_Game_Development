using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardScript : MonoBehaviour
{
    public static int score = 0;

    private TextMeshProUGUI component;
    // Start is called before the first frame update
    void Start()
    {
        component = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        component.text = score + "";
    }
}
