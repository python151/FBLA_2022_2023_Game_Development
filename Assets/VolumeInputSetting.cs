using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class VolumeInputSetting : SettingsInputComponent
{
    public void ValueChanged()
    {
        GlobalSettings.audioVolume = inputObject.GetComponent<Slider>().value;
        Debug.Log(GlobalSettings.audioVolume);
    }
}
