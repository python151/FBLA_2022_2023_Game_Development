using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameInput : MonoBehaviour
{
    public static string current_username;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void username_input(string input) {
        UsernameInput.current_username = input;
    }
}
