using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_orbit : MonoBehaviour {

	 float nextfireQ, firerateQ = 0.4f;
	// Use this for initialization
	void Start () {
		nextfireQ = Time.time + firerateQ;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= new Vector3(0.02f, 0.02f, 0);
		if(Time.time > nextfireQ)
		Destroy(gameObject);
		/* if(transform.localScale.x<=0.25f)
		{
		}*/
	}
}
