using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionController : MonoBehaviour
{
    public GameObject ItemsObj;
    public GameObject[] Item;

    public Text[] CatText = new Text[2];
    public Text NumberText;
    string[] NoItem = new string[2]
    {
        "まだぷれぜんとしてないにゃ",
        "はこをあけてげっとするにゃ"
    };
    string[] Cat1Talk = new string[16]
    {
        "どこにでもあるやじるしにゃ！",
        "もどるためのやじるしにゃ！",
        "にゃあたちににているねこにゃ！",
        "のりもののかたちのてんしにゃ！",
        "あおくぬられたただのかみにゃ！",
        "まるがかかれたみどりいろにゃ！",
        "せんとまるのきいろにゃ！",
        "まんなかすうじのむらさきにゃ！",
        "あかにあかがのっているあかにゃ！",
        "しろとあかのくみあわせにゃ！",
        "つぶらできれいなひとみにゃ！",
        "あおいろだからおとこにゃ！",
        "あかいろだからおんなにゃ！",
        "くろいろだからむせいべつにゃ！",
        "かみさまのなまえにゃ！",
        "しんせいなるねこすたんぷにゃ！"
    };
    string[] Cat2Talk = new string[16]
    {
        "かずがおおすぎてみあきたにゃ？",
        "もちろんかこにももどれるにゃ？",
        "ねこをてがるにかえるじだいにゃ？",
        "てんしのわがひかりかがやいてるにゃ？",
        "なんのこせいもついてないにゃ？",
        "まるになにをかけてもまるにゃ？",
        "きごうのじゅんばんにいみはあるかにゃ？",
        "どっちつかずのはんぱものにゃ？",
        "ゆーざびりてぃはだめだめにゃ？",
        "みっつもすうじがあるのはよくばりにゃ？",
        "みつめつづければこいにおちるにゃ？",
        "そらとうみはおとこにゃ？",
        "ひーろーはみんなおんなにゃ？",
        "はらぐろはみんなむせいべつにゃ？",
        "かみさまかわったにゃ？",
        "ねこすたんぷはぜったいにゃ！"
    };
    int nownum = 0;
    int allnum;

    // Start is called before the first frame update
    void Start()
    {
        allnum = GameParameter.item.Length;
        
        Item = new GameObject[ItemsObj.transform.childCount];
        for(int i = 0; i < Item.Length; i++)
        {
            Item[i] = ItemsObj.transform.GetChild(i).gameObject;
        }

        First();
        ItemChange();
    }


    private void First()
    {
        for (int i = 0; i < Item.Length; i++)
        {
            Item[i].SetActive(false);
        }
    }

    public void ItemChange()
    {
        First();
        int textin = nownum + 1;
        NumberText.text = "ナンバー" + textin;
        if (GameParameter.item[nownum] == 1)
        {
            Item[nownum].SetActive(true);
            CatText[0].text = Cat1Talk[nownum];
            CatText[1].text = Cat2Talk[nownum];
        }
        else
        {
            CatText[0].text = NoItem[0];
            CatText[1].text = NoItem[1];
        }
    }

    public void LeftArrowClick()
    {
        nownum = (nownum + allnum - 1) % allnum;
        ItemChange();
    }
    public void RightArrowClick()
    {
        nownum = (nownum + 1) % allnum;
        ItemChange();
    }
}
