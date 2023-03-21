using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManagerParent : MonoBehaviour
{
    public static int currentRound = 1;
    
    public GameObject OutputText;
    
    public TextMeshProUGUI OutputTextComponent; 
    public TMP_InputField InputTextComponent;

    public string final_text;

    public string current_text;

    public List<int> typingPath;

    public float timer;

    public bool answering;
    // Start is called before the first frame update
    public void Start()
    {
        // Loads all the necessary components
        OutputTextComponent = OutputText.GetComponent<TextMeshProUGUI>();
        InputTextComponent = OutputText.GetComponent<TMP_InputField>();
        
        // Resets and initializes all variables
        answering = false;
        InputTextComponent.enabled = false;
        timer = 0f;

        // Setting up game
        final_text = DictionaryScript.getWordOrPhrase();
        current_text = GenerateInitialText(final_text);
        OutputTextComponent.text = current_text;
        
        // Creates the computer's typing path
        typingPath = new List<int>();
        for (int i = 0; i < final_text.Length; i++)
            typingPath.Add(i);
        var rnd = new System.Random();
        typingPath = typingPath.OrderBy(item => rnd.Next()).ToList();
    }

    private string GenerateInitialText(string finalText)
    {
        string ret = "";
        foreach (char character in finalText)
        {
            ret += character == ' ' ? " " : "_";
        }

        return ret;
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong Answer!");
    }

    public virtual void WordCompleted() { throw new NotImplementedException(); }

    public virtual void ProcessAnswerState() { throw new NotImplementedException(); }
    
    void ProcessUserAnswerInput()
    {
        // Checks if the user has typed in characters while answering
        if (answering && current_text != InputTextComponent.text)
        {
            // Removes excess characters and stops users from typing in additional wrong answers
            bool isCorrect = false;
            for (int i = 0; i < current_text.Length; i++)
            {
                if (current_text[i] != InputTextComponent.text[i])
                {
                    isCorrect = InputTextComponent.text[i] == final_text[i];
                    
                    current_text = InputTextComponent.text[i] == final_text[i] ? InputTextComponent.text.Remove(i+1, 1) : InputTextComponent.text.Remove(i, 1);
                    InputTextComponent.text = current_text;
                    
                    break;
                }
            }
            if (!isCorrect && !Input.GetKeyDown(KeyCode.Space)) WrongAnswer();
            
            // Checks if word is completed
            if (current_text == final_text) WordCompleted();
            
            // Updates caret position (where the user types)
            for (int i = 0; i < current_text.Length; i++)
            {
                if (current_text[i] != final_text[i])
                {
                    InputTextComponent.caretPosition = i;
                    break;
                }
            }
            InputTextComponent.text = current_text;
        }
    }

    void ComputerTyper()
    {
        // Types for computer
        timer += Time.deltaTime;
        if (timer > (TimerScript.initialTime / final_text.Length) && typingPath.Count > 0 && !answering)
        {
            int index = typingPath[0];
            
            // Replaces an individual character at the given index
            current_text = current_text.Insert(index, final_text[index].ToString()).Remove(index+1, 1);
            OutputTextComponent.text = current_text;

            typingPath = typingPath.GetRange(1, typingPath.Count - 1);
            timer = 0;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        ProcessAnswerState();
        
        ProcessUserAnswerInput();
       
        ComputerTyper();
    }
}
