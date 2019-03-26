using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_manager : MonoBehaviour
{



    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume;
    //프로퍼티(속성)를 이용해서 좀 더 개선할 수 있다. 접근자 방식. 
    private static monster_manager _instance;
    public static monster_manager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (monster_manager)GameObject.FindObjectOfType(typeof(monster_manager));
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "MyClassContainer";
                    _instance = container.AddComponent(typeof(monster_manager)) as monster_manager;
                }
            }

            return _instance;
        }
    }
    public LinkedList<monster_parents> monsterList;
    public GameObject monster_1;
    float nextfireQ, firerateQ = 30f;
    move_player player;
    public bool isDead;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player").GetComponent<move_player>();
        monsterList = new LinkedList<monster_parents>();
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextfireQ && player != null)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp = Instantiate(monster_1);
                temp.transform.position = new Vector3(player.transform.position.x + Random.Range(-10.0f, 10.0f), player.transform.position.y + Random.Range(-10.0f, 10.0f));
            }
            nextfireQ = Time.time + firerateQ;
        }
        if(isDead)
        {
            audio.Play();
            isDead=false;
        }
    }
}
