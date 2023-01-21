using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DictionaryScript : MonoBehaviour
{
    public static int difficulty { get; private set; } = 0;
    public static string getWordOrPhrase()
    {
        List<string> easyList = new List<string>() {"issue", "practice", "apple", "rocks"};
        List<string> mediumList = new List<string>() {"distinction", "disposition", "certification"};
        List<string> hardList = new List<string>() {"capricious", "stupendous", "convalesce", "alacrity"};
        // TODO: Make this more dynamic, maybe include an API --- Or at least a much longer word list!

        switch (difficulty)
        {
            case 0:
                return easyList[Random.Range(0, easyList.Count)];
            case 1:
                return mediumList[Random.Range(0, mediumList.Count)];
            case 2:
                return hardList[Random.Range(0, hardList.Count)];
            default:
                throw new KeyNotFoundException("Difficulty variable set incorrectly!");
                return "Apple";
        }
    }

    public static void setDifficulty(int updated_difficulty)
    { 
        difficulty = updated_difficulty;
        Debug.Log("Difficulty changed to " + difficulty);
    }
}
