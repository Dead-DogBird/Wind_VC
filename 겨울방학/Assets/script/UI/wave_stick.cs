using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_stick : MonoBehaviour
{
    float x;
    // Start is called before the first frame update
    void Start()
    {
      x=transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
       if(monster_manager.Instance.player!=null)
        transform.localScale=new Vector3((monster_manager.Instance.nextfireQ-Time.time)/30,1);
    }
}
