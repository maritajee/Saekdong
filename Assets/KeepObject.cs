using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class KeepObject : MonoBehaviour
{
    public static List<GameObject> KeepedObject = new List<GameObject>();
    private List<GameObject> gameObjects = new List<GameObject>();
    public GameObject tower;
    GameObject[] FindGameObjectsWithLayer(int layer)
    {
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer && goList.Contains(goArray[i]) == false)
            {
                goList.Add(goArray[i]);
            }
        }
        Debug.Log("not destroy object count: " + goList.Count);
        if (goList.Count == 0)
        {
            return null;
        }


        return goList.ToArray();

    }
    public void addSingleObject(GameObject temp)
    {
        DontDestroyOnLoad(temp);
        KeepedObject.Add(temp);
    }

    public void keepObject()
    {  
        for (int i = 0; i < gameObjects.Count; i++)
        {
            DontDestroyOnLoad(gameObjects[i]);
            KeepedObject.Add(gameObjects[i]);
        }
        iTween.Stop(tower);
        Vector3 temp = transform.rotation.eulerAngles;
        temp.y = 0f;
        tower.transform.rotation = Quaternion.Euler(temp);

    }

    public void addObject(GameObject temp)
    {
        Debug.Log(temp.GetType());
        gameObjects.Add(temp);
        
        keepObject();
    }

    public void addObjectbyLayer()
    {
        for (int i = 0; i < FindGameObjectsWithLayer(6).Length; i++)
        {
            gameObjects.Add(FindGameObjectsWithLayer(6)[i]);
        }

        keepObject();
    }

    public string getText(Text text)
    {
        return text.text;
    }

    public void keepText(Text text1, Text text2)
    {
        text2.text = getText(text1);
    }
}
