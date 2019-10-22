using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : monster_parents
{
    // Start is called before the first frame update
    public GameObject timeGage,Effect;
	public float nextfireQ, firerateQ = 30f;
    public GameObject[] boss;
	public float toY;
	float fx,fy;
    float orix;
	new void Start () {
		base.Start();
		  orix=timeGage.transform.localScale.x;
		  nextfireQ=Time.time+firerateQ;
		  giveMoney=0;
		  toY=transform.position.y;
		  transform.position-=new Vector3(0,0, transform.position.y/100);
		  transform.position+=new Vector3(0,20);
		  fx=transform.position.x;
		  fy=transform.position.y;
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
		timeGage.transform.localScale=new Vector3(orix*((nextfireQ - Time.time)/firerateQ),timeGage.transform.localScale.y);
		transform.localScale=new Vector3(1,1);
		if(Time.time>nextfireQ)
		{
			Instantiate(boss[Random.Range(0,boss.Length)],transform.position,Quaternion.identity);
			nextfireQ=Time.time+firerateQ;
			for(int i=0;i<5;i++)
			Instantiate(Effect,transform.position+new Vector3(Random.Range(-1f,1),Random.Range(-3f,3f)),Quaternion.identity);
			Kill();
		}
		fy+=(toY-fy)/5;
		transform.position=new Vector3(fx,fy);
	}
}
