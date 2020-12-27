using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collection_Button : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Collection");
    }
}
