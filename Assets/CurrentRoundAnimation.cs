using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentRoundAnimation : MonoBehaviour
{
    private TextMeshProUGUI _textComponent;
    // Start is called before the first frame update
    void Start()
    {
        _textComponent = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textComponent.text = GameManagerParent.currentRound + "/" + GlobalSettings.numRounds;
    }
}
