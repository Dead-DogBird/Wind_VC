using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_manager : MonoBehaviour
{



    public new AudioSource audio;

    public AudioClip fireSound;
    public AudioClip hitMonster;
    public float volume;
    public bool isHit;
    public float firebombCount, hitbombCount;
    public GameObject EffectText;
    public static monster_manager Instance=null;
    public LinkedList<monster_parents> monsterList;
    public GameObject monster_1;
    public GameObject[] Monster = new GameObject[3];
    public float nextfireQ, firerateQ = 15f;
    public move_player player;
    public bool isDead;
    public int combo;
    public int wave;

    public GameObject hit_effect;
    void OnEnable()
    {
        player = GameObject.Find("player").GetComponent<move_player>();

    }
    public void pressButton(int dir)
    {
        player.GetComponent<fire_bomb>().isActive=true;
        player.GetComponent<fire_bomb>().Dir=dir;
    }
    public void unpressButtom()
    {
         player.GetComponent<fire_bomb>().isActive=false;
    }
    public void Jump()
    {
        player.canJump=true;
    }
    public void disJump()
    {
        player.canJump=false;
    }
    void Awake()
    {
        if(Instance==null)
        Instance=this;
    }
    // Use this for initialization
    void Start()
    {
        monsterList = new LinkedList<monster_parents>();
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;
        nextfireQ = Time.time + 10;
        wave = 0;
      


    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Time.time > nextfireQ)
            {
                wave++;
                Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 6f, 1.5f, 10);
                for (int i = 0; i < 5; i++)
                {
                    GameObject temp = Instantiate(Monster[Random.Range(0, 3)]);
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
