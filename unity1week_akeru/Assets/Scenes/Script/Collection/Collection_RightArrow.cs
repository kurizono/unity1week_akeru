using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_RightArrow : MonoBehaviour
{
    CollectionController Controllercs;
    GameObject ControllerObj;

    private void Start()
    {
        ControllerObj = GameObject.FindGameObjectWithTag("GameController");
        Controllercs = ControllerObj.GetComponent<CollectionController>();
    }
    private void OnMouseDown()
    {
        Controllercs.RightArrowClick();
    }
}
