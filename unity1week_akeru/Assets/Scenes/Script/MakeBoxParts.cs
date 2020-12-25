using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBoxParts : MonoBehaviour
{
    //そのboxの回転スピードを変える
    public void MakeBox_Speed(GameObject Box)
    {
        int movedire = Random.Range(0, 2);
        if (movedire == 0)
        {
            movedire = -1;
        }
        Box.GetComponent<BoxContoller>().move = Random.Range(90, 180) * movedire;
    }

    //そのboxの全ての面の色をそろえる
    public void MakeBox_SolidColor(GameObject Box, Sprite color)
    {
        for (int i = 0; i < 6; i++)
        {
            Box.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = color;
        }
    }
}
