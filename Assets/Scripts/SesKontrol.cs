using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            aSource.Pause ();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            aSource.Play ();
        }
    }
}
