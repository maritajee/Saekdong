using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class delButton : MonoBehaviour
{
    TouchManager touchmanager;
    public Button button;
    public void DelButtonAction()
    {
        touchmanager.Shapes.RemoveAt(touchmanager.Shapes.Count - 1);
    }

    
}
