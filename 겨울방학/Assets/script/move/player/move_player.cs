using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : GameMaker
{
    public float speed = 0.1f;
    float hspeed, vspeed;
    float ori_x, ori_y;
    float nextfireQ, firerateQ = 0.8f;
    float nextjump, latejump = 0.2f;
    Vector3 jump;
    int x, y;

    public bool isJump;
    // Use this for initialization
    void Start()
    {
        ori_x = transform.localScale.x;
        ori_y = transform.localScale.y;
        nextjump = Time.time + latejump;
    }
    void Jump(Vector3 toVector)
    {
        jump = new Vector2(x, y);
        nextfireQ = Time.time + firerateQ;
        //Camera.main.GetComponent<ShakeManager>().Shake(0, 0, 0, 0.9f, 10);
        isJump = true;
        nextjump = Time.time + latejump;
        GetComponent<fire_bomb>().a=new Vector2(0,0);
    }
    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 speedNomal = (new Vector2(h, v));

        if (Input.GetKey(KeyCode.A))
            x = -1;
        if (Input.GetKey(KeyCode.D))
            x = 1;
        if (Input.GetKey(KeyCode.S))
            y = -1;
        if (Input.GetKey(KeyCode.W))
            y = 1;

        if (GetComponent<hit_player>().falling == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && ori_x == transform.localScale.x)
            {
                transform.localScale = new Vector3(-ori_x, ori_y);
            }
            if (Input.GetKey(KeyCode.RightArrow) && ori_x != transform.localScale.x)
            {
                transform.localScale = new Vector3(ori_x, ori_y);
            }
        }
        if (speedNomal.magnitude > 1)
            speedNomal = speedNomal.normalized;


        if (Input.GetKey(KeyCode.Space) && Time.time > nextfireQ)
            Jump(speedNomal);

        transform.Translate(speedNomal * (speed));

        transform.Translate(jump * speed * 2.5f);
        if (nextjump < Time.time)
            jump = new Vector2(0, 0);


        if (Mathf.Abs(jump.x) + Mathf.Abs(jump.y) <= 0.05f)
            isJump = false;
        //if(Time.time>nextjump)
        //{
        //    jump=new Vector3(0,0,0);
        //    nextjump=Time.time+latejump;
        //}
        x = y = 0;
    }
}
