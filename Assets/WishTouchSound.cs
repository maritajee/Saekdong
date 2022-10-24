using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishTouchSound : MonoBehaviour
{
    private int touch_count = 0;
    public List<AudioClip> TowerSound = new List<AudioClip>();

    public void TouchSound()
    {
        touch_count += 1;
        

        if (touch_count == 1)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = TowerSound[0];
            audio.Play();
        }

        else if (touch_count == 2)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = TowerSound[1];
            audio.Play();
        }

        else if (touch_count == 3)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = TowerSound[2];
            audio.Play();
        }
    }
}
