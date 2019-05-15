using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_spritechild : MonoBehaviour
{ 
    public GameObject parents;
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
        parents.gameObject.GetComponent<player_sprite>().Childs.AddLast(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
