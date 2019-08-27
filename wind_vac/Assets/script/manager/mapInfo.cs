using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapInfo : MonoBehaviour
{
    public GameObject[] Map;
    public GameObject[] BackGround;
    public GameObject[][] MapMonster;
    public GameObject[] MapBoss;
    public int[] Wave;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Map[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        GameObject temp=Instantiate(BackGround[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        temp.transform.localScale*=2.5f;
        temp.GetComponent<SpriteRenderer>().sortingOrder=-5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
