using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitlazieGame : MonoBehaviour
{



    private GameObject MyObject;

    private GameObject Canvas;

    private GameObject MyCamera;

   

    
    void Start()
    {
        MyCamera = GameObject.FindGameObjectWithTag("MainCamera");

        MyCamera.GetComponent<Camera>().orthographicSize = Screen.height / 2;
        MyCamera.GetComponent<Transform>().position = new Vector3(Screen.width/2,Screen.height/2);
        MyObject = GameObject.FindGameObjectWithTag("object");

        Constant.ObjectSize =Screen.width / 10;

        MyObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Constant.ObjectSize, Constant.ObjectSize);
        MyObject.GetComponent<BoxCollider2D>().size = new Vector2(Constant.ObjectSize, Constant.ObjectSize);

        Canvas = GameObject.FindGameObjectWithTag("canvas");

        //Objects = new List<GameObject>();

        InvokeRepeating("CreateObject", 1f, 2f);  //1s delay, repeat every 1s
    }



    void CreateObject()
    {


        Vector3 newlocation = new Vector3(UnityEngine.Random.Range(-Screen.width/2+Constant.ObjectSize, Screen.width/2 - Constant.ObjectSize), Screen.height/2+ Constant.ObjectSize*2, 0);

        GameObject myobject= Instantiate(MyObject, Canvas.transform.position + newlocation, Quaternion.identity, Canvas.transform);
       


        myobject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-300);

        Color MyColor ;
        int Number = UnityEngine.Random.Range(0, 5);


        switch (Number)
        {


            case 0:
                MyColor = Color.red;
                break;

            case 1:
                MyColor = Color.green;
                break;
            case 2:
                MyColor = Color.blue;
                break;

            case 3:
                MyColor = Color.yellow;
                break;

            default:
                MyColor = Color.magenta;
                break;
        }
        myobject.GetComponent<Image>().color = MyColor;
    }
}
