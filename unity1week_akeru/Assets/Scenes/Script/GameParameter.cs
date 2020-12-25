using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameParameter : MonoBehaviour
{
    //使う色のオンオフ, 数字入り面の数
    public static int[] color_switch = new int[6];
    public static int[] color_num = new int[2] {4, 4};
    private void Start()
    {
        SceneManager.LoadScene("Title");
    }
}
