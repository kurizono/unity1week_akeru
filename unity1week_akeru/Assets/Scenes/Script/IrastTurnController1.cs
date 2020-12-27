using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrastTurnController1 : MonoBehaviour
{
    public float move, time;
    // Start is called before the first frame update
    void Start()
    {
        move = Random.Range(0.1f, 2);
        int dir = Random.Range(0, 2);
        if(dir == 0)
        {
            dir = -1;
        }
        move = move * dir;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, Mathf.Sin((Time.time - time)* move), 0);
    }
}
