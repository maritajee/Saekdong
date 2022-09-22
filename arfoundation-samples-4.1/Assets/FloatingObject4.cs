using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject4 : MonoBehaviour
{
    public GameObject ObjectsOnScreen;
    public GameObject A;
    public GameObject B;
    public GameObject CD;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach(Transform child in A.transform)
        {
            iTween.RotateBy(child.gameObject, iTween.Hash("z", 1,
                                                "time", 90f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", false));

        }
        foreach (Transform child in B.transform)
        {
            iTween.RotateBy(child.gameObject, iTween.Hash("z", 1,
                                                "time", 90f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", false));

        }
        foreach (Transform child in CD.transform)
        {
            iTween.RotateBy(child.gameObject, iTween.Hash("z", 1,
                                                "time", 90f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", false));

        }

        iTween.RotateBy(A, iTween.Hash("y", 1,
                                                "time", 150f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", true));
        iTween.RotateBy(CD, iTween.Hash("y", -1,
                                                "time", 150f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", true));


    }

    private void Update()
    {
        var f = Mathf.Sin(Time.time*0.5f)*0.2f;
        ObjectsOnScreen.transform.position = new Vector3(0f, f, 0f);
        B.transform.position = new Vector3(0f, -f, 0f);
    }
}
