using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;

    float radius =8.0f;
    float speed = 10.0f;
    float Length = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v = rb.velocity;

        Vector3 velocity = new Vector3(30.0f, 0.0f, 0.0f);
        Vector3 velocity2 = new Vector3(-30.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = velocity;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = velocity2;
        }



        if (Input.GetKey(KeyCode.LeftArrow)&&Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(radius * transform.position.x* Mathf.Sin(Time.time * speed),
                0.5f,0.5f);
        }
        

    }



}
