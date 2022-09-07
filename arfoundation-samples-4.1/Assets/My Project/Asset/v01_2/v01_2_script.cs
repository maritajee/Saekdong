using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
# if PLATFORM_ANDROID
using UnityEngine.Android;
# endif

public class v01_2_script : MonoBehaviour
{

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

    public void CamPermission()
    {
        
        NativeCamera.Permission permissionChecker = new NativeCamera.Permission();
        permissionChecker = NativeCamera.CheckPermission();

        switch (permissionChecker)
        {
            case NativeCamera.Permission.Denied:
                if(Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    NativeCamera.OpenSettings();
                }
                else
                {
                    NativeCamera.RequestPermission();
                }
                
                break;

            case NativeCamera.Permission.Granted:
                break;

            case NativeCamera.Permission.ShouldAsk:
                NativeCamera.RequestPermission();
                break;
        }

        
    }

    public void OnDestroy()
    {
        if(GameObject.Find("DontDestroyOnLoad"))
        {
            Debug.Log("Find");
        }
        else
        {
            Debug.Log("cannot Find");
        }
        Destroy(GameObject.Find("DontDestroyOnLoad"));
    }
}
