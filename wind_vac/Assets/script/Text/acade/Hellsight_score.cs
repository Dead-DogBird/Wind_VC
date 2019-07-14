using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hellsight_score : MonoBehaviour
{
    public summon_Altar hellsightmanager;
    public bool isHighScore=false;
    float highScore;
    Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        mytext=GetComponent<Text>();
         if (!PlayerPrefs.HasKey("acadeHigh"))
            {
                PlayerPrefs.SetFloat("acadeHigh", 0);
            }
            else
            {
                highScore = PlayerPrefs.GetFloat("acadeHigh");
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHighScore)
        {
            mytext.text=hellsightmanager.scoresecend.ToString("F2")+"초";
        }
        else
        {
            mytext.text="최고기록 :"+PlayerPrefs.GetFloat("acadeHigh")+"초";
        }

        if(PlayerPrefs.GetFloat("acadeHigh")<=hellsightmanager.scoresecend)
        {
            PlayerPrefs.SetFloat("acadeHigh", hellsightmanager.scoresecend);
        }
    }
}
