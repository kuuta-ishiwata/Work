using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    public Rigidbody rb;
    private AudioSource audioSource;
    public GameObject ItemParticle;
    public static float rand;
    int deadcount = 0;
    Vector3 startposition;
    Vector3 velovity = new Vector3(80.0f, 0, 0);
    public string nextSceneName;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startposition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
     
        Vector3 v = rb.velocity;

        
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

       // Debug.Log(count);

        if(middle.flag == true && UnityEngine.Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

       // if(middle.flag == true)
       // {
       //     velovity = new Vector3(0, 0, 0);
       //     return;
       // }

    }
    private void OnTriggerEnter(Collider other)
    {
            other.gameObject.SetActive(false);
            audioSource.Play();
            Instantiate(ItemParticle, transform.position, Quaternion.identity);
            ItemScript.score += 1;
    }

    public void MoveStartPos()
    {
        transform.position = Vector3.zero;
        transform.position = startposition + Vector3.up * 10f;
        transform.rotation = Quaternion.identity;
        deadcount++;
        Debug.Log(deadcount);
    }


    private void OnCollisionEnter(Collision collsion)
    {
        if (collsion.gameObject.name == "wall")
        {
            velovity = Vector3.zero;
        }

        if (collsion.gameObject.name == "wall1")
        {
            velovity = Vector3.zero;
        }
        if (collsion.gameObject.name == "wall2")
        {
            velovity = Vector3.zero;
        }
        if (collsion.gameObject.name == "wall3")
        {
            velovity = Vector3.zero;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "wall")
        {
            velovity = new Vector3(30.0f, 0, 0);
        }
        if (collision.gameObject.name == "wall1")
        {
            velovity = new Vector3(30.0f, 0, 0);
        }
        if (collision.gameObject.name == "wall2")
        {
            velovity = new Vector3(30.0f, 0, 0);
        }
        if (collision.gameObject.name == "wall3")
        {
            velovity = new Vector3(30.0f, 0, 0);
        }
    }


}
