using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;

    float radius =50.0f;
    float speed = 2.0f;
    float Length = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v = rb.velocity;

        Vector3 velocity = new Vector3(0.2f, 0.0f, 0.0f);
        Vector3 velocity2 = new Vector3(-30.0f, 0.0f, 0.0f);

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    rb.velocity = velocity;
        //}
        //else if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    rb.velocity = velocity2;
        //}




        if (Input.GetKey(KeyCode.LeftArrow))
        {
             transform.RotateAround(velocity, Vector3.up, radius * Time.deltaTime);
            
        }
        

    }



}
