using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Acting : MonoBehaviour
{
    public int MyNumber;
    Vector3 positon;
    // Start is called before the first frame update
    void Start()
    {
        positon=transform.localPosition;    
         positon.y=-1200;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(MyNumber==Canvas_select.Instance.CanvasCode)
        {
            positon.y+=(0-positon.y)*0.1f;
        }
        else
        {
            positon.y+=(-1500-positon.y)*0.1f;
        }
        transform.localPosition=positon;
    }
}
