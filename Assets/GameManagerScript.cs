using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Item;
    public GameObject ItemParticle;
    Vector3 position = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public static bool Upflag = false;
    public static bool Downflag = false;
    public static bool bougaiflag = false;
    public static bool AllUpFlag = false;
    public static bool AllspeedDown = false;
    public static bool flag = false;
    void Start()
    {
        
        score = 0;
        int[,] map =
        {
         {1,0,0,0,0,0,0,0 },
     

        };
        int lenY = map.GetLength(0);
        int lenX = map.GetLength(1);
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x+73;
                position.y = y+1.0f;
                position.z = y + 10;
              
                if (map[y, x] == 1)
                {
                    //Instantiate(Item, position, Quaternion.identity);
                    ItemParticle.transform.position = position;
                }
            }
        }
        int[,] map2 =
        {
         {1,0,0,0,0,0,0,1 }

        };
        int lenY2 = map.GetLength(0);
        int lenX2 = map.GetLength(1);
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 1; y++)
            {
                position.x = x + 70;//+480;
                position.y = y + 1.0f;//+ 2.5f;
                position.z = y + 20f;//-140;
                rotation.x = x + 2.0f;
                rotation.y = y + 4.0f;
                if (map[y, x] == 1)
                {
                    //Instantiate(Item, position, Quaternion.identity);
                    ItemParticle.transform.position = position;
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
                position.x = x + 73;
                position.y = y + 1.0f;
                position.z = y ;
                rotation.x = x + 2.0f;
                rotation.y = y + 4.0f;
                transform.eulerAngles = new Vector3(40, 30, 20);
                if (map[y, x] == 1)
                {
                   // Instantiate(Item, position, Quaternion.identity);
                    ItemParticle.transform.position = position;
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
                position.y = y + 1.0f;
                position.z = y - 420;
                rotation.x = x + 2.0f;
                rotation.y = y + 4.0f;
               
                if (map[y, x] == 1)
                {
                    //Instantiate(Item, position, Quaternion.identity);
                    ItemParticle.transform.position = position;
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

        transform.Rotate(new Vector3(0, 0, 20));
        
        if (Car.rand == 1)
        {

            scoreText.text = "Up";
            Upflag = true;

        }
        if (Car.rand == 2)
        {
            scoreText.text = "Down";
            Downflag = true;
        }

        if (Car.rand == 3)
        {
            scoreText.text = "Allup";
            AllUpFlag = true;
        }
        if (Car.rand == 4)
        {
            scoreText.text = "AllDown";
            AllspeedDown = true;
        }



    }
}
