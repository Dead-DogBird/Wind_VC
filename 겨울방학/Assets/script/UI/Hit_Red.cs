using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Red : MonoBehaviour
{
    new SpriteRenderer renderer;
    public float hitcolor;
    // Start is called before the first frame update
    void Start()
    {
        renderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        hitcolor-=hitcolor/12;
        renderer.color=new Color(1,1,1,hitcolor);


    }
}
