using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MakeBoxParts : MonoBehaviour
{
    //そのboxの回転スピードを変える
    public void MakeBox_Speed(GameObject Box)
    {
        int movedire = UnityEngine.Random.Range(0, 2);
        if (movedire == 0)
        {
            movedire = -1;
        }
        Box.GetComponent<BoxContoller>().move = UnityEngine.Random.Range(90, 180) * movedire;
    }

    //そのboxの全ての面の色をそろえる
    public void MakeBox_SolidColor(GameObject Box, Sprite color)
    {
        for (int i = 0; i < 6; i++)
        {
            Box.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = color;
        }
    }

    //そのboxの面を指定した数だけ数字に変える
    public void MakeBox_NumberChange(GameObject Box, int num)
    {
        if (num > 4)
        {
            Debug.LogError("指定する面の数が多すぎる");
        }
        else {
            for (int i = 0; i < num; i++)
            {
                //Box.transform.GetChild(i+2).gameObject.GetComponent<SpriteRenderer>
            } 
        }
    }

    //そのboxの面をランダムに入れ替える
    public void MakeBox_RandomChange(GameObject Box)
    {
        int[] ary1 = new int[4] { 0, 1, 2, 3 };
        int[] ary2 = ary1.OrderBy(i => Guid.NewGuid()).ToArray();
        Sprite[] PreSprite = new Sprite[ary1.Length];
        for(int i = 0; i < ary1.Length; i++)
        {
            PreSprite[i] = Box.transform.GetChild(ary1[i] + 2).gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        for(int i = 0; i < ary1.Length; i++)
        {
            Box.transform.GetChild(ary1[i] + 2).gameObject.GetComponent<SpriteRenderer>().sprite = PreSprite[ary2[i]];
        }
    }
}
