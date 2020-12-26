using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidColorSet : MonoBehaviour
{
    private GameObject Colorset;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<ColorSetting>().Obj_Click(gameObject);
    }
}
