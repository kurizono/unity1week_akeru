using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//GameSceneのみで使う
public class BoxClick : MonoBehaviour
{
    public string cubeTag = "cube";

    // Update is called once per frame  
    void Update()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            //オブジェクトがcubeタグを持っていたら
            if (hit.collider.gameObject.CompareTag(cubeTag))
            {
                //マウスクリックしたら
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<BoxContoller>().OnUserAction();
                }
            }
        }
    }

    public void OnClick()
    {

    }

}
