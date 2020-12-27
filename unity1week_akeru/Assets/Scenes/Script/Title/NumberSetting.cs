using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSetting : MonoBehaviour
{
    public GameObject One, Two, Three, Four;
    private GameObject[] Numbers;
    private Color[] Numbermode;
    // Start is called before the first frame update
    public void Awake()
    {
        Numbers = new GameObject[4]
        {
            One, Two, Three, Four
        };
        Numbermode = new Color[2]
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
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (GameParameter.color_num[i] == 0)
            {
                Numbers[i].GetComponent<BoxContoller>().Box_Color = Numbermode[0];
            }
            else if (GameParameter.color_num[i] == 1)
            {
                Numbers[i].GetComponent<BoxContoller>().Box_Color = Numbermode[1];
            }
        }
    }

    public void Obj_Click(GameObject obj)
    {
        int effective = 0;
        for(int i = 0; i < GameParameter.color_num.Length; i++)
        {
            effective += GameParameter.color_num[i];
        }
        for (int i = 0; i < Numbers.Length; i++)
        {
            if (obj == Numbers[i])
            {
                GameParameter.color_num[i] = (GameParameter.color_num[i] + 1) % 2;
                if (GameParameter.color_num[i] == 0)
                {
                    Numbers[i].GetComponent<BoxContoller>().Box_Color = Numbermode[0];
                }
                else if (GameParameter.color_num[i] == 1)
                {
                    if (effective < GameParameter.color_num.Length - 1)
                    {
                        Numbers[i].GetComponent<BoxContoller>().Box_Color = Numbermode[1];
                    }
                }
            }

        }
    }
}
