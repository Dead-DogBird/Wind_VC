using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_player : GameMaker
{
    public Vector3 knockback;
    public int hp = 10;
    public Hit_Red hit_Red;
    public float hitcolor = 0;
    public float hit_time;
    public bool falling;
    public new AudioSource audio;
    public float volume=0.7f;
    public AudioClip fireSound,ouchSound;

    void hit()
    {

        BoxCollider2D box_collider = transform.GetComponent<BoxCollider2D>();//컴포넌트를 얻어옴
        box_collider.enabled = false;//자신 충돌 체크 꺼줌
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position + new Vector3(box_collider.offset.x, box_collider.offset.y),
         new Vector2(box_collider.size.x * transform.localScale.x, box_collider.size.y * transform.localScale.y), 0, 1 << 8);//충돌  정보를 얻어옴
        if (hit != null)
        {
            foreach (Collider2D i in hit)
            {
                 if (i.CompareTag("fall")&&falling!=true)
                    {
                        audio.clip=fireSound;
                        audio.Play();
                        StartCoroutine("FallSmall");
                        StartCoroutine("HitOn");
                    }
                if (GetComponent<move_player>().isJump != true && hit_time == 0)
                {
                    if (i.CompareTag("monster"))
                    {
                        Doknockback(transform.position, i.transform.position, 0.2f);
                        i.transform.GetComponent<monster_parents>().Doknockback(i.transform.position, transform.position, 7.5f);
                        hp -= 1;
                        monster_manager.Instance.isHit = true;
                        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 6f, 0.9f, 10);
                         audio.clip=ouchSound;
                    }
                    if (i.CompareTag("bullet"))
                    {
                        Doknockback(transform.position, i.transform.position, 0.2f);
                        hp -= 1;
                        Destroy(i.gameObject);
                        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 6f, 0.9f, 10);
                         audio.clip=ouchSound;
                    }

                    hitcolor = 10;
                    
                    hit_Red.hitcolor = 1;
                    hit_time = 1;
                   
                    audio.Play();
                    StartCoroutine("HitOn");

                }
            }
        }
        box_collider.enabled = true;//다시 자신의 충돌 체크를 켜줌		
    }
    public void Doknockback(Vector3 po1, Vector3 po2, float length = 0.1f)
    {
        knockback = -VectorRotation(PointDirection(po1, po2)) * length;
    }
    void Start()
    {
        audio=gameObject.AddComponent<AudioSource>();
        audio.clip=fireSound;
        audio.volume = volume;
    }
    void die()
    {
        Camera.main.GetComponent<ShakeManager>().Shake(3f, 3f, 10f, 1.2f, 10);
        if(Game_manager.Instance.NowWhatMode==Game_manager.gameMode.endlessMode&&monster_manager.Instance.wave>Game_manager.Instance.highScore)
        PlayerPrefs.SetInt("endLessHigh",monster_manager.Instance.wave);
        Destroy(gameObject);
    }
    IEnumerator FallSmall()
    {
        for(int i=0;i<75;i++)
        {
            falling=true;
            transform.localScale += (new Vector3(0,0,0) - transform.localScale) / 5;
             transform.Rotate(Vector3.forward * Time.deltaTime * 750);
            yield return new WaitForSeconds(0.01f);
        }
        transform.localRotation=Quaternion.Euler(0, 0,0);
        transform.localScale = new Vector3(0.6f, 0.6f);
        transform.position = new Vector3(0, 0);
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 6f, 0.9f, 10);
        hp -= 1;
        falling=false;
        yield return null;
    }
    IEnumerator HitOn()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0&&countTime>4)
            {
                foreach (var item in GetComponent<player_sprite>().Childs)
                {
                    item.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.35f);
                }
            }
            else
            {
                foreach (var item in GetComponent<player_sprite>().Childs)
                {
                    item.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
                }
            }
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        foreach (var item in GetComponent<player_sprite>().Childs)
        {
            item.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        hit_time=0;
        yield return null;
    }
    void FixedUpdate()
    {
        // num++;
        // if (hit_time != 0)
        // {
        //     if (num % 2 == 0)
        //         hit_time = 1f;
        //     else
        //     {
        //         hit_time = 0.2f;
        //     }
        //     if (Time.time > nextfireQ)
        //         hit_time = 0;
        // }

        hit();
        hitcolor -= hitcolor / 4;

        transform.position += knockback;
        knockback -= knockback / 10;
        if (hp <= 0)
            die();
    }
}