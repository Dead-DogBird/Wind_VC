
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_orbit : MonoBehaviour {

	 float nextfireQ, firerateQ = 0.4f;
	// Use this for initialization
	public float destroy_time=0.2f;
	public float minus =0.01f;
	float orix;
	void Start () {
		nextfireQ = Time.time + firerateQ;
		orix=transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale -= new Vector3(minus,minus, 0);
		//if(Time.time > nextfireQ)
		if(transform.localScale.x<=orix-0.2f)
		{
		Destroy(gameObject);
		}
	}
}
