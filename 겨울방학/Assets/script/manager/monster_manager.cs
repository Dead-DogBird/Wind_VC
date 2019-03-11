using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_manager : MonoBehaviour {


  private static monster_manager _instance;  
        
        //프로퍼티(속성)를 이용해서 좀 더 개선할 수 있다. 접근자 방식. 
        public static monster_manager Instance 
        {  
                get  
                {  
                        if (!_instance)  
                        {  
                                _instance = (monster_manager)GameObject.FindObjectOfType(typeof(monster_manager));  
                                if (!_instance)  
                                {  
                                        GameObject container = new GameObject();  
                                        container.name = "MyClassContainer";  
                                        _instance = container.AddComponent(typeof(monster_manager)) as monster_manager;  
                                }  
                        }  
  
                        return _instance;  
                }  
        }  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
