using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
    if(Game_manager.Instance.NowWhatMode!=Game_manager.gameMode.endlessMode)
    {
        gameObject.SetActive(false);
    }    
    else
    {
        myText=gameObject.GetComponent<Text>();
    }

    }

    // Update is called once per frame
    void Update()
    {
        myText.text="HIGH :"+Game_manager.Instance.highScore+"\nNOW :"+monster_manager.Instance.wave;
        
    }
}
