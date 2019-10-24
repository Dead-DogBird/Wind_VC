using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_boss : monster_parents
{
    Animator animator;
    public bool isAttack, isfire, idle;
    public GameObject bullet;
    public float nextfireQ, firerateQ = 5f;
    public float nextFireTime, coolTime = 4;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        nextFireTime = Time.time + coolTime;
        nextfireQ = Time.time + firerateQ;
        animator = GetComponent<Animator>();
    }
    IEnumerator fire()
    {
        isfire = true;
        nextFireTime = Time.time + coolTime;
        animator.Play("3boss_Fire");
        for (int i = 0; i < 18; i++)
        {
            GameObject inst = Instantiate(bullet);
            inst.transform.position = transform.position;
            inst.GetComponent<bullet>().toVector = VectorRotation(PointDirection(transform.position, player.transform.position) + (-20 + 20 * i));
            inst.GetComponent<bullet>().speed = 10;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    void Attack()
    {
        nextfireQ = Time.time + firerateQ;
        animator.Play("3Boss_Attack");
    }
    // Update is called once per frame
    new void Update()
    {
        if (player != null)
        {
            if (nextFireTime < Time.time)
                StartCoroutine(fire());
            if (nextfireQ < Time.time)
                Attack();

            idle = true;

            base.Update();
        }
    }
}
