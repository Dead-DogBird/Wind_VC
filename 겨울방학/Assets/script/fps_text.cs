using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fps_text : MonoBehaviour {


	public Text myText;
	float nextfireQ, firerateQ = 1f;
	int frame=0,fps=0;
	int fa=0;
	// Use this for initialization
	void Start () {
		myText=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		++frame;
		if(Time.time>nextfireQ)
		{
			nextfireQ = Time.time + firerateQ;
			fps=frame;
			frame=0;
		}
		myText.text="프레임:"+fps;
	}
}
