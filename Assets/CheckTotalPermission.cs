using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckTotalPermission : MonoBehaviour
{
    private bool cam = false;
    private bool stor = false;
    public Canvas now;
    public Canvas next;

    public void ClickEvent()
    {
        CamPermission();
        StoragePermission();
        if(cam && stor)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            now.gameObject.SetActive(false);
            next.gameObject.SetActive(true);
        }
    }


    public void CamPermission()
    {
        NativeCamera.Permission permissionChecker = new NativeCamera.Permission();
        permissionChecker = NativeCamera.CheckPermission();
        switch (permissionChecker)
        {
            case NativeCamera.Permission.Denied:
                cam = false;
                break;

            case NativeCamera.Permission.Granted:
                cam = true;
                break;

            case NativeCamera.Permission.ShouldAsk:
                cam = false;
                break;
        }
    }

    public void StoragePermission()
    {

        NativeGallery.Permission permissionChecker = new NativeGallery.Permission();
        permissionChecker = NativeGallery.CheckPermission(NativeGallery.PermissionType.Write);
        switch (permissionChecker)
        {
            case NativeGallery.Permission.Denied:
                stor = false;
                break;

            case NativeGallery.Permission.Granted:
                stor = true;
                break;

            case NativeGallery.Permission.ShouldAsk:
                stor = false;
                break;
        }


    }
}
