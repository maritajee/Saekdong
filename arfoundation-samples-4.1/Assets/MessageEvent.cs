using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageEvent : MonoBehaviour
{
    public InputField messageInput;
    public string message;
    public GameObject textDisplay;

    public void StoreMessage()
    {
        if (message.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            message = messageInput.GetComponent<InputField>().text;
            textDisplay.GetComponent<Text>().text = message;
        }
    }
}
