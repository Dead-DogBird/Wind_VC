using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 toVector;
    public float speed =3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(toVector*Time.deltaTime*speed);
        // transform.localScale-=transform.localScale/100;
        // if(transform.localScale.x<=0)
        // Destroy(gameObject);
        Destroy(gameObject,8);
    }
}
