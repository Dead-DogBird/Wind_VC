using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
public class Shop_price
{
    public int level, price;
    public Shop_price(int Level, int Price)
    {
        level = Level;
        price = Price;
    }

}
public class monster_manager : MonoBehaviour
{


    public LinkedList<Shop_price> Shop_Price_List=new LinkedList<Shop_price>();
    public new AudioSource audio;

    public AudioClip fireSound;
    public float volume;
    public bool isHit;
    public float firebombCount, hitbombCount;
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
    public GameObject[] Monster = new GameObject[3];
    public float nextfireQ, firerateQ = 15f;
    public move_player player;
    public bool isDead;
    public int combo;
    public int wave;

    public GameObject hit_effect;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player").GetComponent<move_player>();
        monsterList = new LinkedList<monster_parents>();
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;
        nextfireQ = Time.time + 5;
        wave = 0;
        Shop_Price_List.AddLast(new Shop_price(0,650));
        Shop_Price_List.AddLast(new Shop_price(1,650));
        Shop_Price_List.AddLast(new Shop_price(2,650));
        Shop_Price_List.AddLast(new Shop_price(3,650));
        Shop_Price_List.AddLast(new Shop_price(4,650));
        Shop_Price_List.AddLast(new Shop_price(5,650));


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
