using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageEvent : MonoBehaviour
{
    public InputField messageInput;
  
    private string message;
    void Update()
    {
        if(messageInput.text.Length > 0)
        {
            Debug.Log(messageInput.text);
        }
    }
    public string StoreMessage(Text input)
    {
        message = input.text;
        return message;
    }

    
}
