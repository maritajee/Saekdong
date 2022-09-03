using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextKeeper : MonoBehaviour
{
    public static Text Msg = null;
    // Start is called before the first frame update
    public void GetMsg(Text text)
    {
        Msg = text;
        Debug.Log(text.text);
    }
}
