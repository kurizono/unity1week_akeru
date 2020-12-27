using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSolidSet : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<NumberSetting>().Obj_Click(gameObject);
    }
}
