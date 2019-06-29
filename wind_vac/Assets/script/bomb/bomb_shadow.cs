using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_shadow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3(0.075f, 0.075f, 0);
        Destroy(gameObject, 0.3f);
	}
}
