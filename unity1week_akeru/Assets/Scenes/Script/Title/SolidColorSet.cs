using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidColorSet : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<ColorSetting>().Obj_Click(gameObject);
    }
}
