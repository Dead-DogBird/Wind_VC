using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hpbar : MonoBehaviour
{
    Image myImage;
    float oriHp;
    hit_player player;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        // player =;
        player=monster_manager.Instance.player.GetComponent<hit_player>();
        oriHp=player.hp;
    }
    float CurHp;
    float BarHo = 1;
    // Update is called once per frame
    void Update()
    {

        if (monster_manager.Instance.player != null)
        {
            CurHp = (float)player.hp / oriHp;
            //if (BarHo > CurHp)
                BarHo += (CurHp - BarHo) / 10;

        }
        else
        {
            BarHo += (0 - BarHo) / 10;
        }
        myImage.fillAmount = BarHo;
    }
}
