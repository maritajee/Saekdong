using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeepObject : MonoBehaviour
{
    private List<GameObject> gameObjects = new List<GameObject>();
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

    public void keepObject()
    {  
        for (int i = 0; i < gameObjects.Count; i++)
        {

            DontDestroyOnLoad(gameObjects[i]);
        }
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
