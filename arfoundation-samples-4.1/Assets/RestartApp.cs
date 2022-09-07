using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartApp : MonoBehaviour
{
    public void Restart()
    {
        for(int i = 0; i < KeepObject.KeepedObject.Count; i++)
        {
            Destroy(KeepObject.KeepedObject[i]);
            KeepObject.KeepedObject.Remove(KeepObject.KeepedObject[i]);
        }
    }
}
