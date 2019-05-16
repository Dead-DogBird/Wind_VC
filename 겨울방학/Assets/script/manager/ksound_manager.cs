using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ksound_manager : MonoBehaviour
{
    private static ksound_manager _instance;
    public static ksound_manager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (ksound_manager)GameObject.FindObjectOfType(typeof(ksound_manager));
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "MyClassContainer";
                    _instance = container.AddComponent(typeof(ksound_manager)) as ksound_manager;
                }
            }

            return _instance;
        }
    }
    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;
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
