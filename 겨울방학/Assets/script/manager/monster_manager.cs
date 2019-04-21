using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_manager : MonoBehaviour
{



    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume;
    public bool isHit;
    public float firebombCount,hitbombCount;
    public GameObject EffectText;
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
    public move_player player;
    public bool isDead;
    public int combo;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player").GetComponent<move_player>();
        monsterList = new LinkedList<monster_parents>();
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;
        nextfireQ = Time.time + 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Time.time > nextfireQ)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject temp = Instantiate(monster_1);
                    temp.transform.position = new Vector3(player.transform.position.x + Random.Range(-10.0f, 10.0f), player.transform.position.y + Random.Range(-10.0f, 10.0f));
                }
                nextfireQ = Time.time + firerateQ;
            }
            if (isHit)
            {
                // if (monsterList.Count != 0)
                // {
                //     foreach (var item in monsterList)
                //     {
                //         item.Doknockback(item.transform.position, player.transform.position, 7.5f);
                //     }
                // }
                isHit = false;
            }
        }
        if (isDead)
        {
            audio.Play();
            isDead = false;
        }
    }
}
