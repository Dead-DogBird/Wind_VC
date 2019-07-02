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
         positon.y=-1000;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(MyNumber==Canvas_select.Instance.CanvasCode)
        {
            positon.y+=(0-positon.y)/10;
        }
        else
        {
            positon.y+=(-1000-positon.y)/10;
        }
        transform.localPosition=positon;
    }
}
