using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrastTurnController1 : MonoBehaviour
{
    float move, time;
    // Start is called before the first frame update
    void Start()
    {
        move = 1;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, Mathf.Sin((Time.time - time)* move), 0);
    }
}
