using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SinglePlayerGameManager : MonoBehaviour
{
    public GameObject OutputText;
    
    private TextMeshProUGUI OutputTextComponent; 
    private TMP_InputField InputTextComponent;

    public string final_text;

    public string current_text;

    private List<int> typingPath;

    private float timer = 0f;

    private bool answering;
    // Start is called before the first frame update
    void Start()
    {
        // Loads all the necessary components
        OutputTextComponent = OutputText.GetComponent<TextMeshProUGUI>();
        InputTextComponent = OutputText.GetComponent<TMP_InputField>();
        
        // Setting up game
        final_text = DictionaryScript.getWordOrPhrase();
        current_text = GenerateInitialText(final_text);
        OutputTextComponent.text = current_text;
        
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

    void ReplaceAllInstances(char character)
    {
        string final_text_temp = final_text;
        int nextIndex = final_text_temp.IndexOf(character);
        while (nextIndex != -1)
        {
            current_text = current_text.Insert(nextIndex, final_text[nextIndex].ToString()).Remove(nextIndex+1, 1);
            nextIndex = final_text_temp.IndexOf(character);
        }

        OutputTextComponent.text = current_text;
    }

    void WrongAnswer()
    {
        Debug.Log("Wrong Answer!");
    }

    void GameCompleted()
    {
        Debug.Log("Game Completed!!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !answering)
        {
            InputTextComponent.enabled = true;
            InputTextComponent.text = current_text;
            InputTextComponent.caretPosition = 0;
            InputTextComponent.Select();
            answering = true;
            SceneManager.LoadSceneAsync("Scenes/SinglePlayerAnsweringScene", LoadSceneMode.Additive);
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            answering = false;
            SceneManager.UnloadSceneAsync("Scenes/SinglePlayerAnsweringScene");
        }
        InputTextComponent.enabled  = answering;

        if (answering && Input.anyKeyDown)
        {
            
            if (current_text != InputTextComponent.text)
            {
                bool is_correct = false;
                for (int i = 0; i < current_text.Length; i++)
                {
                    if (current_text[i] != InputTextComponent.text[i])
                    {
                        is_correct = InputTextComponent.text[i] == final_text[i];
                        current_text = InputTextComponent.text[i] == final_text[i] ? InputTextComponent.text.Remove(i+1, 1) : InputTextComponent.text.Remove(i, 1);
                        InputTextComponent.text = current_text;
                        break;
                    }
                }
                if (!is_correct) WrongAnswer();

                bool is_complete = true;
                for (int i = 0; i < current_text.Length; i++)
                {
                    if (current_text[i] != final_text[i])
                    {
                        InputTextComponent.caretPosition = i;
                        is_complete = false;
                        break;
                    }
                }

                if (is_complete) GameCompleted();
            }
            InputTextComponent.text = current_text;
            
        }

        timer += Time.deltaTime;
        if (timer > (TimerScript.initalTime / final_text.Length) && typingPath.Count > 0 && !answering)
        {
            int index = typingPath[0];
            
            // Replaces an individual character at the given index
            current_text = current_text.Insert(index, final_text[index].ToString()).Remove(index+1, 1);
            OutputTextComponent.text = current_text;

            typingPath = typingPath.GetRange(1, typingPath.Count - 1);
            timer = 0;
        }
    }
}
