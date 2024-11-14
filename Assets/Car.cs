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
    //加速
    [SerializeField] private Vector3 _accleration;

    //初速度

    [SerializeField]
    [Tooltip("プレイヤーのプレハブを設定")]
    private GameObject playerPrefab;

    private Vector3 playerPosiiton;
    JointSpring suspensionSpring = new JointSpring();
    WheelFrictionCurve frictionCurve = new WheelFrictionCurve();
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startposition = transform.position;
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    
        suspensionSpring.spring = 35000f; // サスペンションのばね定数
        suspensionSpring.damper = 4500f; // サスペンションの減衰定数
        suspensionSpring.targetPosition = 0.5f; // サスペンションの目標位置


    }

    // Update is called once per frame
    void Update()
    {
       
       
        frictionCurve.extremumSlip = 0.4f; // 極限値の滑り
        frictionCurve.extremumValue = 1.0f; // 極限値の摩擦力
        frictionCurve.asymptoteSlip = 0.8f; // 漸近値の滑り
        frictionCurve.asymptoteValue = 0.5f; // 漸近値の摩擦力
        frictionCurve.stiffness = 1.0f; // 摩擦の剛性
        
      
        // Debug.Log(transform.position);
        //wheelFLTrans.Rotate(wheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelFRTrans.Rotate(wheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelBLTrans.Rotate(wheelBL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //wheelBRTrans.Rotate(wheelBR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        //
        ////wheelcolliderの角度に合わせてタイヤモデルを回転する（フロントのみ）
        //wheelFLTrans.localEulerAngles = new Vector3(wheelFLTrans.localEulerAngles.x, wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z, wheelFLTrans.localEulerAngles.z);
        //wheelFRTrans.localEulerAngles = new Vector3(wheelFRTrans.localEulerAngles.x, wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z, wheelFRTrans.localEulerAngles.z);


        //スピードUp
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
        //スピードダウン
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
        //Allスピードダウン
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

            // 各WheelColliderに設定
            axleInfo.leftWheel.forwardFriction = frictionCurve;
            axleInfo.rightWheel.forwardFriction = frictionCurve;
            axleInfo.leftWheel.sidewaysFriction = frictionCurve;
            axleInfo.rightWheel.sidewaysFriction = frictionCurve;

            // 各WheelColliderに設定
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
        //playerobjが存在しない場合

        GameObject newPlayerObj = Instantiate(playerPrefab, playerPosiiton, Quaternion.identity);

        newPlayerObj.name = playerPrefab.name;
        // 追加：プレイヤーの位置を都度更新
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
