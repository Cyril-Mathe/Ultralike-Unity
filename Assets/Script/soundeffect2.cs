using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffect2 : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx2;
    void Start()
    {
        Ambiance();
    }
    void Ambiance()
    {
        if (!src.isPlaying || src.clip != sfx2)
        {
            src.clip = sfx2;
            src.loop = true;
            src.Play();
        }
    }
}
