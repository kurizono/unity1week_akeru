using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Button : MonoBehaviour
{
    TitleController Controllercs;
    GameObject ControllerObj;

    // Start is called before the first frame update
    void Start()
    {
        ControllerObj = GameObject.FindGameObjectWithTag("GameController");
        Controllercs = ControllerObj.GetComponent<TitleController>();
    }

    private void OnMouseDown()
    {
        Controllercs.LeftArrowClick();
    }
}
