using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class wave_text : MonoBehaviour
{
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(monster_manager.Instance.wave==0)
        myText.text="준비시간!";
        else if(monster_manager.Instance.wave==monster_manager.Instance.boss_wave)
        myText.text="BOSS WAVE!";
        else
        myText.text=monster_manager.Instance.wave+"WAVE";

    }
}
