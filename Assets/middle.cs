using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class middle : MonoBehaviour
{

    // Start is called before the first frame update

    public  GameObject goalText;
    public static bool flag = false;
    void Start()
    {
        flag = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collsion)
    {

        // �v���C���[�͏����ʒu�Ƀ��[�v������
        // ����ȊO�̃I�u�W�F�N�g�͔j�󂷂�

        if (collsion.gameObject.name == "Player")
        {
            Player player = collsion.gameObject.GetComponent<Player>();
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        goalText.SetActive(true);
        flag = true;
    }



}
