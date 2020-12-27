using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    //GameParameterから情報加工
    public int[] boxcolor_info = new int[0];
    public int[] boxwritenum_info = new int[0];

    int[] boxcolor;
    int[,] boxnumber;
    int boxnum;
    int[] boxpanel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameParameter.color_switch.Length; i++)
        {
            if (GameParameter.color_switch[i] == 0)
            {
                Array.Resize(ref boxcolor_info, boxcolor_info.Length + 1);
                boxcolor_info[boxcolor_info.Length - 1] = i;
            }
        }
        for(int i = 0; i < GameParameter.color_num.Length; i++)
        {
            if(GameParameter.color_num[i] == 0)
            {
                Array.Resize(ref boxwritenum_info, boxwritenum_info.Length + 1);
                boxwritenum_info[boxwritenum_info.Length - 1] = i;
            }
        }

        boxnum = 4;
        boxpanel = GameParameter.color_num;
        boxcolor = new int[boxnum];
        boxnumber = new int[boxnum, boxpanel.Length];

        BoxInfo_Remake();

    }

    //プレゼントボックスを作り直す
    public void BoxInfo_Remake()
    {
        for (int i = 0; i < boxnum; i++)
        {
            //色を決める
            boxcolor[i] = boxcolor_info[UnityEngine.Random.Range(0, boxcolor_info.Length)];
            //数字を決める(初期化)
            for (int j = 0; j < boxpanel.Length; j++)
            {
                boxnumber[i, j] = 0;
            }
            //数字を決める
            for (int j = 0; j < boxwritenum_info[UnityEngine.Random.Range(0, boxwritenum_info.Length)] + 1; j++)
            {
                Debug.Log(j);
                boxnumber[i, j] = UnityEngine.Random.Range(1, 101);
            }
        }
        GetComponent<MakeBox>().PresentBoxMake(boxcolor, boxnumber);
    }

    //ボックスの値を計算する
    public int[] BoxInfo_Cul()
    {
        int[] num = new int[boxnum];
        for (int i = 0; i < boxnum; i++)
        {
            for (int j = 0; j < boxpanel.Length; j++)
            {
                num[i] += boxnumber[i, j];
            }
        }
        return num;
    }
}
