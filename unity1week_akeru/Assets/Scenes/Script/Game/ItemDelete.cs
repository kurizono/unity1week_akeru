using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    private GameObject CatBox;
    // Start is called before the first frame update
    void Start()
    {
        CatBox = GameObject.FindGameObjectWithTag("CatBox");
    }

    void OnTriggerEnter(Collider cat)
    {
        if(cat.gameObject == CatBox)
        {
            Destroy(gameObject);
        }
    }
}
