using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
   public int Player_num = 1;
    Vector3 MyTransform;
    player_anime P_Anime;
    // Start is called before the first frame update
    void Start()
    {
        P_Anime=GetComponent<player_anime>();
        MyTransform = transform.localPosition;
        MyTransform.y=150;
        if(!PlayerPrefs.HasKey("Player_Num"+Player_num))
        {
        GameObject temp=Instantiate(Canvas_select.Instance.Locker);
        temp.transform.SetParent(this.transform);
        temp.transform.localPosition=new Vector3(0,0,0);
        }
    }
    public void SetAni(bool isRun)
    {
        P_Anime.orRun=isRun;
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
        P_Anime.orRun=(Player_num==PlayerPrefs.GetInt("PlayerType",Canvas_select.Instance.playerCode));
    }
}
