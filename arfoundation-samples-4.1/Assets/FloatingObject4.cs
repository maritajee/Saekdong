using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject4 : MonoBehaviour
{
    public GameObject ObjectsOnScreen;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach(Transform child in ObjectsOnScreen.transform)
        {
            iTween.RotateBy(child.gameObject, iTween.Hash("z", 1,
                                                "time", 90f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", false));

        }
    }

}
