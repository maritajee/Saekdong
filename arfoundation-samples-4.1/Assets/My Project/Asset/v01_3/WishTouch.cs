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
    public GameObject target;

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
        float temp = 1.3f * (0.15f * touch_count * touch_count)+1.0f;
        if (touch_count < 4)
        {
            iTween.ScaleTo(raw_image, iTween.Hash("scale", new Vector3(temp, temp, 1f),
                                            "time", 1f,
                                            "easetype", iTween.EaseType.easeOutBack,
                                            "islocal", true));
            if(touch_count < 3)
            {
                iTween.RotateTo(target, iTween.Hash("rotation", new Vector3(0, 720, 0),
                                                "time", 1f,
                                                "easetype", iTween.EaseType.easeOutExpo,
                                                "islocal", false));
            }
        }
    }

    public void TouchCount()
    {
        var main = effect.main;
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
            
            main.maxParticles = 30;
            EffectCtrl();
        }

        else if (touch_count == 2)
        {
            text2.SetActive(false);
            text3.SetActive(true);
            main.maxParticles = 120;
            EffectCtrl();
        }

        else if (touch_count == 3)
        {
            text3.SetActive(false);
            boundary.SetActive(false);
            nextbutton.SetActive(true);
            main.maxParticles = 500;
            EffectCtrl();

            iTween.RotateBy(target, iTween.Hash("y", 1,
                                                "time", 4f,
                                                "looptype", iTween.LoopType.loop,
                                                "easetype", iTween.EaseType.linear,
                                                "islocal", false));
        }
    }


    void EffectCtrl()
    {
        effect.gameObject.SetActive(true);
        effect.Play(true);
    }

    GameObject[] FindTowerObject(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }
}
