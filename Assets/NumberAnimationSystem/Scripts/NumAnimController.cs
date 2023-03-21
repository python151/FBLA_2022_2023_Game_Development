using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using TMPro;

public class NumAnimController : MonoBehaviour
{
    public TextMeshProUGUI _numberText;
    public int m_currentNum;

    void Start()
    {
        //AnimateFromJson("/TestData/JackpotTestFile");
        Animate();
    }

    public void Animate()
    {
        // Stop previous animation
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, m_currentNum, ScoreBoardScript.score, 10)
            .setEase(LeanTweenType.easeOutQuart)
            .setOnUpdate(UpdateUI);
    }

    public void UpdateUI(float v)
    {
        m_currentNum = (int) v;
        _numberText.text = v.ToString("0");
    }
}