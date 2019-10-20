using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetPlayer : MonoBehaviour
{
    public int Player_num = 1;
    Vector3 MyTransform, myscale;
    player_anime P_Anime;
    float oriX, oriY;
    GameObject temp;
    List<GameObject> childList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        P_Anime = GetComponent<player_anime>();
        MyTransform = transform.localPosition;
        MyTransform.y = 150;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount != 0)
            {
                childList.Add(transform.GetChild(i).GetChild(0).gameObject);
            }
            else
            {
                childList.Add(transform.GetChild(i).gameObject);
            }
        }
        if (!PlayerPrefs.HasKey("Player_Num" + Player_num))
        {
            temp = Instantiate(Canvas_select.Instance.Locker);
            temp.transform.SetParent(this.transform);
            temp.transform.localPosition = new Vector3(0, 0, 0);
            for (int i = 0; i < childList.Count; i++)
            {
                if (childList[i].GetComponent<Image>() != null)
                    childList[i].GetComponent<Image>().color = new Color(0, 0, 0);
            }
        }
        myscale = transform.localScale;
        oriX = myscale.x;
        oriY = myscale.y;
    }
    public void reActing()
    {
        for (int i = 0; i < childList.Count; i++)
        {
            if (childList[i].GetComponent<Image>() != null)
                childList[i].GetComponent<Image>().color = new Color(1, 1, 1);
        }
        Destroy(temp);
    }
    public void SetAni(bool isRun)
    {
        P_Anime.orRun = isRun;
    }
    // Update is called once per frame
    void Update()
    {
        if (Canvas_select.Instance.playerCode < Player_num)
        {
            MyTransform.x += (800 * (Player_num - Canvas_select.Instance.playerCode) - MyTransform.x) * 0.1f;
            myscale.x += (oriX * 0.7f - myscale.x) / 10;
            myscale.y += (oriY * 0.7f - myscale.y) / 10;
        }
        if (Canvas_select.Instance.playerCode == Player_num)
        {
            MyTransform.x += (-10 - MyTransform.x) * 0.1f;
            myscale.x += (oriX - myscale.x) / 10;
            myscale.y += (oriY - myscale.y) / 10;
        }
        if (Canvas_select.Instance.playerCode > Player_num)
        {
            MyTransform.x += (-800 * (Canvas_select.Instance.playerCode - Player_num) - MyTransform.x) * 0.1f;
            myscale.x += (oriX * 0.7f - myscale.x) / 10;
            myscale.y += (oriY * 0.7f - myscale.y) / 10;
        }

        transform.localPosition = MyTransform;
        transform.localScale = myscale;
        P_Anime.orRun = (Player_num == PlayerPrefs.GetInt("PlayerType", Canvas_select.Instance.playerCode));
    }
}
