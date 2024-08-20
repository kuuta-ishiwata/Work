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

        // プレイヤーは初期位置にワープさせる
        // それ以外のオブジェクトは破壊する
        if (collsion.gameObject.name == "Player")
        {
            Player player = collsion.gameObject.GetComponent<Player>();
            player.Goalpos();
        }

    }
}
