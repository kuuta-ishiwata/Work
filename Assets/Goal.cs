using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            player.Goalpos();
        }

    }
}
