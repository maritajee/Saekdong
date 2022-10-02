using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEffect : MonoBehaviour
{
    public GameObject next_txt1;
    public GameObject next_txt2;
    public GameObject next_btn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSec(0.5f));
        
    }

    IEnumerator WaitSec(float sec)
    {
        yield return new WaitForSeconds(sec);
        next_txt1.SetActive(true);
        yield return new WaitForSeconds(sec);
        next_txt2.SetActive(true);
        next_btn.SetActive(true);
    }
}
