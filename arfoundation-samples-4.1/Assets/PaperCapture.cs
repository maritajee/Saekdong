using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PaperCapture : MonoBehaviour
{
    public RenderTexture r_texture;
    public Canvas ErrPopup;


    public void Awake()
    {
        StartCoroutine(WaitRead());
    }

    public void StoragePermissionCheck()
    {
        NativeGallery.Permission permissionChecker = new NativeGallery.Permission();
        permissionChecker = NativeGallery.CheckPermission(NativeGallery.PermissionType.Write);

        switch(permissionChecker)
        {
            case NativeGallery.Permission.Denied:
                ErrPopup.gameObject.SetActive(true);
                NativeGallery.OpenSettings();
                break;

            case NativeGallery.Permission.Granted:
                SaveTexture();
                break;

            case NativeGallery.Permission.ShouldAsk:
                ErrPopup.gameObject.SetActive(true);
                NativeGallery.RequestPermission(NativeGallery.PermissionType.Write);
                break;
        }

    }
    
    public void ShareTexture()
    {
        Texture2D tex2d = toTexture2D(r_texture);
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, tex2d.EncodeToPNG());
        // To avoid memory leaks
        Destroy(tex2d);
        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").
            SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }


    public void SaveTexture()
    {
        Texture2D tex2d = toTexture2D(r_texture);
        //save image file
        string savePath = System.IO.Path.Combine(Application.persistentDataPath, "save img.png");
        File.WriteAllBytes(savePath, tex2d.EncodeToPNG());
        Debug.Log("saved file in +" + savePath + "shared img.png");
        //save temp image for share
        string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, tex2d.EncodeToPNG());
        // To avoid memory leaks
        Destroy(tex2d);
    }
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    IEnumerator WaitRead()
    {
        yield return new WaitForEndOfFrame();
    }
}
