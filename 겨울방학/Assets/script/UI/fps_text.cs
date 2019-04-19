using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fps_text : MonoBehaviour {


	public Text myText;
	float nextfireQ, firerateQ = 1f;
	int frame=0,fps=0;
	int fa=0;
	hit_player player;
	// Use this for initialization
	void Start () {
		myText=GetComponent<Text>();
		player=GameObject.Find("player").GetComponent<hit_player>();
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
		if(monster_manager.Instance.hitbombCount==0&&monster_manager.Instance.firebombCount==0)
		myText.text="명중률 : 0%";
		else
		myText.text="명중률 : "+Mathf.Round((monster_manager.Instance.hitbombCount/monster_manager.Instance.firebombCount)*100)+"%";
	//	myText.color = new Color(1+(10-player.hp)*0.1f,1-(10-player.hp)*0.1f,1-(10-player.hp)*0.1f);
	}
}
