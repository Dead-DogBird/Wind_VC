using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_monster : monster_parents
{
    Animator animator;
	public GameObject bullet;
	public float nextfireQ, firerateQ = 0.8f;
	public float random=0;
    // Start is called before the first frame update
	new void Start () {
		base.Start();
        animator = GetComponent<Animator>();
	}
	void fire()
	{
		nextfireQ = Time.time + firerateQ;
		GameObject inst= Instantiate(bullet);
		inst.transform.position=transform.position;
		inst.GetComponent<bullet>().toVector=VectorRotation(PointDirection(transform.position,player.transform.position)+Random.Range(-random,random));
	}
	// Update is called once per frame
	new void Update () {
		base.Update();
        animator.SetBool("isRun",is_player);
		if(Time.time > nextfireQ&&player!=null)
		{
			fire();
		}
	}
}
