using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inStage : MonoBehaviour
{
    public int Stage_num = 1;
    Vector3 MyTransform;
    // Start is called before the first frame update
    void Start()
    {
        MyTransform = transform.localPosition;
        MyTransform.y=-56;
    }

    // Update is called once per frame
    void Update()
    {
        if (Canvas_select.Instance.StageCode < Stage_num)
        { MyTransform.x += (1200*(Stage_num-Canvas_select.Instance.StageCode) - MyTransform.x) / 10; }
        if (Canvas_select.Instance.StageCode == Stage_num)
        { MyTransform.x += (0 - MyTransform.x) / 10; }
        if (Canvas_select.Instance.StageCode > Stage_num)
        { MyTransform.x += (-1200*(Canvas_select.Instance.StageCode-Stage_num) - MyTransform.x) / 10; }

        transform.localPosition = MyTransform;
    }
}
