using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_select : MonoBehaviour
{
    public int CanvasCode;
    public static Canvas_select Instance=null;
    
    public void toCanvas(int num)
    {
        CanvasCode=num;
    }
    void Awake()
    {
        Instance=this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
