using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    MakeBoxParts Partscs;


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
        Partscs = GetComponent<MakeBoxParts>();

        //素材インポート
       
        BluePatter = Resources.LoadAll<Sprite>("BlueSquare");
        GreenPatter = Resources.LoadAll<Sprite>("GreenSquare");
        YellowPatter = Resources.LoadAll<Sprite>("YellowSquare");
        PurplePatter = Resources.LoadAll<Sprite>("PurpleSquare");
        RedPatter = Resources.LoadAll<Sprite>("RedSquare");
        WhitePatter = Resources.LoadAll<Sprite>("WhiteSquare");
        Patter = new List<Sprite[]>
        {
            BluePatter, GreenPatter, YellowPatter, PurplePatter, RedPatter, WhitePatter
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
            Partscs.MakeBox_SolidColor(PresentBoxs[i], color[0]);
            
            //面の数字情報を変える
            for(int j = 0; j < boxnumber.GetLength(1); j++)
            {
                PresentBoxs[i].transform.GetChild(j + 2).gameObject.GetComponent<SpriteRenderer>().sprite = color[boxnumber[i,j]];
            }

            //面の位置情報を入れ替える
            Partscs.MakeBox_RandomChange(PresentBoxs[i]);

            //箱の回転を変える
            Partscs.MakeBox_Speed(PresentBoxs[i]);        
        }
    }
}
