using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathrattle_monster : monster_parents
{
    public GameObject deathrattle_object;
    public int Count =5;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }
    public override void Kill()
    {
        for(int i=0;i<Count;i++)
        Instantiate(deathrattle_object,transform.position,Quaternion.identity);
        base.Kill();
    }
    // Update is called once per frame
    new void Update()
    {
        // if(hp<0)
        // Kill();
        base.Update();
    }
}
