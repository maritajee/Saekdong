using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInternet : MonoBehaviour
{
    public Canvas popup;
    public void InternetCheck()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            popup.gameObject.SetActive(true);
            Debug.Log("Error. Check internet connection!");
        }

        else
        {
            Debug.Log("Internet Connected");
            SendData(TouchManager.TowerObjectList);
            MoveScene(3);
        }
    }
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SendData(List<GameObject> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            Debug.Log(list[i].transform.GetChild(0).name);
        }
    }
}
