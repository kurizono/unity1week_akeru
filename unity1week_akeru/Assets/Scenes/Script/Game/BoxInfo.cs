using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    int[] boxcolor;
    int[,] boxnumber;
    int boxnum;
    int boxpanel;

    // Start is called before the first frame update
    void Start()
    {
        boxnum = 4;
        boxpanel = 4;
        boxcolor = new int[boxnum];
        boxnumber = new int[boxnum, boxpanel];

        BoxInfo_Remake();

    }

    //プレゼントボックスを作り直す
    public void BoxInfo_Remake()
    {
        for (int i = 0; i < boxnum; i++)
        {
            boxcolor[i] = Random.Range(0, 6);
            for (int j = 0; j < boxpanel; j++)
            {
                boxnumber[i, j] = Random.Range(1, 101);
            }
        }
        GetComponent<MakeBox>().PresentBoxMake(boxcolor, boxnumber);
    }
}
