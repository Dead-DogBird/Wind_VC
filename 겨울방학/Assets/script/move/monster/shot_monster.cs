using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_monster : monster_parents
{
    Animator animator;
    // Start is called before the first frame update
	new void Start () {
		base.Start();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
        animator.SetBool("isRun",is_player);
	}
}
