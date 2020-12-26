using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetting : MonoBehaviour
{
    public GameObject Blue, Green, Yellow, Purple, Red, White;
    private GameObject[] Colors;
    private Color[] colormode;

    public void Awake()
    {
        Colors = new GameObject[6]
        {
            Blue, Green, Yellow, Purple, Red, White
        };
        colormode = new Color[2]
        {
            new Color(1, 1, 1, 1),
            new Color(0.5f, 0.5f, 0.5f, 1)
        };
    }
    public void Start()
    {
        FirstSet();
    }

    public void FirstSet()
    {
        for(int i = 0; i < Colors.Length; i++)
        {
            if(GameParameter.color_switch[i] == 0)
            {
                Colors[i].GetComponent<BoxContoller>().Box_Color = colormode[0];
            }
            else if(GameParameter.color_switch[i] == 1)
            {
                Colors[i].GetComponent<BoxContoller>().Box_Color = colormode[1];
            }
        }
    }
    public void Obj_Click(GameObject obj)
    {
        for(int i = 0; i < Colors.Length; i++)
        {
            if(obj == Colors[i])
            {
                GameParameter.color_switch[i] = (GameParameter.color_switch[i] + 1) % 2;
                if (GameParameter.color_switch[i] == 0)
                {
                    Colors[i].GetComponent<BoxContoller>().Box_Color = colormode[0];
                }
                else if (GameParameter.color_switch[i] == 1)
                {
                    Colors[i].GetComponent<BoxContoller>().Box_Color = colormode[1];
                }
            }
        }
    }
}
