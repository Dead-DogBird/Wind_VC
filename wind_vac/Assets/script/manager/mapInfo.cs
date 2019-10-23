using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class MonsterList
{
    public GameObject[] Monster;
}
public class mapInfo : MonoBehaviour
{
    public GameObject[] Map;
    public GameObject[] BackGround;
    public MonsterList[] MapMonster;
    public GameObject[] MapBoss;
    public int[] Wave;
    public Text stageName;
    public string[] stageNames;
    public AudioClip[] stageMusics;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Map[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        GameObject temp=Instantiate(BackGround[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        temp.transform.localScale=new Vector3(2.5f,2.5f);
        temp.GetComponent<SpriteRenderer>().sortingOrder=-5;
        temp.transform.parent=Camera.main.transform;
        stageName.text="St."+(PlayerPrefs.GetInt("noWStage")+1)+" "+stageNames[PlayerPrefs.GetInt("noWStage")];
        Game_manager.Instance.audio.clip=stageMusics[PlayerPrefs.GetInt("noWStage")];
        Game_manager.Instance.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
