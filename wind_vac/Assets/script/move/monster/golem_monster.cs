using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem_monster : monster_parents
{
    // Start is called before the first frame update
    float nextfireQ, firerateQ = 4f;
    float mNext,mLate=0.5f;
    int ChargeCount = 3;
    float length = 1;
    Vector3 toVector;
    new void Start()
    {
        base.Start();
        nextfireQ = Time.time + firerateQ;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (player != null)
        {
            if (ChargeCount != 0&&mNext<Time.time)
            {
                Doknockback(player.transform.position,transform.position,7);
                ChargeCount--;
                mNext = Time.time + mLate;
            }
            if(nextfireQ<Time.time)
            {
                ChargeCount=3;
                nextfireQ = Time.time + firerateQ+Random.Range(-1.0f,1.0f);
            }
        }
    }
}
