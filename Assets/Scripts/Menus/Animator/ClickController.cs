using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public AudioClip SoundClip;
    public AudioSource SoundSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Clicked!!");
            SoundSource.PlayOneShot(SoundClip);
        }
    }
}
