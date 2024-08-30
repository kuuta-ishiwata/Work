using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Item;
    public  TextMeshProUGUI ItemText;
    public static bool flag = false;
    public static bool flag1 = false;
    public static bool randflag = false;
    public static int count = 0;


    Vector3 position = Vector3.up;
    void Start()
    {
       
        int[,] map =
        {
            {1},
            {0},{0},{0},{0},{0},{0},
            {1},
            {0},{0},{0},{0},{0},{0},
            {1},
            {0},{0},{0},{0},{0},{0},
            {1}
        };
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 22; y++)
            {
                position.x = -x -10;
                position.y = +2.5f;
                position.z = y -10;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);
                   
                }
            }
        }



        int[,] map2 =
        {
            {1},
            {0},{0},{0},{0},{0},{0},
            {1},
            {0},{0},{0},{0},{0},{0},
            {1},
            {0},{0},{0},{0},{0},{0},
            {1}
        };
        int lenY2 = map.GetLength(0);
        int lenX2 = map.GetLength(1);
        for (int x = 0; x < 1; x++)
        {
            for (int y = 0; y < 22; y++)
            {
                position.x = -x - 20;
                position.y = +2.5f;
                position.z = y - 425;
                if (map[y, x] == 1)
                {
                    Instantiate(Item, position, Quaternion.identity);

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (randflag == true)
        {
            if (Player.rand == 0)
            {
                flag = true;
                flag1 = false;
            }

            if (Player.rand == 1)
            {
                flag1 = true;
                flag = false;
            }



            if (flag == true)
            {

                ItemText.text = "kinoko";

                randflag = false;
            }
            if (flag1 == true)
            {

                ItemText.text = "koura";
                randflag = false;
            }
        }

    }

    
}
