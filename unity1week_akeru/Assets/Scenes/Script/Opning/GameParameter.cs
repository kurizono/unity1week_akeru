using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameParameter : MonoBehaviour
{
    //使う色のオンオフ, 数字入り面の数
    //blue, green, yellow, purple, red, white
    public static int[] color_switch = new int[6];

    public static int[] color_num = new int[4];

    //アイテム
    public static int[] item = new int[14];

    //正解数
    public static int question_num = 0;
    
    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Title");
    }
}
