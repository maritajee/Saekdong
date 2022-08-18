using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Shapes : MonoBehaviour
{
    public GameObject shape;

    ARRaycastManager arManager;
    // Start is called before the first frame update
    void Start()
    {
        shape.SetActive(false);

        arManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }

    void DetectGround()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            shape.SetActive(true);
            shape.transform.position = hitInfos[0].pose.position;
        }

        else
        {
            shape.SetActive(false);
        }
    }
}
