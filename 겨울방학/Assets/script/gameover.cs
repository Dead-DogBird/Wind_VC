using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    move_player player;
    Text myText;
    void Start()
    {
        myText=GetComponent<Text>();
        player=GameObject.Find("player").GetComponent<move_player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            myText.color = new Color(1,1,1,0);
        }
        else
        {
            myText.color = new Color(1,1,1,1);
        }
    }
}
