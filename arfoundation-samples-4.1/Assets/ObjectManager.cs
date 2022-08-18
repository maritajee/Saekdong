using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] prefab;

    ARRaycastManager arManager;
    GameObject placedObject;

    // Start is called before the first frame update
    void Start()
    {
        arManager = GetComponent<ARRaycastManager>();
        List <ARRaycastHit> hitInfo = new List <ARRaycastHit>();
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        if (arManager.Raycast(screenSize, hitInfo, TrackableType.Planes))
        {
            for (int i = 0; i < 33; i++)
            {
                Instantiate(prefab[i], hitInfo[0].pose.position * Random.Range(0, 10) * 0.1f, hitInfo[0].pose.rotation);
            }
        }  
    }

    //update is called once per frame
    //void update()
    //{
    //    detectground();
    //}

    //void detectground()
    //{
    //    vector2 screensize = new vector2(screen.width * 0.5f, screen.height * 0.5f);

    //    list<arraycasthit> hitinfos = new list<arraycasthit>();
    //    if (armanager.raycast(screensize, hitinfos, trackabletype.planes))
    //    {
    //        if (placedobject = null)
    //        {
    //            placedobject = instantiate(prefab[0], hitinfos[0].pose.position * random.range(0, 10) * 0.1f, hitinfos[0].pose.rotation);
    //        }
    //    }
    //}
}
