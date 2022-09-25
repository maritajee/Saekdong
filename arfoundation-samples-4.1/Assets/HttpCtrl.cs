using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;
public class HttpCtrl : MonoBehaviour
{
    private List<GameObject> towerObjects = new List<GameObject>();
    public List<GameObject> Shapes = new List<GameObject>();
    string url = "https://dorothymagic.com:8080/api/magicStick";
    [SerializeField]
    public sticklist sticks;
    [SerializeField]
    public postStick postTestData;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Saekdong_v01_5")
        {
            Download();
        }
    }

    //void Update()
    //{
    //    if (input.getkeydown(keycode.q))
    //        startcoroutine(upload(posttestdata));
    //    if (Input.GetKeyDown(KeyCode.G))
    //        StartCoroutine(GetStickList());
    //}

    public void BuildTower()
    {
        float height = -15f;
        for (int i = 0; i < towerObjects.Count; i++)
        {
            Instantiate(towerObjects[i], new Vector3(0f, height, 10f), towerObjects[i].transform.rotation);
            height += towerObjects[i].transform.GetChild(1).gameObject.transform.localPosition.z;
        }
    }
    public void GetObject()
    {
        Debug.Log("Sticks.Items.Length: " + sticks.Items.Length);
        for (int i = 0; i < 7; i++)
        {
            GameObject temp1 = null;
            GameObject temp2 = null;
            GameObject temp3 = null;
            
            for (int j = 0; j < Shapes.Count; j++)
            {
                if (Shapes[j].name == sticks.Items[sticks.Items.Length - 7 + i].object1 + "_Onstick")
                {
                    temp1 = Shapes[j];
                }
                if (Shapes[j].name == sticks.Items[sticks.Items.Length - 7 + i].object2 + "_Onstick")
                {
                    temp2 = Shapes[j];
                }
                if (Shapes[j].name == sticks.Items[sticks.Items.Length - 7 + i].object3 + "_Onstick")
                {
                    temp3 = Shapes[j];
                }

                if (temp1 && temp2 && temp3 != null)
                {
                    break;
                }
            }
            towerObjects.Add(temp1);
            towerObjects.Add(temp2);
            towerObjects.Add(temp3);
        }
    }

    
    public void Upload()
    {
        for(int i = 0; i < 3; i++)
        {
            postTestData.objects[i] = TouchManager.TowerObjectList[i+1].transform.GetChild(0).name;
        }
        StartCoroutine(Upload(postTestData));
    }
    public void Download()
    {
        StartCoroutine(GetStickList());
        
    }


    IEnumerator GetStickList()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string downloadTxt = www.downloadHandler.text;
            string value = "{\"Items\":" + downloadTxt + "}";
            Debug.Log("value :: " + value);
            sticks = new sticklist();
            sticks = JsonUtility.FromJson<sticklist>(value);
            Debug.Log("targetData length:: " + sticks.Items.Length);

            GetObject();
            BuildTower();

        }
    }
    IEnumerator Upload(postStick postdata)
    {
        string targetData = JsonUtility.ToJson(postdata);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(targetData);
        using (UnityWebRequest uwr = UnityWebRequest.Post(url, targetData))
        {
            uwr.uploadHandler = new UploadHandlerRaw(jsonBytes);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            yield return uwr.SendWebRequest();
            yield return new WaitUntil(() => uwr.isDone);
            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log("Form upload complete! :: " + uwr.downloadHandler.text);
            }
            uwr.Dispose();
        }
    }

    IEnumerator WaitSec(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
[System.Serializable]
public struct postStick
{
    [SerializeField]
    public string[] objects;
}
[System.Serializable]
public struct sticklist
{
    [SerializeField]
    public stick[] Items;
}
[System.Serializable]
public struct stick
{
    [SerializeField]
    public string id;
    [SerializeField]
    public string object1;
    [SerializeField]
    public string object2;
    [SerializeField]
    public string object3;
    [SerializeField]
    public string uuid;
}