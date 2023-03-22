using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneOverride = "";
    public void loadScene(string scene)
    {
        SceneManager.LoadSceneAsync(sceneOverride == "" ? scene : sceneOverride);
    }
}

