using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    private AudioSource audioSource;
    public GameObject ItemParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v = rb.velocity;

        Vector3 velovity = new Vector3(30.0f, 0, 0);

        if (UnityEngine.Input.GetKey(KeyCode.UpArrow)&&UnityEngine.Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.rotation * velovity *Time.deltaTime ;
        }
        else if(UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
        {
            transform.position -= transform.rotation * velovity * Time.deltaTime;
        }

        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            worldAngle.y += 0.3f;
            transform.eulerAngles = worldAngle;
        }
        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            worldAngle.y -= 0.3f;
            transform.eulerAngles = worldAngle;
        }

        audioSource = gameObject.GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        audioSource.Play();
        Instantiate(ItemParticle, transform.position, Quaternion.identity);
        int  count = 0 ;
        count++;
        if(count == 30)
        {
            other.gameObject.SetActive(true);
        }

    }


}
