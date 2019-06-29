using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child_manager : MonoBehaviour
{
    GameObject parents;
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
        parents.gameObject.GetComponent<monster_parents>().childs.AddLast(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
