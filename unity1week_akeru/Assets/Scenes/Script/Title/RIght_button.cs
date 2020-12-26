using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIght_button : MonoBehaviour
{
    TitleController Controllercs;
    GameObject ControllerObj;

    private void Start()
    {
        ControllerObj = GameObject.FindGameObjectWithTag("GameController");
        Controllercs = ControllerObj.GetComponent<TitleController>();
    }
    private void OnMouseDown()
    {
        Controllercs.RightArrowClick();
    }
}
