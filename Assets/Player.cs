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
    public static int UpCount = 0;
    public static int DownCount = 0;
    public static int AllDownCount = 0;
    public static int AllUpCount = 0;

    int deadcount = 0;
    Vector3 startposition;
    Vector3 velovity = new Vector3(30.0f, 0.0f, 0);
    //Vector3 velocity2 = new Vector3(0.0f, -30.0f, 0);
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
        audioSource = gameObject.GetComponent<AudioSource>();
       // Debug.Log(count);
        if(middle.flag == true && UnityEngine.Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        //スピードUp
       if(GameManagerScript.Upflag == true)
        {
            velovity = new Vector3(60.0f, 0, 0);
            UpCount++;
            Debug.Log(velovity);

        }
   
        if (UpCount >= 420)
        {
            GameManagerScript.Upflag = false;
            velovity = new Vector3(30.0f, 0, 0);
            Debug.Log(velovity);
        }
        //AllSpeedIp
        if (GameManagerScript.AllUpFlag== true)
        {
            velovity = new Vector3(60.0f, 0, 0);
            AllUpCount++;
            Debug.Log(velovity);

        }
        if (AllUpCount >= 420)
        {
            GameManagerScript.AllUpFlag = false;
            velovity = new Vector3(30.0f, 0, 0);
            Debug.Log(velovity);
        }
        //スピードダウン
        if (GameManagerScript.Downflag == true)
        {
            velovity = new Vector3(5.0f, 0, 0);
            DownCount++;
           
        }
        if(DownCount >= 540)
        {
            GameManagerScript.Downflag = false;
            velovity = new Vector3(30.0f, 0, 0);
          
        }
        //if(GameManagerScript.Downflag == false)
        //{
        //    DownCount = 0;
        //}
        //Allスピードダウン
        if (GameManagerScript.AllspeedDown == true)
        {
            velovity = new Vector3(5.0f, 0, 0);
            AllDownCount++;
           
        }
        if (AllDownCount >= 540)
        {
            GameManagerScript.AllspeedDown = false;
            velovity = new Vector3(30.0f, 0, 0);
          
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
