using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.ComponentModel;
public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOverFlag = false;
    public GameObject gameOverText;
    public static int life = 2;
    public TextMeshProUGUI lifetext;
    void Start()
    {
        life = 2;
        gameOverText.SetActive(false);
        gameOverFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        //lifetext.text = "" +life;

    }

    private void OnTriggerEnter(Collider other)
    {

        // プレイヤーは初期位置にワープさせる
        // それ以外のオブジェクトは破壊する
        if (other.CompareTag("Player"))
        {
            Car player = other.gameObject.GetComponent<Car>();
            player.MoveStartPos();
            life = -1;
        }
 
        if(other.CompareTag("Enemy"))
        {
            Car2 player = other.gameObject.GetComponent<Car2>();

        }

        if (life == 0)
        {
            gameOverText.SetActive(true);
        }

    }
 



}
