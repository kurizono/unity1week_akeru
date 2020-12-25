using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BoxContoller : MonoBehaviour
{
    Rigidbody rigidBody;
    GameObject[] childObject;
    public GameObject GameController;

    //回転速度
    public float move;

    // Use this for initialization
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");

        //rigidBody = gameObject.GetComponent<Rigidbody>();

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
    }

    //マウスが重なれば、暗くなる
    public void OnMouseEnter()
    {
        for (int i = 0; i < childObject.Length; i++)
        {
            childObject[i].GetComponent<SpriteRenderer>().material.color = new Color32(230, 230, 230, 255);
        }
    }
    //マウスが離れれば、明るくなる
    public void OnMouseExit()
    {
        for (int i = 0; i < childObject.Length; i++)
        {
            childObject[i].GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
        }
    }

    //GameSceneのみで使用(クリックしたときは再構築される)
    public void OnUserAction()
    {
        GameController.GetComponent<BoxInfo>().BoxInfo_Remake();
    }
}
