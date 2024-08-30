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

        //-5.0f
        //+ 1.0f
        //- 7.0f
        //rotation
        // rotation.x = playerrotation.x;
        // rotation.y = playerrotation.y+0.5f;
        // rotation.z = playerrotation.z;

        transform.position = position;
        transform.rotation = rotation;

        //if (UnityEngine.Input.GetKey(KeyCode.UpArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
        //{
        //    transform.position += transform.rotation * velovity * Time.deltaTime;
        //}
        //else if (UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
        //{
        //    transform.position -= transform.rotation * velovity * Time.deltaTime;
        //}
        //
        //if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        //{
        //
        //    Vector3 worldAngle = transform.eulerAngles;
        //    worldAngle.y += 0.2f;
        //
        //    transform.eulerAngles = worldAngle;
        //}
        //if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Vector3 worldAngle = transform.eulerAngles;
        //    worldAngle.y -= 0.2f;
        //
        //    transform.eulerAngles = worldAngle;
        //}

        //if (playerrotation.y >= -75.0f)
        //{
        //    Vector3 transformAngle = transform.position;
        //    transformAngle.x -= 15.1f;
        //    transform.position = transformAngle;
        //}
       // if(playerrotation.y >= 140.0f)
       // {
       //     Vector3 transformAngle = transform.position;
       //     transformAngle.x += 5.1f;
       //     transform.position = transformAngle;
       // }
    }
}
