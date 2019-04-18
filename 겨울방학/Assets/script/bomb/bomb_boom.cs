using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_boom : MonoBehaviour
{

    public int dir = 0;
    public GameObject shadow;
    public GameObject orbit;
    // Use this for initialization
    enum shoot_direction { up = 0, down, left, right };
    public float speed = 0.17f;
    float i_z;
    float a = 0.025f;
    bool isGround = false;
    public float firstnum, plus;
<<<<<<< HEAD
    public GameObject effect,outlineeffect;
=======
    public GameObject effect,effect_shadow;
>>>>>>> 85f03661486dce86e5d5bf3e0fe6423e2ddf3bfe
    float nextfireQ, firerateQ = 0.01f;
    GameObject inst;
    float Y, X;
    Vector3 moveboom;
    public GameObject pa;
    public bool kill;
    void Start()
    {
        a = firstnum;
        inst = Instantiate(shadow);
        inst.transform.position = transform.position + new Vector3(0, -0.35f, 0);
        Y = transform.position.y - 0.75f;
        X = transform.position.x;
        if (dir == (int)shoot_direction.left)
            moveboom = new Vector3(speed, 0, 0);
        if (dir == (int)shoot_direction.right)
            moveboom = new Vector3(-speed, 0, 0);
        if (dir == (int)shoot_direction.up)
            moveboom = new Vector3(0, speed, 0);
        if (dir == (int)shoot_direction.down)
            moveboom = new Vector3(0, -speed, 0);
        Instantiate(pa).transform.position = transform.position;
       
       
    }
    bool Is_hit()
    {
        BoxCollider2D box_collider = transform.GetComponent<BoxCollider2D>();//컴포넌트를 얻어옴
        box_collider.enabled = false;//자신 충돌 체크 꺼줌
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position + new Vector3(box_collider.offset.x, box_collider.offset.y),
         new Vector2(box_collider.size.x * transform.localScale.x, box_collider.size.y * transform.localScale.y), 0,1<<8);//충돌  정보를 얻어옴
        if (hit != null)
        {
            foreach (Collider2D i in hit)
            {
                if(i.tag=="monster")
                kill=true;
            }         
        }
        box_collider.enabled = true;//다시 자신의 충돌 체크를 켜줌			
        return (hit != null);//부딫혔을때 true반환 아닐경우에는 false 반환
    }
    void Die()
    {
        
            GameObject temp = Instantiate(effect);
<<<<<<< HEAD
            GameObject temp_sh = Instantiate(outlineeffect);
=======
            GameObject temp_sh = Instantiate(effect_shadow);
>>>>>>> 85f03661486dce86e5d5bf3e0fe6423e2ddf3bfe
            temp.transform.position = transform.position + new Vector3(0, 0, -0.1f);
            temp_sh.transform.position = transform.position + new Vector3(0, 0, -0.05f);
            temp_sh.transform.rotation = temp.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            temp_sh.transform.localScale += new Vector3(0.2f, 0.2f, 0);
            temp_sh.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            Destroy(inst);
            Destroy(gameObject);
    }
    void CoolTime()
    {
          GameObject tempOb = Instantiate(orbit);
            GameObject tempObshadow = Instantiate(orbit);

            tempOb.transform.position = transform.position + new Vector3(Random.Range(-0.07f, 0.07f), Random.Range(-0.07f, 0.07f));//랜덤하게 연기 퍼짐

            float radonscle = Random.Range(-0.11f, 0.11f);
            tempOb.transform.localScale += new Vector3(radonscle, radonscle);
            
            tempObshadow.transform.position = tempOb.transform.position + new Vector3(0, 0, 0.1f);
            tempObshadow.transform.localScale = tempOb.transform.localScale + new Vector3(0.17f, 0.17f, 0);
            tempObshadow.gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.2f, 0.2f);
            nextfireQ = Time.time + firerateQ;
    }
    // Update is called once per frame
    void Update()
    {   
        Is_hit();
        if (Time.time > nextfireQ)
        {
          CoolTime();
        }
        transform.position += moveboom;
        if (speed >= 0)
            speed -= 0.0025f;
        if (speed < 0)
            speed = 0;
        a -= plus;
        i_z += a;
        if (dir == (int)shoot_direction.right || dir == (int)shoot_direction.left)
        {
            if (i_z <= -0.4f && isGround == false)
            {
                a = firstnum / 1.2f;
                i_z = 0f;
                isGround = true;
            }
            if (i_z > -0.2f || isGround == false)
            {
                transform.position += new Vector3(0, i_z, 0);
                inst.transform.localScale -= new Vector3(i_z / 4, i_z / 4);
            }
            inst.transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }
        if (dir == (int)shoot_direction.up || dir == (int)shoot_direction.down)
        {
            if (i_z <= -0.4f && isGround == false)
            {
                a = firstnum / 1.2f;
                i_z = 0f;
                isGround = true;
            }
            if (i_z > -0.2f || isGround == false)
            {
                transform.localScale += new Vector3(i_z / 4, i_z / 4, 0);
            }
            inst.transform.position = new Vector3(X, transform.position.y - 0.45f + (-i_z * 2), transform.position.z);
        }
        transform.localScale += new Vector3(0.005f, 0.005f, 0);
        if (dir != (int)shoot_direction.left)
            transform.Rotate(Vector3.forward * Time.deltaTime * 5000 * speed);
        else
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 5000 * speed);
        }

        if (speed <= 0||kill==true)
        {
            Die();
        }
    }
}
