using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2_boss : monster_parents
{
 //  Animator animator;
    public GameObject sumons;
	public float nextfireQ, firerateQ = 0.8f;
	public float random=5,Bulletspeed=4;
	bool isShoot;
    // Start is called before the first frame update
	new void Start () {
		base.Start();
        nextfireQ=Time.time+firerateQ;
       // animator = GetComponent<Animator>();
	}
	void fire()
	{
		 nextfireQ = Time.time + firerateQ+Random.Range(-1.0f,1.0f);
		
		isShoot=true;
		GameObject inst= Instantiate(sumons);
		inst.transform.position=monster_manager.Instance.player.transform.localPosition+new Vector3(Random.Range(-random,random),Random.Range(-random,random));
		
	}
	// Update is called once per frame
	new void Update () {
		base.Update();

		//animator.SetBool("isShoot",isShoot);   
		//if(!isShoot)
		//animator.SetBool("isRun",is_player);     

		isShoot=false;
		if(Time.time > nextfireQ&&player!=null)
		{
			fire();
		}
	}
}
