using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSleep : MonoBehaviour
{    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

}
