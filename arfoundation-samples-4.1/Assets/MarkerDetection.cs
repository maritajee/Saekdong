using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class MarkerDetection : MonoBehaviour
{
    public GameObject target;
    public Canvas canvas01;
    public Canvas canvas02;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ARTrackedImage.referenceImage)
        {

        }
    }
}
