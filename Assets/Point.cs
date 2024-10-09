using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public static int pointcount = 0;
    void Start()
    {
        pointcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            pointcount += 1;
            Debug.Log(pointcount);

        }

    }
}
