using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom_effect : MonoBehaviour
{
    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume = 0.5f, pitch = 1;
    public float hitcode;
    // Use this for initialization
    void Start()
    {
        if (monster_manager.Instance.player != null)
        {
            player_stats player = monster_manager.Instance.player.GetComponent<player_stats>();
            transform.localScale += new Vector3(player.extent, player.extent);
        }
        hitcode = Time.time;
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = PlayerPrefs.GetFloat("SfxVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        audio.pitch = pitch;
        audio.Play();

    }
    public bool isbig = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isbig)
            transform.localScale += new Vector3(0.075f, 0.075f, 0);

        Destroy(gameObject, 0.9f);
    }
}
