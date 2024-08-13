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
        var position = transform.position;
        position.x = playerposirion.x-10.0f;
        position.y = playerposirion.y+6.0f;
        position.z = playerposirion.z-1.0f;
        transform.position = position;

    }
}
