using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    move_player player;
    Text myText;
    float nextfire, firelate = 0.4f;
    void Start()
    {
        myText = GetComponent<Text>();
        player = GameObject.Find("player").GetComponent<move_player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            myText.color = new Color(1, 1, 1, 0);
        }
        else
        {
            if (nextfire < Time.time)
            {
                Camera.main.GetComponent<ShakeManager>().Shake(0, 0, 0, 0.9f, 4);
                nextfire = +firelate + Time.time;
            }
            myText.color = new Color(1, 0, 0, 1);
        }
    }
}
