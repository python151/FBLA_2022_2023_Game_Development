using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Numerics;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SinglePlayerGameManager : GameManagerParent
{
    public override void ProcessAnswerState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(EventSystem.current.currentSelectedGameObject);
        
        if (Input.GetKeyDown(KeyCode.Space) && !answering)
        {
            // Sets up input box
            InputTextComponent.enabled = true;
            InputTextComponent.text = " " + current_text; // <- includes the extra space to force the caret position to update accordingly
            if (EventSystem.current.currentSelectedGameObject != OutputText)
            {
                Debug.Log("Selected!");
                InputTextComponent.Select();
            }
            InputTextComponent.caretPosition = 0;
            
            // Sets up Scene
            answering = true;
            SceneManager.LoadSceneAsync("Scenes/SinglePlayerAnsweringScene", LoadSceneMode.Additive);
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Unloads Scene
            answering = false;
            SceneManager.UnloadSceneAsync("Scenes/SinglePlayerAnsweringScene");
        }
        InputTextComponent.enabled  = answering;
    }

    public override void WordCompleted()
    {
        currentRound++;
        if (currentRound <= GlobalSettings.numRounds)
        {
            answering = false;
            
            SceneManager.UnloadSceneAsync("Scenes/SinglePlayerAnsweringScene");
            
            base.Start();
        }
        else
        {
            currentRound = 1;
            SceneManager.LoadSceneAsync("Scenes/GameOver");
        }
        Debug.Log("Word Completed!!");
    }
}
