using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        position.x = playerposirion.x-7.0f;
        position.y = playerposirion.y+5.0f;
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

        if (UnityEngine.Input.GetKey(KeyCode.UpArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.rotation * velovity * Time.deltaTime;
        }
        else if (UnityEngine.Input.GetKey(KeyCode.DownArrow) && UnityEngine.Input.GetKey(KeyCode.Space))
        {
            transform.position -= transform.rotation * velovity * Time.deltaTime;
        }

        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {

            Vector3 worldAngle = transform.eulerAngles;
            Vector3 transformAngle = transform.position;
            transformAngle.x += 0.5f;
            worldAngle.y += 0.3f;
            transform.eulerAngles = worldAngle;
            transform.position = transformAngle;
        }
        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 worldAngle = transform.eulerAngles;
            Vector3 transformAngle = transform.position;
            transformAngle.x -= 0.5f;
            worldAngle.y -= 0.3f;
            transform.eulerAngles = worldAngle;
            transform.position = transformAngle;
        }


    }
}
