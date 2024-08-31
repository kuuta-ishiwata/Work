using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camerascript : MonoBehaviour
{
    public GameObject player;
    Vector3 velovity = new Vector3(35.0f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerposirion = player.transform.position;
        var playerrotation = player.transform.rotation;
        var position = transform.position;
        var rotation = transform.rotation;
        //posiiton
        position.x = playerposirion.x-35.5f;
        position.y = playerposirion.y+25.0f;
        position.z = playerposirion.z;



        transform.position = position;
        transform.rotation = rotation;
    }
}
