using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeIn : MonoBehaviour
{
    Image myImage;
    void Awake()
    {
        gameObject.SetActive(true);    
    }
    // Start is called before the first frame update
    void Start()
    {
        myImage=GetComponent<Image>();
    }

    float alpah=1;
    // Update is called once per frame
    void Update()
    {
        myImage.color=new Color(1,1,1,alpah);
        alpah-=0.015f;

        if(alpah<=0)
        Destroy(gameObject);

    }
}
