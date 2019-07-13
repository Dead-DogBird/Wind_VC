using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_boss : monster_parents
{
    Animator animator;
    float nextfireQ, firerateQ = 4f;
    public float FnextfireQ, FfirerateQ = 15f;
    public GameObject bullet;
    public float random = 0, Bulletspeed = 4;
    float mNext, mLate = 0.5f;
    public int ChargeCount = 10;
    bool isShoot;
    new void Start()
    {
        base.Start();
        nextfireQ = Time.time + firerateQ;
        animator = GetComponent<Animator>();
    }
    void fire()
    {
        FnextfireQ = Time.time + FfirerateQ + Random.Range(-1.0f, 1.0f);
        isShoot=true;
        for (int i = 0; i < 3; i++)
        {
            GameObject inst = Instantiate(bullet);
            inst.transform.position = transform.position;
            inst.GetComponent<bullet>().toVector = VectorRotation(PointDirection(transform.position, player.transform.position)+(-20+20*i));
            inst.GetComponent<bullet>().speed = Bulletspeed;
        }
    }
    // Update is called once per frame
    new void Update()
    {
        base.Update();

        
        if (player != null)
        {
            
		animator.SetBool("isShoot",isShoot);   
		if(!isShoot)
		animator.SetBool("isRun",is_player);     

		isShoot=false;
            if (ChargeCount != 0 && mNext < Time.time)
            {
                Doknockback(player.transform.position, transform.position, 14);
                nockback_length = 0;
                ChargeCount--;
                mNext = Time.time + mLate;
            }
            else
            {
                nockback_length = 0.5f;
            }
            if (nextfireQ < Time.time)
            {
                ChargeCount = 3;
                nextfireQ = Time.time + firerateQ + Random.Range(-1.0f, 1.0f);
            }
            if (Time.time > FnextfireQ)
            {
                fire();
            }
        }
    }
}
