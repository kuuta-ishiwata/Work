using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Text;
    float time =  30.0f;

    void Start()
    {
        this.Text = GameObject.Find("timetext");

    }

    // Update is called once per frame
    void Update()
    {
        this.time = Time.deltaTime;
      if(this.time < 0)
        {
            this.Text.GetComponent<Text>().text = "Syuury";
        }
        else
        {
            this.Text.GetComponent<Text>().text = this.time.ToString("F1");
        }

    }
}
