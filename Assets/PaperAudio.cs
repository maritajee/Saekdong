using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAudio : MonoBehaviour
{
    public List<AudioClip> PaperSound = new List<AudioClip>();
    // Start is called before the first frame update
    void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        float i = Random.Range(0f, 1f);
        audio.clip = PaperSound[Mathf.RoundToInt(i)];
        audio.Play();
    }
}
