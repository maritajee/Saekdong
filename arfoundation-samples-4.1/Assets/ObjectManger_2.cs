using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectManger_2 : MonoBehaviour
{
    public GameObject[] prefab;

    ARRaycastManager arManager;

    GameObject placedObject;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    void Update()
    {
        List<ARRaycastHit> hitInfo = new List<ARRaycastHit>();
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        if (arManager.Raycast(screenSize, hitInfo, TrackableType.Planes))
        {
            spawnObject();
        }
    }

    // Update is called once per frame
    public void spawnObject()
    {
        float x, y, z;
        x = Random.Range(0.0f, 6.0f);
        y = Random.Range(0.0f, 6.0f);
        z = Random.Range(0.0f, 6.0f);
        Vector3 pos;

        List<ARRaycastHit> hitInfo = new List<ARRaycastHit>();

        for (int i = 0; i < prefab.Length - 1; i++)
        {
            pos = new Vector3(x, y, z);
            Instantiate(prefab[i], pos, hitInfo[0].pose.rotation);
        }

    }
}
