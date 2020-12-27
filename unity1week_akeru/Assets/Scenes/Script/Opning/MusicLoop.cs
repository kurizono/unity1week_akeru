using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioClip music, cat;
    public AudioSource[] audioSources;
    
    float musictime = 0;
    float[] musicloop = new float[2]
    {
        8.858f , 63.714f
    };

    int catmyau = 0;

    private void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        audioSources[0].clip = music;
        audioSources[1].clip = cat;
    }

    // Update is called once per frame
    void Update()
    {
        musictime += Time.deltaTime;
        if(musictime > musicloop[1])
        {
            musictime -= (musicloop[1] - musicloop[0]);
            audioSources[0].time = musictime;
            audioSources[0].Play();
            catmyau = 0;
        }
        if(musictime > musicloop[1] - 0.3 && catmyau == 0)
        {
            audioSources[1].Play();
            catmyau = 1;
        }
    }
}
