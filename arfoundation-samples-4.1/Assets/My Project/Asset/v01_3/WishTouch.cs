using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ParticleSystem))]
public class WishTouch : MonoBehaviour
{
    public GameObject raw_image;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject boundary;
    public GameObject nextbutton;

    public ParticleSystem effect;

    private int touch_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        raw_image.GetComponent<Button>().onClick.AddListener(ImageTouch);
    }

    // Update is called once per frame
    void Update()
    {
        TouchCount();
    }

    void ImageTouch()
    {
        touch_count += 1;
        float temp = 0.15f * touch_count * touch_count + 0.8f;
        if(touch_count < 4)
        {
            iTween.ScaleTo(raw_image, iTween.Hash("scale", new Vector3(temp, temp, 1f),
                                            "time", 1f,
                                            "easetype", iTween.EaseType.easeOutBack,
                                            "islocal", true));
        }
    }

    void TouchCount()
    {
        if (touch_count == 0)
        {
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
            boundary.SetActive(true);
        }

        else if (touch_count == 1)
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }

        else if (touch_count == 2)
        {
            text2.SetActive(false);
            text3.SetActive(true);
        }

        else if (touch_count == 3)
        {
            text3.SetActive(false);
            boundary.SetActive(false);
            nextbutton.SetActive(true);
            EffectCtrl();
        }
    }

    void EffectCtrl()
    {
        effect.gameObject.SetActive(true);
        effect.Play(true);
    }
}
