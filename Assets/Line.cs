using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    int count = 0;
    void Start()
    {

        count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(count == 4 && Point.pointcount == 3)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Car")
        {
            count += 1;
            Debug.Log(count);

        }

    }

}
