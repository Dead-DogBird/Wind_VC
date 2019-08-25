using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
   public int Player_num = 1;
    Vector3 MyTransform;
    // Start is called before the first frame update
    void Start()
    {
        MyTransform = transform.localPosition;
        MyTransform.y=150;
        if(!PlayerPrefs.HasKey("Player_Num"+Player_num))
        {
        GameObject temp=Instantiate(Canvas_select.Instance.Locker);
        temp.transform.SetParent(this.transform);
        temp.transform.localPosition=new Vector3(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Canvas_select.Instance.playerCode < Player_num)
        { MyTransform.x += (800*(Player_num-Canvas_select.Instance.playerCode) - MyTransform.x) *0.1f; }
        if (Canvas_select.Instance.playerCode == Player_num)
        { MyTransform.x += (-10 - MyTransform.x) *0.1f; }
        if (Canvas_select.Instance.playerCode > Player_num)
        { MyTransform.x += (-800*(Canvas_select.Instance.playerCode-Player_num) - MyTransform.x) *0.1f; }

        transform.localPosition = MyTransform;
    }
}
