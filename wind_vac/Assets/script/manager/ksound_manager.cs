using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ksound_manager : MonoBehaviour
{
    public static ksound_manager Instance=null;
    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance==null)
        Instance=this;
    }
    void Start()
    {
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = PlayerPrefs.GetFloat("SfxVoluim")*PlayerPrefs.GetFloat("MasterVoluim");
        audio.loop=false;
        
    }
    public bool get=false;
    // Update is called once per frame
    void Update()
    {
        if(get)
        {
           audio.Play();
           get=false;
        }
    }
}
