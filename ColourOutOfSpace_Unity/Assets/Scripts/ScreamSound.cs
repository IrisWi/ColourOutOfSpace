using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSound : MonoBehaviour
{
    public AudioSource screamSource;
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
    screamSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter ()
    {
        if (!alreadyPlayed)
        { 
        screamSource.Play();
        alreadyPlayed = true;
        }

    }
}
