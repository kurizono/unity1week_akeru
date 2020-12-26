using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Button : MonoBehaviour
{
    TitleController Controllercs;
    GameObject ControllerObj;

    void Start()
    {
        ControllerObj = GameObject.FindGameObjectWithTag("GameController");
        Controllercs = ControllerObj.GetComponent<TitleController>();
    }

    public void OnMouseDown()
    {
        Controllercs.StoryClick();
    }

}
