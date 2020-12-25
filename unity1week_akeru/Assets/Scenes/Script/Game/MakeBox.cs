using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;

    //プレハブ
    public GameObject PresentBox;
    public GameObject[] PresentBoxs;
    public GameObject PresentSenter;

    private SpriteRenderer[] PresentSprite;

    //素材
    private Sprite[] RedPatter;
    private Sprite[] BluePatter;
    private Sprite[] GreenPatter;
    private Sprite[] YellowPatter;
    private Sprite[] PurplePatter;
    private Sprite[] WhitePatter;

    private List<Sprite[]> Patter;

    private Vector3[] PresentPosi = new Vector3[4] 
    {
        new Vector3(4, 0),
        new Vector3(0, 4),
        new Vector3(-4, 0),
        new Vector3(0, -4),
    };

    // Start is called before the first frame update
    private void Awake()
    {
        //素材インポート
        RedPatter = Resources.LoadAll<Sprite>("RedSquare");
        BluePatter = Resources.LoadAll<Sprite>("BlueSquare");
        GreenPatter = Resources.LoadAll<Sprite>("GreenSquare");
        YellowPatter = Resources.LoadAll<Sprite>("YellowSquare");
        PurplePatter = Resources.LoadAll<Sprite>("PurpleSquare");
        WhitePatter = Resources.LoadAll<Sprite>("WhiteSquare");
        Patter = new List<Sprite[]>
        {
            RedPatter, BluePatter, GreenPatter, YellowPatter, PurplePatter, WhitePatter
        };

        //4つのプレゼント創る
        PresentBoxs = new GameObject[4];
        for(int i = 0; i < PresentBoxs.Length; i ++)
        {
            PresentBoxs[i] = PresentBox;
            PresentBoxs[i] = Instantiate(PresentBoxs[i]);
            PresentBoxs[i].name = "PresentBoxs" + i;
            PresentBoxs[i].transform.SetParent(PresentSenter.transform, true);
            PresentBoxs[i].transform.position = PresentPosi[i];
        }
    }

    //情報をもとにプレゼントボックス作成
    public void PresentBoxMake(int[] boxcolor, int[,] boxnumber)
    {
        Sprite[] color = RedPatter;
        for(int i = 0; i < boxcolor.Length; i++)
        {
            //箱の色
            color = Patter[boxcolor[i]];
           
            //すべての面の色をそろえる
            for(int j = 0; j < 6; j++)
            {
                PresentBoxs[i].transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().sprite = color[0];
            }
            //面の数字情報を変える
            for(int j = 0; j < boxnumber.GetLength(1); j++)
            {
                PresentBoxs[i].transform.GetChild(j + 2).gameObject.GetComponent<SpriteRenderer>().sprite = color[boxnumber[i,j]];
            }

            //箱の回転を変える
            int movedire = Random.Range(0, 2);
            if(movedire == 0)
            {
                movedire = -1;
            }
            PresentBoxs[i].GetComponent<BoxContoller>().move = Random.Range(90, 180) * movedire;
        }
    }
}
