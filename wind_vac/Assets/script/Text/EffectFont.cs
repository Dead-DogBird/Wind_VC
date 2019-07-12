using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFont : MonoBehaviour {

	public string effectText;

	public float gravity = -0.01f;
	public float vspeed = 0;
	public float wspeed = 0,fwspeed;

	float alpha = 1;

	float destroyTime;

	TextMesh text;

	void Start()
	{
		vspeed = 0.1f;
		text = GetComponent<TextMesh>();
		destroyTime = Time.time + 0.3f;

		text.text = effectText;

		wspeed=fwspeed;
	//	float red = Random.Range(0.2f,0.7f);
		//text.color = new Color(1,red,0,1);
	}

	void Update () {
		vspeed += gravity;

		 wspeed += fwspeed>0?gravity/2:-gravity/2;
		transform.position += new Vector3(0,vspeed,0);
		transform.position += new Vector3(wspeed,0,0);
		if (Time.time >= destroyTime)
			alpha -= 0.1f;
		
		if (alpha <= 0)
			Destroy(gameObject);

		text.color = new Color(text.color.r,text.color.g,text.color.b,alpha);

		

	}
}
