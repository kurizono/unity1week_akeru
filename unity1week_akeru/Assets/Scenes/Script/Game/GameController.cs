using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


//箱がだんだん薄くなる
//正解するごとに値を1増やす
//正解不正解判定
public class GameController : MonoBehaviour
{
    BoxInfo BoxInfocs;
    MakeBox MakeBoxcs;
    MakeItem MakeItemcs;

    float dark;
    float time;
    //最初の制限時間
    float maxtime = 10;

    // Start is called before the first frame update
    void Start()
    {
        BoxInfocs = GetComponent<BoxInfo>();
        MakeBoxcs = GetComponent<MakeBox>();
        MakeItemcs = GetComponent<MakeItem>();

        GameParameter.question_num = 0;
    }

    public void First()
    {
        dark = 1;
        time = 0;
    }

    //全ての箱がだんだん薄くなる
    private void Update()
    {
        time += Time.deltaTime;
        dark = (1 - time / maxtime);
        if (dark < 0)
        {
            GameOver();
        }
        else
        {
            for (int i = 0; i < MakeBoxcs.PresentBoxs.Length; i++)
            {
                MakeBoxcs.PresentBoxs[i].gameObject.GetComponent<BoxContoller>().BoxDelete(dark);
            }
        }
    }


    //正解不正解判定(1で正解)
    public int AnsCheck(GameObject gameObject)
    {
        int[] num = BoxInfocs.BoxInfo_Cul();
        int maxnum = num.Max();

        int ans = 0;
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] == maxnum && MakeBoxcs.PresentBoxs[i] == gameObject)
            {
                ans = 1;
                GameParameter.question_num += 1;
                MakeItemcs.ItemDrop();
                First();
            }
        }
        if(ans == 0)
        {
            GameOver();
        }
        return ans;
    }

    //ゲームオーバー時の判定
    public void GameOver()
    {
        SceneManager.LoadScene("Result");
    }
}
