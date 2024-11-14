using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
 
}



public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float brakeTorque;

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
   
    Vector3 up = new Vector3(50, 100, 50);

    public static int UpCount = 0;
    public static int DownCount = 0;
    public static int AllDownCount = 0;
    public static int AllUpCount = 0;

   

    public AudioSource audioSource;
    public GameObject ItemParticle;
    public static int rand;
    Vector3 startposition = new Vector3(-106, -7, 15);
    int deadcount = 0;
    //����
    [SerializeField] private Vector3 _accleration;

    //�����x

    [SerializeField]
    [Tooltip("�v���C���[�̃v���n�u��ݒ�")]
    private GameObject playerPrefab;

    private Vector3 playerPosiiton;
    JointSpring suspensionSpring = new JointSpring();
    WheelFrictionCurve frictionCurve = new WheelFrictionCurve();
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startposition = transform.position;
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    
        suspensionSpring.spring = 35000f; // �T�X�y���V�����̂΂˒萔
        suspensionSpring.damper = 4500f; // �T�X�y���V�����̌����萔
        suspensionSpring.targetPosition = 0.5f; // �T�X�y���V�����̖ڕW�ʒu


    }

    // Update is called once per frame
    void Update()
    {
       
       
        frictionCurve.extremumSlip = 0.4f; // �Ɍ��l�̊���
        frictionCurve.extremumValue = 1.0f; // �Ɍ��l�̖��C��
        frictionCurve.asymptoteSlip = 0.8f; // �Q�ߒl�̊���
        frictionCurve.asymptoteValue = 0.5f; // �Q�ߒl�̖��C��
        frictionCurve.stiffness = 1.0f; // ���C�̍���
        
      
        // Debug.Log(transform.position);
        //wheelFLTrans.Rotate(wheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelFRTrans.Rotate(wheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelBLTrans.Rotate(wheelBL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelBRTrans.Rotate(wheelBR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //
        ////wheelcollider�̊p�x�ɍ��킹�ă^�C�����f������]����i�t�����g�̂݁j
        //wheelFLTrans.localEulerAngles = new Vector3(wheelFLTrans.localEulerAngles.x, wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z, wheelFLTrans.localEulerAngles.z);
        //wheelFRTrans.localEulerAngles = new Vector3(wheelFRTrans.localEulerAngles.x, wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z, wheelFRTrans.localEulerAngles.z);


        //�X�s�[�hUp
        if (GameManagerScript.Upflag == true)
        {
           
            UpCount++;
            maxMotorTorque  = 600;

        }

        if (UpCount >= 420)
        {
            GameManagerScript.Upflag = false;
         
        }
        //AllSpeedIp
        if (GameManagerScript.AllUpFlag == true)
        {
          
            AllUpCount++;
            maxMotorTorque = 350.0f;

        }
        if (AllUpCount >= 420)
        {
            GameManagerScript.AllUpFlag = false;
            maxMotorTorque = 350.0f;
          
        }
        //�X�s�[�h�_�E��
        if (GameManagerScript.Downflag == true)
        {
            maxMotorTorque = 300.0f;
            DownCount++;

        }
        if (DownCount >= 540)
        {
            GameManagerScript.Downflag = false;
            maxMotorTorque = 100.0f;

        }
        //if(GameManagerScript.Downflag == false)
        //{
        //    DownCount = 0;
        //}
        //All�X�s�[�h�_�E��
        if (GameManagerScript.AllspeedDown == true)
        {
            motor -= 50;
            AllDownCount++;

        }
        if (AllDownCount >= 540)
        {
            GameManagerScript.AllspeedDown = false;
            motor += 50;

        }

        float brake = 0;

        // Debug.Log("button0");
        if (Input.GetKey("joystick button 0"))
        {
            motor = maxMotorTorque;
           
        }
        if (Input.GetKey("joystick button 1"))
        {
            motor = -maxMotorTorque;
          
        }
        if (Input.GetKey("joystick button 3"))
        {
        
            brake = brakeTorque;
           
        }

        if (Input.GetKey(KeyCode.Space))
        {

            brake = brakeTorque;
        }

        steering = maxSteeringAngle * Input.GetAxis("Horizontal");


        foreach (AxleInfo axleInfo in axleInfos)
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
            if (axleInfo.motor)
            {
                axleInfo.rightWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
            }


            axleInfo.rightWheel.brakeTorque = brake;
            axleInfo.rightWheel.brakeTorque = brake;
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);

            // �eWheelCollider�ɐݒ�
            axleInfo.leftWheel.forwardFriction = frictionCurve;
            axleInfo.rightWheel.forwardFriction = frictionCurve;
            axleInfo.leftWheel.sidewaysFriction = frictionCurve;
            axleInfo.rightWheel.sidewaysFriction = frictionCurve;

            // �eWheelCollider�ɐݒ�
           axleInfo.leftWheel.suspensionSpring = suspensionSpring;
           axleInfo.rightWheel.suspensionSpring = suspensionSpring;




        }
    }
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;


    }

    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(ItemParticle, transform.position, Quaternion.identity);
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            rand = Random.Range(1, 5);
            Instantiate(ItemParticle, transform.position, Quaternion.identity);
            Debug.Log(rand);
        }
    }
    public void MoveStartPos()
    {


        GameObject playerObj = GameObject.Find(playerPrefab.name);
        //playerobj�����݂��Ȃ��ꍇ

        GameObject newPlayerObj = Instantiate(playerPrefab, playerPosiiton, Quaternion.identity);

        newPlayerObj.name = playerPrefab.name;
        // �ǉ��F�v���C���[�̈ʒu��s�x�X�V
        playerPosiiton = playerObj.transform.localPosition;

        deadcount += 1;
        audioSource.Play();
        DeadZone.life--;
       // Debug.Log(DeadZone.gameOverFlag);
       // Debug.Log(DeadZone.life);
        if (DeadZone.life == 0)
        {
            DeadZone.gameOverFlag = true;
        }
    }
}
