using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_parents : GameMaker
{

    public move_player player;
    public float speed = 1.5f;
    public float gur;
    float angle;
    float orignsize;
    float dumy_x;
    [HideInInspector]
    public float radi;
    //[HideInInspector]
    public float hp = 3;
    private Vector3 knockback;
    public float nockback_length = 0.5f;
    public float hitcolor = 0;
    public LinkedList<child_manager> childs;
    public bool is_player;
    public new AudioSource audio;

    public float volume;
    public int giveMoney = 5;
    public GameObject coin;


    // Use this for initialization
    public void Start()
    {
         transform.position-=new Vector3(0,0, transform.position.y/100);
        orignsize = transform.localScale.x;
        dumy_x = transform.localScale.x;
        player = monster_manager.Instance.player;
        monster_manager.Instance.monsterList.AddLast(this);
        childs = new LinkedList<child_manager>();

        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = monster_manager.Instance.hitMonster;
        audio.volume = PlayerPrefs.GetFloat("SfxVoluim") * PlayerPrefs.GetFloat("MasterVoluim"); ;
        coin = monster_manager.Instance.coin;
    }
    public float alredyhit;
    bool Is_hit()
    {
        player_stats player = monster_manager.Instance.player.GetComponent<player_stats>();
        
        BoxCollider2D box_collider = transform.GetComponent<BoxCollider2D>();//컴포넌트를 얻어옴
        box_collider.enabled = false;//자신 충돌 체크 꺼줌
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position + new Vector3(box_collider.offset.x, box_collider.offset.y),
         new Vector2(box_collider.size.x * transform.localScale.x, box_collider.size.y * transform.localScale.y), 0, 1 << 8);//충돌  정보를 얻어옴
        if (hit != null)
        {
            foreach (Collider2D i in hit)
            {

                if (i.gameObject.tag == "monster")
                {
                    Doknockback(transform.position, i.transform.position);
                    //this.audio.clip = this.fireSound;
                }
                if (i.gameObject.tag == "attack")
                {
                    if (alredyhit!=i.GetComponent<boom_effect>().hitcode)
                    {
                        alredyhit=i.GetComponent<boom_effect>().hitcode;
                        hp -= 1f + player.attack;
                        Doknockback( transform.position,i.transform.position,5f);
                        hitcolor = 20;
                        audio.Play();

                        Instantiate(monster_manager.Instance.hit_effect, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), Quaternion.identity);

                        EffectFont text = Instantiate(monster_manager.Instance.EffectText, transform.position, Quaternion.identity).GetComponent<EffectFont>();
                        text.fwspeed = Random.Range(-0.05f, 0.05f);

                        if (hp == 0)
                            text.effectText = "처치!";
                        else
                            text.effectText = "" + (player.attack + 1) * 10;
                        Camera.main.GetComponent<ShakeManager>().Shake(0f, 0f, 0, 0.9f, 10);
                    }
                }
            }
        }
        box_collider.enabled = true;//다시 자신의 충돌 체크를 켜줌			
        return (hit != null);//부딫혔을때 true반환 아닐경우에는 false 반환
    }
    void to_player()
    {
        radi = Vector2.Distance((Vector2)transform.position, (Vector2)player.transform.position);
        angle = PointDirection((Vector2)transform.position, (Vector2)player.transform.position);
        if (radi > gur)
        {
            is_player = true;
        }
        else
        {
            is_player = false;
        }
        if (transform.position.x <= player.transform.position.x + 0.1f)
            dumy_x = -orignsize;
        else
        {
            dumy_x = orignsize;
        }
        transform.localScale = new Vector3(dumy_x, transform.localScale.y, transform.localScale.z);
        if (is_player)
        {
            transform.Translate(VectorRotation(angle) * speed * Time.deltaTime);
        }
    }
    public void Doknockback(Vector3 po1, Vector3 po2)
    {
        knockback = -VectorRotation(PointDirection(po1, po2)) * nockback_length * 0.1f;
    }
    public void Doknockback(Vector3 po1, Vector3 po2, float length = 0.1f)
    {
        knockback = -VectorRotation(PointDirection(po1, po2)) * nockback_length * 0.1f * length;
    }
    virtual public void Kill()
    {
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 0, 0.9f, 10);
        monster_manager.Instance.monsterList.Remove(this);
        monster_manager.Instance.isDead = true;
        monster_manager.Instance.combo++;
        for (int i = 0; i < giveMoney; i++)
        {
            GameObject inst = Instantiate(coin);
            inst.transform.position = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-1.5f, 1.5f));
        }
        Destroy(gameObject);
    }
    public void Update()
    {
        if (player != null)
        {
            to_player();
            Is_hit();
            knockback -= knockback / 10;
            transform.position += knockback;
            hitcolor -= hitcolor / 4;
            foreach (var item in childs)
            {
                //item.GetComponentInChildren<Renderer>().material.color = new Color(1 + (hitcolor * 2), 1 + (hitcolor * 2), 1 + (hitcolor *2));
                item.GetComponentInChildren<Renderer>().material.color = new Color(1 + (hitcolor * 2), 1 - (hitcolor * 0.5f), 1 - (hitcolor * 0.5f));
            }
        }
        if (hp <= 0 || monster_manager.Instance.isClear)
            Kill();
    }

}
// Update is called once per frame
