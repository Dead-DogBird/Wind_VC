using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {


	public float plus;
	GameObject inst;
	Vector3 mouse;
	Vector3 joong;
	void Start () {
		inst = GameObject.Find("player");
		 
	}
	void Update()
	{
		// mouse= Camera.main.ScreenToWorldPoint(Input.mousePosition);//스크린
		  //mouse=Input.mousePosition;//월드
	}
	void LateUpdate () 
	{
		//camera좌표 += (마우스 좌표 - 카메라좌표)/10;
		//카메라좌표 += (플레이어 좌표 - 카메라좌표)/10;
	

		
		//transform.position = new Vector3(inst.transform.position.x+(mouse.x/200-2.5f),inst.transform.position.y+plus+(mouse.y/200-3),-10);//월드 좌표계
		//	transform.position = new Vector3(inst.transform.position.x+mouse.x/3,inst.transform.position.y+plus+mouse.y/3,-10);//스크린 좌표계
		transform.position += (inst.transform.position-transform.position)/10;
		transform.position += new Vector3(0,0,-10);
	}
}
