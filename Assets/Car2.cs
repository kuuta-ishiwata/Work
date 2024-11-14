using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class AxleInfo2
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}



public class Car2 : MonoBehaviour
{
    public Rigidbody rb;
    public List<AxleInfo2> axleInfos;
    public float maxMotorTorque = 150f;
    public float maxSteeringAngle = 30.0f;

    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    public Transform wheelFLTrans;
    public Transform wheelFRTrans;
    public Transform wheelBLTrans;
    public Transform wheelBRTrans;

    float steering = 0.0f;
    float motor = 0.0f;

    public float speed = 120.0f;
    public float TurnSpeed = 40.0f;
    public float Break;
    private int PointIndex = 0; 
    public Transform[] Point;
  


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
       
      if(Point.Length == 0)
        {
            return;
        }
        Vector3 Pos = Point[PointIndex].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * maxSteeringAngle);

         motor = maxMotorTorque;
         steering = Vector3.Angle(transform.forward, Pos);
        foreach (AxleInfo2 axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
           // if (Vector3.Distance(transform.position, Point[PointIndex].position) < 3.0f)
           // {
           //     axleInfo.leftWheel.brakeTorque = Break;
           //     axleInfo.rightWheel.brakeTorque = Break;
           //     axleInfo.leftWheel.motorTorque = 0;
           //     axleInfo.rightWheel.motorTorque = 0;
           // }
           

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        //if (axleInfo2.motor)
        //{
        //    axleInfo2.rightWheel.brakeTorque = brake;
        //    axleInfo2.rightWheel.brakeTorque = brake;
        //}
        if (Pos.magnitude < 3.0f)
        {
            PointIndex = (PointIndex + 1) % Point.Length;
        }

        //if (Vector3.Distance(transform.position, target2.position) > 1f)
        //{
        //    transform.LookAt(target3);
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
        //if(Vector3.Distance(transform.position,target3.position) > 1f)
        //{
        //    transform.LookAt(target4);
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}


    }


 
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        {
            return;
        }
        Transform VisualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        VisualWheel.transform.position = position;
        VisualWheel.transform.rotation = rotation;

            
    }


}
