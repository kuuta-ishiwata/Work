using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    public Rigidbody rb;
    private AudioSource audioSource;
    public GameObject ItemParticle;
    public static int rand;
    public static int DownCount;
    public static int AllDownCount;
   
    int deadcount = 0;
    Vector3 startposition;
    Vector3 velovity = new Vector3(30.0f, 0, 0);
    public string nextSceneName;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        startposition = transform.position;

        Vector3 v = rb.velocity;
        if (middle.flag == false)
        {
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.rotation * velovity * Time.deltaTime;
            }
             if (UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                transform.position -= transform.rotation * velovity * Time.deltaTime;
            }

            if (UnityEngine.Input.GetKey(KeyCode.UpArrow)&&UnityEngine.Input.GetKey(KeyCode.RightArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                //transform.position += transform.rotation * velovity * Time.deltaTime;
                Vector3 worldAngle = transform.eulerAngles;
                worldAngle.y += 0.3f;
                transform.eulerAngles = worldAngle;
            }
             if (UnityEngine.Input.GetKey(KeyCode.UpArrow)&&UnityEngine.Input.GetKey(KeyCode.LeftArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                //transform.position += transform.rotation * velovity * Time.deltaTime;
                Vector3 worldAngle = transform.eulerAngles;
                worldAngle.y -= 0.3f;
                transform.eulerAngles = worldAngle;
            }
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.RightArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                //transform.position += transform.rotation * velovity * Time.deltaTime;
                Vector3 worldAngle = transform.eulerAngles;
                worldAngle.y += 0.3f;
                transform.eulerAngles = worldAngle;
            }
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.LeftArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
            {
                //transform.position += transform.rotation * velovity * Time.deltaTime;
                Vector3 worldAngle = transform.eulerAngles;
                worldAngle.y -= 0.3f;
                transform.eulerAngles = worldAngle;
            }




        }
        
        audioSource = gameObject.GetComponent<AudioSource>();

       // Debug.Log(count);

        if(middle.flag == true && UnityEngine.Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

       if(GameManagerScript.Upflag == true)
        {
            velovity = new Vector3(40.0f, 0, 0);
   
        }
   
        if (GameManagerScript.Upflag == false)
        {
             velovity = new Vector3(30.0f, 0, 0);
        }


        if (GameManagerScript.Downflag == true)
        {
            velovity = new Vector3(5.0f, 0, 0);
            DownCount++;
            Debug.Log(DownCount);
        }
        if(DownCount >= 110)
        {
            DownCount = 0;
            GameManagerScript.Downflag = false;
        }
        if (GameManagerScript.Downflag == false)
        {
             velovity = new Vector3(30.0f, 0, 0);
        }
        if (GameManagerScript.AllspeedDown == true)
        {
            Vector3 velovity = new Vector3(5.0f, 0, 0);
            Debug.Log(velovity);
        }
        if(GameManagerScript.AllspeedDown == false)
        {
            Vector3 velovity = new Vector3(30.0f, 0, 0);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            rand = Random.Range(1,6);
            Instantiate(ItemParticle, transform.position, Quaternion.identity);
            Debug.Log(rand);

        }
    }
    
    public void MoveStartPos()
    {
        
        transform.position = startposition + Vector3.up * 80f;
        transform.rotation = Quaternion.identity;
        deadcount += 1;
        audioSource.Play();
        DeadZone.life--;
        Debug.Log(DeadZone.gameOverFlag);
        Debug.Log(DeadZone.life);

        if(DeadZone.life == 0)
        {
            DeadZone.gameOverFlag = true;
        }

    }


    private void OnCollisionEnter(Collision collsion)
    {
        if (collsion.gameObject.name == "wall")
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

    }


}
