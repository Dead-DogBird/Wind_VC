using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    private static Game_manager _instance;
    // Start is called before the first frame update  private static ksound_manager _instance;
    public static Game_manager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (Game_manager)GameObject.FindObjectOfType(typeof(Game_manager));
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "MyClassContainer";
                    _instance = container.AddComponent(typeof(Game_manager)) as Game_manager;
                }
            }

            return _instance;
        }
    }
    public new AudioSource audio;

    public AudioClip audioClip;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.audioClip;
        audio.volume = volume;
        audio.loop=true;
        audio.Play();
    }
    public bool get=false;
    // Update is called once per frame
    void Update()
    {
   
           
          
    }
}
