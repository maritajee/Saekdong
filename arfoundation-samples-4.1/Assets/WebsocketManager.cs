using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using System.Text;

public class WebsocketManager : MonoBehaviour
{
    string url = "wss://dorothymagic.com:8080/ws/magic";

    WebSocket m_socket = null;

    public string targetMsg;
    public enum AppType
    {
        mobile,
        console
    }
    public AppType curType;
    private void Start()
    {
        for(int i =0; i < 3; i++)
        {
            if(i == 2)
            {
                targetMsg += TouchManager.TowerObjectList[i + 1].transform.GetChild(0).name;
            }
            else
            {
                targetMsg += TouchManager.TowerObjectList[i + 1].transform.GetChild(0).name + ',';
            }
            
        }
        Init();
        SendMsg(targetMsg);
    }

    void Init()
    {
        try
        {
            m_socket = new WebSocket(url);
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

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("try to send !");
            SendMsg(targetMsg);
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
