using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSound : MonoBehaviour
{
    public AudioClip sound;
    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = sound;
        audio.Play();
    }
}
