using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;
public class Item : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 20);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.5f, 0.5f, 0.0f);


    }
}
