using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class fire_bomb : MonoBehaviour
{

    int input_code;
    enum shoot_direction { up = 0, down, left, right };
    float nextfireQ, firerateQ = 0.8f;

    public GameObject Bomb;
    public new AudioSource audio;

    public AudioClip fireSound;
    float nock_back = 0.2f;
    public Vector2 a;
    public float volume, pitch;
    move_player player;
    hit_player hplayer;

    GameObject[] BombList = new GameObject[5];
    // Use this for initialization
    void Start()
    {
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = volume;
        audio.pitch = pitch;
        player = GetComponent<move_player>();
        hplayer = GetComponent<hit_player>();
        for (int i = 0; i < 5; i++)
        {
            BombList[i] = Instantiate(Bomb);
            BombList[i].GetComponent<bomb_boom>().samyDie();
        }
    }
    void nockback(shoot_direction dir)
    {
        if (dir == shoot_direction.left)
        {
            a = new Vector2(-nock_back, 0);

        }
        if (dir == shoot_direction.right)
        {
            a = new Vector2(nock_back, 0);
        }
        if (dir == shoot_direction.up)
        {
            a = new Vector2(0, -nock_back);
        }
        if (dir == shoot_direction.down)
        {
            a = new Vector2(0, nock_back);
        }
    }
    public GameObject returnActiveObject(int dir)//현재 비활성화된 오브젝트 반환
    {
        int i = 0;
        while (true)
        {
            if (BombList[i].GetComponent<bomb_boom>().Uactive == false)
            {
                //BombList[i].SetActive(true);
                BombList[i].GetComponent<bomb_boom>().reActive(dir, transform.position);
                return BombList[i];
            }
            i++;
            if (i >= 5)
                return null;
        }
    }
    public void fire(int dir = 0)
    {
        if (Time.time > nextfireQ)
        {
            input_code = dir;
            nextfireQ = Time.time + (firerateQ - GetComponent<player_stats>().rapidfire);
            audio.Play();
            //this.audio.clip = this.fireSound;
            /*bomb_boom tempbomb = */

            returnActiveObject(dir).GetComponent<bomb_boom>();
            // tempbomb.transform.position = transform.position;
            //bomb_boom bomb_sh=Instantiate(Bomb).GetComponent<bomb_boom>();
            // tempbomb.dir = dir;
            //bomb_sh.dir=tempbomb.dir;
            //bomb_sh.transform.localScale+=new Vector3(0.75f,0.75f,0);
            //bomb_sh.gameObject.GetComponent<Renderer>().material.color=new Color(0,0,0); 
            nockback((shoot_direction)dir);
        }

    }
    public int Dir;
    public bool isActive;
    // Update is called once per frame
    void Update()
    {
        //if(a.x!=0||a.y!=0)
        a -= a / 10;

        transform.position += (Vector3)a;
        if (isActive)
        {
            if (player.isJump == false && hplayer.falling == false)
            {
                fire(Dir);
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    fire((int)shoot_direction.up);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    fire((int)shoot_direction.down);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    fire((int)shoot_direction.right);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    fire((int)shoot_direction.left);
                }
            }
        }
    }
}
