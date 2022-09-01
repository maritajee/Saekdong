using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMessage : MonoBehaviour
{
    private Text message1;
    public Text message2;
    MessageEvent messageEvent;
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("DontDestroyOnLoad/MessageCanvas").gameObject.SetActive(true);
        if (GameObject.Find("DontDestroyOnLoad/MessageCanvas/Message/Text"))
        {
            Debug.Log("Find object");
        }
        else
        {
            Debug.Log("Cant Find");
        }
        
        message1 = GameObject.Find("DontDestroyOnLoad/MessageCanvas/Message/Text").GetComponent<Text>();
        message2.text = message1.text;
        Debug.Log(message1.text);
    }
}
