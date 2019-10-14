using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waringmark : MonoBehaviour
{
    public GameObject monster;
    Vector3 scale;
    float startTime;
    float pi = 3.14f;
    public float coolTime = 2.5f;
    public bool isBoss=false;
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(5f, 5f);
        startTime = Time.time;
    }
    float returnTime() => Time.time - startTime;
       float moveElastic(float num)
    {
        float argument0 = num;
        if (argument0 == 0)
            return 0;
        else if (argument0 == 1)
            return 1;

        float p = 0.3f;
        float s = p / 4;

        return Mathf.Pow(2, -10 * argument0) * Mathf.Sin((argument0 - s) * (2 * pi) / p) + 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        scale =new Vector3(moveElastic(returnTime()),moveElastic(returnTime()));
        transform.localScale = scale;
        if (returnTime() > coolTime)
        {
            GameObject temp=Instantiate(monster, transform.position, Quaternion.identity);
            if(isBoss)
            {
                monster_manager.Instance.instanceBoss=temp;
                Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 10, 1.5f, 5);
            }
            Destroy(gameObject);
        }
        
    }
}
