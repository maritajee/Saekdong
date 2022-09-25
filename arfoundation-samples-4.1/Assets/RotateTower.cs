using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < KeepObject.KeepedObject.Count; i++)
        {
            if(KeepObject.KeepedObject[i].name == "TowerObject")
            {
                iTween.RotateTo(KeepObject.KeepedObject[i], iTween.Hash("rotation", new Vector3(0, 720, 0),
                                                "time", 1.5f,
                                                "easetype", iTween.EaseType.easeOutExpo,
                                                "islocal", false));
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
