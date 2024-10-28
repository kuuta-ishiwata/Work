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
        if (life ==0)
        {
            SceneManager.LoadScene("TitleScene");
        }
        //lifetext.text = "" +life;

    }

    private void OnTriggerEnter(Collider other)
    {

        // �v���C���[�͏����ʒu�Ƀ��[�v������
        // ����ȊO�̃I�u�W�F�N�g�͔j�󂷂�
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.MoveStartPos();
        }
 
        if (life == 0)
        {
            gameOverText.SetActive(true);
        }

    }
 



}
