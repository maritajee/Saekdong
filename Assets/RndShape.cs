using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using System.Text;

public class RndShape : MonoBehaviour
{
    public List<GameObject> Shapes = new List<GameObject>();
    string url = "https://dorothymagic.com:8080/api/magicStick";
    [SerializeField]
    public postStick postTestData;


    public void pplay()
    {
        for (int i = 0; i < 3; i++)
        {
            postTestData.objects[i] = Shapes[UnityEngine.Random.Range(0,Shapes.Count - 1)].name;
        }
        StartCoroutine(Upload(postTestData));
        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                targetMsg += postTestData.objects[i];
            }
            else
            {
                targetMsg += postTestData.objects[i] + ',';
            }

        }
        Init();
        SendMsg(targetMsg);
        targetMsg = "";
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



    string url2 = "wss://dorothymagic.com:8080/ws/magic";

    WebSocket m_socket = null;

    public string targetMsg;
    public enum AppType
    {
        mobile,
        console
    }
    public AppType curType;
    

    void Init()
    {
        try
        {
            m_socket = new WebSocket(url2);
            m_socket.OnOpen += OnOpen;
            m_socket.OnMessage += OnMessageReceived;
            m_socket.OnError += OnError;
            m_socket.OnClose += OnClosed;

        }
        catch (Exception e)
        {
            Debug.LogError("Error Msg: " + e.ToString());
        }

        Connect();

        //Connect message received Type
        switch (curType)
        {
            case AppType.mobile:
                break;

            case AppType.console:
                SendMsg("Client");
                break;

        }

    }

    void Connect()
    {
        try
        {
            if (m_socket == null || !m_socket.IsAlive)
            {
                m_socket.Connect();

            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error Msg: " + e.ToString());
        }
    }

    public void SendMsg(string msg)
    {
        if (!m_socket.IsAlive)
            return;

        try
        {
            Debug.Log("try to send Msg: " + msg);
            //m_socket.Send( Encoding.UTF8.GetBytes(msg));
            m_socket.Send((msg));
        }
        catch (Exception e)
        {
            Debug.Log("Error Msg: " + e.ToString());
            throw;
        }
    }

    void OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log(" on opened");
    }

    void OnClosed(object sender, CloseEventArgs e)
    {

        Debug.Log("  OnClosed Reason :: " + e.Reason);
        Debug.Log("  OnClosed Reason :: " + e.ToString());
    }

    void OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log("  OnError :: " + e.Message);
    }

    public string[] resultData = new string[3];
    void OnMessageReceived(object sender, MessageEventArgs e)
    {
        Debug.Log("  get Message ----- :: " + e.Data);
        OnMagicSticRecieved(e.Data, out resultData);
    }

    public List<string> mobileMsgs = new List<string>();
    public Queue<string> q_mobileMsgs = new Queue<string>();
    void OnMagicSticRecieved(string data, out string[] results)
    {
        results = new string[3];
        results = data.Split(',');
        q_mobileMsgs.Enqueue(data);

    }

    string[] curTargetMagicArray = new string[3];

    void CreateMagicStick()
    {
        string targetStr = q_mobileMsgs.Dequeue();
        curTargetMagicArray = targetStr.Split(',');

    }
}