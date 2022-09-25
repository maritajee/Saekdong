using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    HttpCtrl httpCtrl;
    // Start is called before the first frame update
    void Awake()
    {
        httpCtrl.Download();

    }
}
