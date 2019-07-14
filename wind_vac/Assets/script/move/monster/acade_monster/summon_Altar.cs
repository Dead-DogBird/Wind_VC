using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summon_Altar : MonoBehaviour
{
    public GameObject altar;
    public float nextlate, firerateQ = 50;
    float start_time;
    public Text[] getTime;

    // Start is called before the first frame update
    void Start()
    {   start_time=Time.time;
        nextlate = Time.time + 10;
    }
    public float scoresecend;
    float reTurnafterTime()=>Time.time-start_time;
    void sumaltar()
    {
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 0, 3f, 5);
        nextlate=Time.time+firerateQ;
         int randaltar= Random.Range(0, 3);
            for (int i = 0; i <randaltar; i++)
            {
                Instantiate(altar,monster_manager.Instance.RandomCircle(monster_manager.Instance.player.transform.position, 6, Random.Range(0, 360)),Quaternion.identity);

            }
    }
    // Update is called once per frame
    void Update()
    {
        if (nextlate < Time.time)
        {
            sumaltar();
        }
        foreach(Text a in getTime)
        {
            if(monster_manager.Instance.player!=null)
            a.text=reTurnafterTime().ToString("F2");
        }
        if(monster_manager.Instance.player==null)
        {
            scoresecend=float.Parse(getTime[0].text);
        }
    }
}
