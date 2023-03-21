using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class RoundNumberAnimation : MonoBehaviour
{
    public GameObject textObject;
    
    private TextMeshProUGUI _textComponent;

    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _textComponent = textObject.GetComponent<TextMeshProUGUI>();
        _slider = transform.GetComponent<UnityEngine.UI.Slider>();
        
        InvokeRepeating(nameof(ProcessSlider), .01f, .05f);
    }

    void ProcessSlider()
    {
        int _slider_value = (int) _slider.value;
        _textComponent.text = _slider_value == 1 ? "1 round" : _slider_value + " rounds";
        
        GlobalSettings.numRounds = GlobalSettings.numRounds == _slider_value ? GlobalSettings.numRounds : _slider_value;
    }
}
