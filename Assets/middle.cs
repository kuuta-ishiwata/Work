using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class middle : MonoBehaviour
{

    // Start is called before the first frame update

    public GameObject Middle;
    public GameObject goalText;
    public static bool flag = false;
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == true)
        {
            return;
        }
    }
    private void OnCollisionEnter(Collision collsion)
    {

        // プレイヤーは初期位置にワープさせる
        // それ以外のオブジェクトは破壊する

        if (collsion.gameObject.name == "Player")
        {
            Player player = collsion.gameObject.GetComponent<Player>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            goalText.SetActive(true);
    }



}
