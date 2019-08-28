using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Map[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        GameObject temp=Instantiate(BackGround[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        temp.transform.localScale=new Vector3(2.5f,2.5f);
        temp.GetComponent<SpriteRenderer>().sortingOrder=-5;
        temp.transform.parent=Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
