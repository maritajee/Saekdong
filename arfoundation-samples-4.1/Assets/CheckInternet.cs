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
            MoveScene(3);
        }
    }
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void SendData()
    {

    }
}
