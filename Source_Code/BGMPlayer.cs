using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{

    public AudioClip[] BGM;
    public AudioSource audio;
    [HideInInspector]
    public string name;

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = nextSong();
            name = audio.clip.ToString();
            name = name.Substring(0, name.Length - 24); //cuts off additional .unity(gameObject) text
            audio.Play();
        }
    }

    private AudioClip nextSong()
    {
        return BGM[Random.Range(0, BGM.Length)];
    }
}
