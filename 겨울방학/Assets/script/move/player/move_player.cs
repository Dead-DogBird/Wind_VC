using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    public float speed=0.1f;
    float hspeed,vspeed;
    float ori_x,ori_y;
    // Use this for initialization
    void Start()
    {
        ori_x=transform.localScale.x;
        ori_y=transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
      
        float h =Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");
        Vector2 speedNomal = (new Vector2(h, v));
        if(Input.GetKey(KeyCode.LeftArrow)&&ori_x==transform.localScale.x)
        {
            transform.localScale=new Vector3(-ori_x,ori_y);
        }
        if(Input.GetKey(KeyCode.RightArrow)&&ori_x!=transform.localScale.x)
        {
            transform.localScale=new Vector3(ori_x,ori_y);
        }
        if (speedNomal.magnitude > 1)
            speedNomal = speedNomal.normalized;

        transform.Translate(speedNomal * (speed));

    }
}
