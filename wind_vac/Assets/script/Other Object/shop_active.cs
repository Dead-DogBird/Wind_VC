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
        Game_manager.Instance.shop = this;
    }
    public void OnMouseDown()
    {
        Game_manager.Instance.shop_touch = true;
    }
    // Update is called once per frame
    
    void Update()
    {

        
        if (monster_manager.Instance.monsterList.Count == 0)
        {
            transform.position += (oriPos - transform.position) / 10;
        }
        else
        {
            Game_manager.Instance.shop_touch = false;
            transform.position += (ToHigh.position - transform.position) / 20;
        }
    }
}
