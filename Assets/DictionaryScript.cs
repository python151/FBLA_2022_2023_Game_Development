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
        // TODO: Make this more dynamic, maybe include an API --- Or at least a much longer word list!

        switch (difficulty)
        {
            case 0:
                return "Apple";
            case 1:
                return "Certified";
            case 2:
                return "Incomprehensibleness";
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
