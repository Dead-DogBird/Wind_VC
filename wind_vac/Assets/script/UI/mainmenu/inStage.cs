using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inStage : MonoBehaviour
{
    public int Stage_num = 1;
    Vector3 MyTransform;
    public bool isAkade = false;
    // Start is called before the first frame update
    void Start()
    {
        MyTransform = transform.localPosition;
        MyTransform.y = 150;
        if (Stage_num!=1&&!PlayerPrefs.HasKey("Stage_Num" + Stage_num))
        {
            GameObject temp = Instantiate(Canvas_select.Instance.Locker);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0, 0, 0);
            transform.GetComponent<Image>().color = new Color(0, 0, 0);
            transform.GetComponent<Button>().enabled = false;
        }
       
    }
    void BuyMe()
    {
        if(isAkade)
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAkade)
        {
            if (Canvas_select.Instance.StageCode < Stage_num)
            { MyTransform.x += (1200 * (Stage_num - Canvas_select.Instance.StageCode) - MyTransform.x) * 0.1f; }
            if (Canvas_select.Instance.StageCode == Stage_num)
            { MyTransform.x += (0 - MyTransform.x) * 0.1f; }
            if (Canvas_select.Instance.StageCode > Stage_num)
            { MyTransform.x += (-1200 * (Canvas_select.Instance.StageCode - Stage_num) - MyTransform.x) * 0.1f; }
        }
        transform.localPosition = MyTransform;
    }
}
