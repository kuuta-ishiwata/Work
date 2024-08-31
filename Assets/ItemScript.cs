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
    public static int score = 0;


    Vector3 position = Vector3.up;
    void Start()
    {
        score = 0;
        //int[,] map =
        //{
        //    {1,0,0,0,0,0,0,0},
        //    {0,0,0,0,0,0,0,0},
        //};
        //int lenY = map.GetLength(0);
        //int lenX = map.GetLength(1);
        //
        //for (int x = 0; x < 8; x++)
        //{
        //    for (int y = 0; y < 2; y++)
        //    {
        //        position.x = +x+50;
        //        position.y = +2.5f;
        //        position.z = y+20.0f;
        //
        //        if (map[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}



        //int[,] map2 =
        //{
        //    {1},
        //};
        //int lenY2 = map.GetLength(0);
        //int lenX2 = map.GetLength(1);
        //for (int x = 0; x < 1; x++)
        //{
        //    for (int y = 0; y < 1; y++)
        //    {
        //        position.x = +x + 285;
        //        position.y = +2.5f;
        //        position.z = y - 40.0f;
        //        Debug.Log(position);
        //        if (map2[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}
        //
        //int[,] map3 =
        //{
        //    {1},
        //};
        //int lenY3 = map.GetLength(0);
        //int lenX3 = map.GetLength(1);
        //for (int x = 0; x < 1; x++)
        //{
        //    for (int y = 0; y < 1; y++)
        //    {
        //        position.x = +x +300;
        //        position.y = +2.5f;
        //        position.z = y - 215.0f;
        //        Debug.Log(position);
        //        if (map2[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}
        //int[,] map4 =
       //{
        //    {1},
        //};
        //int lenY4 = map.GetLength(0);
        //int lenX4 = map.GetLength(1);
        //for (int x = 0; x < 1; x++)
        //{
        //    for (int y = 0; y < 1; y++)
        //    {
        //        position.x = +x + 300;
        //        position.y = +2.5f;
        //        position.z = y - 295.0f;
        //        Debug.Log(position);
        //        if (map2[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}
        //int[,] map5 =
        //{
        //    {1},
        //};
        //int lenY5 = map.GetLength(0);
        //int lenX5 = map.GetLength(1);
        //for (int x = 0; x < 1; x++)
        //{
        //    for (int y = 0; y < 1; y++)
        //    {
        //        position.x = x + 255;
        //        position.y = +2.5f;
        //        position.z = y - 460.0f;
        //        Debug.Log(position);
        //        if (map2[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}
        //int[,] map6 =
        //{
        //    {1},
        //};
        //int lenY6 = map.GetLength(0);
        //int lenX6 = map.GetLength(1);
        //for (int x = 0; x < 1; x++)
        //{
        //    for (int y = 0; y < 1; y++)
        //    {
        //        position.x = x-100;
        //        position.y = +2.5f;
        //        position.z = y - 420.0f;
        //        Debug.Log(position);
        //        if (map2[y, x] == 1)
        //        {
        //            Instantiate(Item, position, Quaternion.identity);
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
            ItemText.text = "SCORE" + score;
    }


 }
