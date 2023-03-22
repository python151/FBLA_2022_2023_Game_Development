using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using Random = System.Random;

public class DramaticTypingScript : MonoBehaviour
{
    private string full_text = "";

    public string current_text = "";

    public float time_per_char = .1f;

    public float time_variation = .05f;

    public float shrink_rate = .1f;

    public float big_size = 0;

    public float small_size = 1;

    public bool animation_complete = false;

    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        if (big_size == 0) big_size = small_size;
        transform.localScale = big_size * Vector3.one;
        
        tmp = transform.GetComponent<TextMeshProUGUI>();

        full_text = tmp.text;
        tmp.text = current_text;
        
        Invoke(nameof(_next_character), .2f);
    }

    void _shrink_text()
    {
        if (transform.localScale.magnitude > small_size)
        {
            transform.localScale -= .05f * shrink_rate * Vector3.one;
            Invoke(nameof(_shrink_text), .05f);
        }
    }

    void _next_character()
    {
        if (full_text.Length > current_text.Length)
        {
            current_text = full_text.Substring(0, current_text.Length + 1);
            tmp.text = current_text;
            
            // Invokes method recursively with a random delay centered around 0
            Invoke(nameof(_next_character), time_per_char + (UnityEngine.Random.value * time_variation) - time_variation/2);
        }
        else
        {
            animation_complete = true;
            _shrink_text();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the text has been externally changed rerun animation
        if (animation_complete && tmp.text != full_text)
        {
            transform.localScale = big_size * Vector3.one;
            
            full_text = tmp.text;
            current_text = "";
            tmp.text = "";
        
            Invoke(nameof(_next_character), time_per_char);

            animation_complete = false;
        }
    }
}