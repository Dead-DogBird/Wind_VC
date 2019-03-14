using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_bar : MonoBehaviour
{
     GameObject parents;
     monster_parents parMon;
    float oriHp,curHp;
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
    }
    // Update is called once per frame
    void Update()
    {
        curHp=parMon.hp;
        transform.localScale=new Vector3((curHp/oriHp),transform.localScale.y);
        GetComponent<Renderer>().material.color=new Color(1+(2-(curHp/oriHp)),1,1);
    }
}
