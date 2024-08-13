using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v = rb.velocity;

        Vector3 velovity = new Vector3(30.0f, 0, 0);

        if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.rotation * velovity *Time.deltaTime ;
        }
        else if(UnityEngine.Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.rotation * velovity * Time.deltaTime;
        }

        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            worldAngle.y += 0.8f;
            transform.eulerAngles = worldAngle;
        }
        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            worldAngle.y -= 0.8f;
            transform.eulerAngles = worldAngle;
        }



    }



}
