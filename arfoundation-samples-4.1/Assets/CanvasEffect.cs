using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEffect : MonoBehaviour
{
    public GameObject next_btn;
    public GameObject next_txt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSec(0.5f));
        
    }

    IEnumerator WaitSec(float sec)
    {
        yield return new WaitForSeconds(sec);
        next_btn.SetActive(true);
        next_txt.SetActive(true);
    }
}
