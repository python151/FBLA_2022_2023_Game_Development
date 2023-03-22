using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameInput : MonoBehaviour
{
    public static string current_username;
    public static string current_username_2;

    public bool is_second = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void username_input(string input) {
        if (!is_second) {
            UsernameInput.current_username = input;
        } else {
            UsernameInput.current_username_2 = input;
        }
        
    }
}
