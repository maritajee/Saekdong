using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class v01_1_script : MonoBehaviour
{

    private bool permission_ask = false;
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

    public void AskPermission()
    {
        NativeCamera.RequestPermission();
        NativeGallery.RequestPermission(NativeGallery.PermissionType.Write);
    }
}
