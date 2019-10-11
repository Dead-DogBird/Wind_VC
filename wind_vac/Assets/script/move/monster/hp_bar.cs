using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_bar : MonoBehaviour
{
     GameObject parents;
     monster_parents parMon;
    SpriteRenderer myColor;
    float oriHp,curHp,orix;
    // Start is called before the first frame update
    void Start()
    {
        parents=gameObject.transform.parent.gameObject;
        while(true)
        {
            if(parents.transform.parent!=null)
            {
                parents=parents.transform.parent.gameObject;
            }
            else
            {
                break;
            }
        }
        parMon=parents.gameObject.GetComponent<monster_parents>();
        oriHp=parMon.hp;
        orix=transform.localScale.x;
        myColor=GetComponent<SpriteRenderer>();
        myColor.color=new Color(0,0,0,0);
    }
    // Update is called once per frame
    void Update()
    {
        curHp=parMon.hp;
        if(curHp<oriHp)
         myColor.color=new Color(1f,0.25f,0.25f,1);
        transform.localScale=new Vector3(orix*(curHp/oriHp),transform.localScale.y);
        GetComponent<Renderer>().material.color=new Color(1+(2-(curHp/oriHp)),1,1);
    }
}
