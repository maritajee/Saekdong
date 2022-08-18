using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerDetection : MonoBehaviour
{
    public GameObject objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Cube") != null)
        {
            objects.SetActive(true);
        }
    }
}
