using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBox : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;

    //プレハブ
    public GameObject PresentBox;
    private GameObject[] PresentBoxs;
    public GameObject PresentSenter;

    private SpriteRenderer[] PresentSprite;

    //素材
    private Sprite[] RedPatter;
    private Sprite[] BluePatter;
    private Sprite[] GreenPatter;
    private Sprite[] YellowPatter;
    private Sprite[] PurplePatter;
    private Sprite[] WhitePatter;

    private Vector3[] PresentPosi = new Vector3[4] 
    {
        new Vector3(5, 0),
        new Vector3(0, 5),
        new Vector3(-5, 0),
        new Vector3(0, -5),
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

        //4つのプレゼント
        PresentBoxs = new GameObject[4];
        for(int i = 0; i < PresentBoxs.Length; i ++)
        {
            PresentBoxs[i] = PresentBox;
            PresentBoxs[i] = Instantiate(PresentBoxs[i]);
            PresentBoxs[i].name = "PresentBoxs" + i;
            PresentBoxs[i].transform.SetParent(PresentSenter.transform, true);
            PresentBoxs[i].transform.position = PresentPosi[i];
        }


        PresentSprite = new SpriteRenderer[6];
        for (int i = 0; i < 6; i++)
        {
            PresentSprite[i] = PresentBoxs[0].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        }
        PresentSprite[2].sprite = WhitePatter[2];
        PresentSprite[3].sprite = WhitePatter[3];
        PresentSprite[4].sprite = WhitePatter[4];
        PresentSprite[5].sprite = WhitePatter[5];
    }
}
