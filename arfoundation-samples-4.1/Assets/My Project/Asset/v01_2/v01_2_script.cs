using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
# if PLATFORM_ANDROID
using UnityEngine.Android;
# endif

public class v01_2_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
