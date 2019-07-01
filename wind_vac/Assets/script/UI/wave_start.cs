using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_start : MonoBehaviour
{
    public float lateTime, lateQ = 4;
    public bool is_startWave=true;
    Vector3 Transform;
    // Start is called before the first frame update
    void Start()
    {
        Transform = transform.localPosition;
        lateTime = Time.time + 6;
        Transform.y =50;
        transform.localPosition = Transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_startWave)
        {
            Transform.y =50;
           // Transform.y += (50 - Transform.y) / 6;
            if (Time.time > lateTime)
            {
                is_startWave = false;
            }
        }
        else /*if(monster_manager.Instance.wave!=0)*/
        {
            Transform.y += (700 - Transform.y) / 10;
        }

        transform.localPosition = Transform;
    }
}
