using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fps_text : MonoBehaviour {


	public Text myText;
	float nextfireQ, firerateQ = 1f;
	int frame=0,fps=0;
	//int fa=0;
	hit_player player;
	// Use this for initialization
	int oriHP;
	void Start () {
		myText=GetComponent<Text>();
		player=monster_manager.Instance.player.GetComponent<hit_player>();
		
		oriHP=player.hp;
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
		//myText.text=""+fps;
		if(player!=null)
		myText.text=""+player.hp+"/"+oriHP;
		else
		{
			myText.text="game over";
		}
	//	myText.color = new Color(1+(10-player.hp)*0.1f,1-(10-player.hp)*0.1f,1-(10-player.hp)*0.1f);
	}
}
