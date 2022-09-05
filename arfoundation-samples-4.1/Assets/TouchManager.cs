using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(AudioSource))]

public class TouchManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    [SerializeField] private Camera arCamera;


    public Canvas canvas;
    public GameObject towerbase;
    public Button delButton;
    public Button nextButton;

    public GameObject faith;
    public GameObject hope;
    public GameObject love;
    public GameObject boundary;
    public GameObject towerparent;

    private int clickBool = 0;
    private bool rotating = true;

    public List<GameObject> Shapes = new List<GameObject>();
    public List<AudioClip> SFX = new List<AudioClip>();
    private List<GameObject> TowerObjectList = new List<GameObject>();


    void Start()
    {
        TowerObjectList.Add(towerbase);
        delButton.onClick.AddListener(DelButtonAction);
    }

    void Update()
    {
        
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ray = arCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if(TowerObjectList.Count<4)
                    {
                        objectSelect(hit.transform.gameObject);
                        objectRotation(hit.transform.gameObject);
                        objectSound(hit.transform.gameObject);
                    }
                    
                }
            }
        }
        ButtonBool(delButton, nextButton);
        if(clickBool == 1)
        {
            Destroy(GameObject.Find((TowerObjectList.Count - 1).ToString()));
            TowerObjectList.RemoveAt(TowerObjectList.Count - 1);
            //Debug.Log("Counted object on List: " + TowerObjectList.Count);
            clickBool = 0;
        }
    }

    void objectSelect(GameObject selected)
    {
        string objname = selected.name;
        GameObject temp = new GameObject();
        for (int i =0; i<Shapes.Count; i++)
        {
            if(Shapes[i].name == objname+"_Onstick")
            {
                temp = Shapes[i];
                break;
            }
        }
        temp.AddComponent<BoxCollider>();
        Vector3 position = new Vector3(0f, towerHeight(TowerObjectList), 0f);
        GameObject tower = Instantiate(temp, position, temp.transform.rotation, towerparent.transform);
        tower.layer = LayerMask.NameToLayer("Tower");
        foreach (Transform child in tower.transform)
        {
            child.gameObject.layer = 6;
        }
        tower.name = TowerObjectList.Count.ToString();
        TowerObjectList.Add(tower);

        rotating = true;
    }

    private float towerHeight(List<GameObject> list)
    {
        
        float height = 0f;
        height += towerbase.GetComponent<BoxCollider>().size.z;
        if(list.Count == 1)
        {
        }
        else
        {
            for (int i = 1; i < list.Count; i++)
            {
                if(list[i].transform.GetChild(1).gameObject.transform.localPosition.z == 0)
                {
                    height += list[i].GetComponent<BoxCollider>().size.z;
                }
                else
                {
                    height += list[i].transform.GetChild(1).gameObject.transform.localPosition.z;
                }
                //height += list[i].GetComponent<BoxCollider>().size.z;
                
            }
            
        }
        //Debug.Log(height);
        return height;
    }

    private void objectRotation(GameObject obj)
    {
        if(rotating)
        {
            iTween.RotateTo(obj, iTween.Hash("rotation", new Vector3(0, 1440, 0),
                                "time", 2f, 
                                "easetype", iTween.EaseType.easeOutExpo,
                                "islocal", false));
            rotating = false;
            //Vector3 to = new Vector3(0, obj.transform.rotation.y + 720, 0);
            //if(Vector3.Distance(obj.transform.eulerAngles, to) > 0.01f)
            //{
            //    obj.transform.eulerAngles = Vector3.Lerp(obj.transform.rotation.eulerAngles, to, Time.deltaTime);
            //}
            //else
            //{
            //    obj.transform.eulerAngles = to;
            //    rotating = false;
            //}
        }
    }

    private void objectSound(GameObject obj)
    {
        for (int i = 0; i < SFX.Count; i++)
        {
            if (SFX[i].name == obj.name)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = SFX[i];
                audio.Play();
            }
        }
    }

    private void ButtonBool(Button button1, Button button2)
    {
        //button1
        if (TowerObjectList.Count > 1)
        {
            button1.gameObject.SetActive(true);
        }
        else
        {
            button1.gameObject.SetActive(false);
        }

        //button2
        if(TowerObjectList.Count == 4)
        {
            button2.gameObject.SetActive(true);
        }
        else
        {
            button2.gameObject.SetActive(false);
        }

        //modify text active setting
        if(TowerObjectList.Count == 1)
        {
            faith.SetActive(true); 
            hope.SetActive(false);
            love.SetActive(false);
            boundary.SetActive(true);
        }
        else if(TowerObjectList.Count == 2)
        {
            faith.SetActive(false);
            hope.SetActive(true);
            love.SetActive(false);
            boundary.SetActive(true);
        }
        else if(TowerObjectList.Count == 3)
        {
            faith.SetActive(false);
            hope.SetActive(false);
            love.SetActive(true);
            boundary.SetActive(true);
        }
        else
        {
            faith.SetActive(false);
            hope.SetActive(false);
            love.SetActive(false);
            boundary.SetActive(false);
        }
    }

    public void DelButtonAction()
    {
        clickBool = 1;
    }
    
}