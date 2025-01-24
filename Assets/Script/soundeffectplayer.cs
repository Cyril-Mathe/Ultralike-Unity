using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class soundeffectplayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;

    
    void Update()
    {
        Shooteffect();
    }

    void Shooteffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            src.clip = sfx;
            src.Play();
        }
    }
}
