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

    public string targetImgName;
    public GameObject target3dObj;
    ARTrackedImageManager arTrackImageManager;
    Dictionary<string, GameObject> _prefabDic = new Dictionary<string, GameObject>();

    private bool imagedetected = false;
    // Start is called before the first frame update
    void Start()
    {
        arTrackImageManager = GetComponent<ARTrackedImageManager>();
        _prefabDic.Add(targetImgName, target3dObj);
        arTrackImageManager.trackedImagesChanged += ImageStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if(imagedetected)
        {
            canvas01.gameObject.SetActive(false);
            canvas02.gameObject.SetActive(true);
        }
    }

    void ImageStateChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            Debug.Log("image tracking add!!" + trackedImage.name);
            imagedetected = true;
        }
    }
}
