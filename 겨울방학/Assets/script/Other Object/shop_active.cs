using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_active : MonoBehaviour
{
    public Transform ToHigh;
    Vector3 oriPos;
    bool isTouch;
 
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
    }
    void OnMouseDown()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(monster_manager.Instance.monsterList.Count==0)
        {
            transform.position += (oriPos - transform.position) / 10;
        }
        else
        {   
            transform.position+=(ToHigh.position - transform.position)/20;
        }
    }
}
