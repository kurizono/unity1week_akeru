using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItem : MonoBehaviour
{
    private Sprite[] Items;
    public Sprite Arrow, Return, Cat, Ufo, blue, green, yellow, purple, red, white, eye, boy, girl, nogeneral, credit, catstamp;
    public GameObject DropObj;

    private void Start()
    {
        Items = new Sprite[16]
        {
            Arrow, Return, Cat, Ufo, blue, green, yellow, purple, red, white, eye, boy, girl, nogeneral, credit, catstamp
        };
    }

    public void ItemDrop()
    {
        int i = Random.Range(0, Items.Length);
        GameParameter.item[i] = 1;
        GameObject Obj = (GameObject)Instantiate(DropObj);
        Obj.gameObject.GetComponent<SpriteRenderer>().sprite = Items[i];
    }
}
