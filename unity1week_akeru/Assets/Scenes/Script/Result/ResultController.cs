using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Text Resultnum;

    // Start is called before the first frame update
    void Start()
    {
        Resultnum.text = GameParameter.question_num.ToString();
    }
}
