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
        position.x = playerposirion.x;
        position.y = playerposirion.y+50;
        position.z = playerposirion.z-0.5f;
        transform.position = position;

    }
}
