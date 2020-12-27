using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Text Resultnum, CatComent;

    // Start is called before the first frame update
    void Start()
    {
        Resultnum.text = "アケタプレゼント　"  + GameParameter.question_num.ToString();
        if(GameParameter.question_num == 0)
        {
            CatComent.text = "ひとはおろかにゃ" + "\r\n" + "しんりゃくされろにゃ";
        }
        else if(GameParameter.question_num < 5)
        {
            CatComent.text = "ねこのほうがかわいいにゃ" + "\r\n" + "ねこになれにゃ";
        }
        else if(GameParameter.question_num < 10)
        {
            CatComent.text = "にくきゅういいにゃ" + "\r\n" + "ぷにれにゃ";
        }
        else if(GameParameter.question_num < 15)
        {
            CatComent.text = "もしかしてこどもにゃ？" + "\r\n" + "すこしかしこいにゃ";
        }
        else if(GameParameter.question_num < 20)
        {
            CatComent.text = "けいさんきみたいにゃ" + "\r\n" + "にゃあにつかわれろにゃ";
        }
        else
        {
            CatComent.text = "かみさまのけはいにゃ" + "\r\n" + "てんちそうぞうしろにゃ";
        }
    }
}
