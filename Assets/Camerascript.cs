using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public GameObject player;
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
        position.x = playerposirion.x-10.0f;
        position.y = playerposirion.y+7.0f;
        position.z = playerposirion.z+3.0f;

        //-5.0f
        //+ 1.0f
        //- 7.0f
        //rotation
        // rotation.x = playerrotation.x;
        // rotation.y = playerrotation.y+0.5f;
        // rotation.z = playerrotation.z;

        transform.position = position;
        transform.rotation = rotation;

    }
}
