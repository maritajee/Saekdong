using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCamPermission : MonoBehaviour
{
    public Canvas pre;
    public Canvas next;
    public void CamPermission()
    {

        NativeCamera.Permission permissionChecker = new NativeCamera.Permission();
        permissionChecker = NativeCamera.CheckPermission();
        pre.gameObject.SetActive(false);
        switch (permissionChecker)
        {
            case NativeCamera.Permission.Denied:
                next.gameObject.SetActive(true);
                break;

            case NativeCamera.Permission.Granted:
                SceneManager.LoadScene(2);
                break;

            case NativeCamera.Permission.ShouldAsk:
                next.gameObject.SetActive(true);
                break;
        }


    }
}
