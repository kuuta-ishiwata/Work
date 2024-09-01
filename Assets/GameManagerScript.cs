using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Item;
    Vector3 position = Vector3.zero;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public static bool flag = false;
    void Start()
    {

        score = 0;
        int[,] map =
        {
         {1,0,0,0,0,0,1 }
        
        };
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x;
                position.y = y+2.5f;
                position.z = y + 20;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);
                }
            }
        }
        int[,] map2 =
        {
         {1,0,0,0,0,0,1 }

        };
        int lenY2 = map.GetLength(0);
        int lenX2 = map.GetLength(1);
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x+200;
                position.y = y + 2.5f;
                position.z = y -140;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);
                }
            }
        }
        int[,] map3 =
       {
         {1,0,0,0,0,0,1 }

        };
        int lenY3 = map.GetLength(0);
        int lenX3 = map.GetLength(1);
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x + 377;
                position.y = y + 2.5f;
                position.z = y +205;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);
                }
            }
        }
        int[,] map4 =
        {
         {1,0,0,0,0,0 }

        };
        int lenY4 = map.GetLength(0);
        int lenX4 = map.GetLength(1);
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x +50;
                position.y = y + 2.5f;
                position.z = y - 420;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);
                }
            }
        }

        if(score == 4)
        {
            flag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE " + score;
    }
}
