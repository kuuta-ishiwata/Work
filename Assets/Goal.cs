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
       
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if (middle.flag == true)
        {
            ItemScript.score -= 1;
        }
        if(ItemScript.score ==6)
        {
            goalText.SetActive(true);
        }

    }

}
