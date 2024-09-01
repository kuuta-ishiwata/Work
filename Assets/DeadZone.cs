using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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
        if (gameOverFlag == true && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
        lifetext.text = "Life" +life;

    }

    private void OnTriggerEnter(Collider other)
    {

        // プレイヤーは初期位置にワープさせる
        // それ以外のオブジェクトは破壊する
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.MoveStartPos();
        }
        life -= 1;
        if (life == 0)
        {
            gameOverText.SetActive(true);
        }

    }
 



}
