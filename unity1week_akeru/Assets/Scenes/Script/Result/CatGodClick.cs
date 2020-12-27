using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGodClick : MonoBehaviour
{
    public AudioSource　sources;

    // Start is called before the first frame update
    void Start()
    {
        sources = gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        sources.Play();
    }
}
