using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMsg : MonoBehaviour
{
    public Text MessageText;
    // Start is called before the first frame update
    void Start()
    {
        MessageText.text = TextKeeper.Msg.text;
    }

}
