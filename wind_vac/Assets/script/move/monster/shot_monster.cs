using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_monster : monster_parents
{
    Animator animator;
	public GameObject bullet;
	public float nextfireQ, firerateQ = 0.8f;
	public float random=0,Bulletspeed=4;
	bool isShoot;
    // Start is called before the first frame update
	new void Start () {
		base.Start();
        animator = GetComponent<Animator>();
	}
	void fire()
	{
		 nextfireQ = Time.time + firerateQ+Random.Range(-1.0f,1.0f);
		
		isShoot=true;
		GameObject inst= Instantiate(bullet);
		inst.transform.position=transform.position;
		inst.GetComponent<bullet>().toVector=VectorRotation(PointDirection(transform.position,player.transform.position)+Random.Range(-random,random));
		inst.GetComponent<bullet>().speed=Bulletspeed;
		
	}
	// Update is called once per frame
	new void Update () {
		base.Update();

		animator.SetBool("isShoot",isShoot);   
		if(!isShoot)
		animator.SetBool("isRun",is_player);     

		isShoot=false;
		if(Time.time > nextfireQ&&player!=null)
		{
			fire();
		}
	}
}
