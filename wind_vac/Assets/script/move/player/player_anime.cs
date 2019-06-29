using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_anime : MonoBehaviour {

	Animator animator;
	bool isrun;
	public bool orRun;
	move_player player;
	// Use this for initialization
	void Start () {
		 animator = GetComponent<Animator>();
		 player =GetComponent<move_player>();
	}
	
	// Update is called once per frame
	void Update () {
		float h =Input.GetAxis("Horizontal");
        float v =Input.GetAxis("Vertical");
		if(h!=0||v!=0||orRun!=false)
		{
			isrun=true;
		}
		else
		{
			isrun=false;
		}
		animator.SetBool("isRun",isrun);
		animator.SetBool("isJump",player.isJump);
	}
}
