using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BoxContoller : MonoBehaviour
{
    Rigidbody rigidBody;
    public GameObject[] childObject;
    private GameObject GameControllerObj;

    MakeBoxParts Partscs;

    //回転速度
    public float move;
    //透明度
    public float color_dark  = 1;
    //箱の色
    public Color Box_Color = new Color(1, 1, 1, 1);

    //マウスが乗っているかどうか(1だと乗っている)
    int onmouse = 0;

    // Use this for initialization
    void Start()
    {
        GameControllerObj = GameObject.FindGameObjectWithTag("GameController");

        Partscs = GameControllerObj.GetComponent<MakeBoxParts>();

        Partscs.MakeBox_Speed(gameObject);
        //箱を構成するすべてのオブジェクト
        childObject = new GameObject[gameObject.transform.childCount];
        for(int i = 0; i < childObject.Length; i++)
        {
            childObject[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    //箱は回転する
    private void Update()
    {
        gameObject.transform.Rotate(0, Time.deltaTime*move , 0);
        if (onmouse == 0)
        {
            NoMouse();
        }
    }

    //マウスが重なっていない時の色
    public void NoMouse()
    {
        for (int i = 0; i < childObject.Length; i++)
        {
            childObject[i].GetComponent<SpriteRenderer>().material.color = Box_Color;
        }
    }

    //マウスが重なれば、暗くなる
    public void OnMouseEnter()
    {
        onmouse = 1;
        for (int i = 0; i < childObject.Length; i++)
        {
            //元データ * (0.9, 0.9, 0.9, 1)
            childObject[i].GetComponent<SpriteRenderer>().material.color = Box_Color * new Color(0.9f, 0.9f, 0.9f, 1);
        }
    }
    public void OnMouseOver()
    {
        for (int i = 0; i < childObject.Length; i++)
        {
            //元データ * (0.9, 0.9, 0.9, 1)
            childObject[i].GetComponent<SpriteRenderer>().material.color = Box_Color * new Color(0.9f, 0.9f, 0.9f, 1);
        }
    }
    //マウスが離れれば、明るくなる
    public void OnMouseExit()
    {
        onmouse = 0;
    }

    //GameSceneのみで使用(クリックしたときは再構築される)
    public void OnUserAction()
    {
        if (GameControllerObj.GetComponent<GameController>().AnsCheck(gameObject) == 1)
        {
            GameControllerObj.GetComponent<BoxInfo>().BoxInfo_Remake();
        }
    }

    //GameSceneのみで使用(だんだん薄くなる)
    public void BoxDelete(float post_dark)
    {
        color_dark = post_dark;
        Box_Color = new Color(1, 1, 1, color_dark);
    }
}
