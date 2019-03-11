using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_pa : GameMaker {
    
    public int hp=3;
    GameObject current_bomb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(hp<=0)
        Destroy(gameObject);
	}
}
