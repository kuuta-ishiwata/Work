using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{

  
    public  GameObject goalText;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        goalText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(middle.flag == true && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }

    }

   




}
