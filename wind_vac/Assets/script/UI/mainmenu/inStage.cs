using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inStage : MonoBehaviour
{
    public int Stage_num = 1;
    Vector3 MyTransform, myscale;
    public bool isAkade = false;
    public bool isUnlock = true;
    float oriX, oriY;
    // Start is called before the first frame update
    void Start()
    {
        MyTransform = transform.localPosition;
        MyTransform.y = 150;
        myscale = transform.localScale;
        oriX = myscale.x;
        oriY = myscale.y;
        if (Stage_num != 1 && !PlayerPrefs.HasKey("Stage_Num" + Stage_num))
        {
            GameObject temp = Instantiate(Canvas_select.Instance.Locker);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0, 0, 0);
            transform.GetComponent<Image>().color = new Color(0, 0, 0);
            isUnlock = false;
            //transform.GetComponent<Button>().enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!isAkade)
        {
            if (Canvas_select.Instance.StageCode < Stage_num)
            {
                MyTransform.x += (800 * (Stage_num - Canvas_select.Instance.StageCode) - MyTransform.x) * 0.1f;
                myscale.x+=(oriX*0.5f-myscale.x)/10;
                myscale.y+=(oriY*0.5f-myscale.y)/10;
            }
            if (Canvas_select.Instance.StageCode == Stage_num)
            {
                MyTransform.x += (0 - MyTransform.x) * 0.1f;
                myscale.x+=(oriX-myscale.x)/10;
                myscale.y+=(oriY-myscale.y)/10;
            }
            if (Canvas_select.Instance.StageCode > Stage_num)
            {
                MyTransform.x += (-800 * (Canvas_select.Instance.StageCode-Stage_num)- MyTransform.x) * 0.1f;
                myscale.x+=(oriX*0.5f-myscale.x)/10;
                myscale.y+=(oriY*0.5f-myscale.y)/10;
            }

        }
        transform.localPosition = MyTransform;
        transform.localScale = myscale;
    }
}
