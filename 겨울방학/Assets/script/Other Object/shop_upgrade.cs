using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
public class shop_upgrade : MonoBehaviour
{
    public Shop_price[] inst = new Shop_price[6];
    int[] Level=new int[5];
    player_stats player;
    Game_manager Gm = Game_manager.Instance;
    int max = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = monster_manager.Instance.player.GetComponent<player_stats>();
        for (int i = 0; i < inst.Length; i++)
        {
            inst[i] = new Shop_price(0, 0);
        }
        string Jsonstring = File.ReadAllText(Application.dataPath + "/game_data//Shop_pricedata.json");
        // Debug.Log(Jsonstring);
        JsonData priceData = JsonMapper.ToObject(Jsonstring);
        for (int i = 0; i < priceData.Count; i++)
        {
            inst[i].level = int.Parse(priceData[i]["level"].ToString());
            inst[i].price = int.Parse(priceData[int.Parse(priceData[i]["level"].ToString())]["price"].ToString());
            Debug.Log(inst[i].level);
            Debug.Log(inst[i].price);
        }
        for(int i=0;i<5;i++)
        {
            Level[i]=0;
        }
    }
    public void UpBoutton(int code)
    {
        switch (code)
        {
            case 0://공격력
                if (Level[0]< max && Gm.true_money >= inst[Level[0]].price)
                {
                    Gm.true_money-=inst[Level[0]].price;
                    player.attack += 0.5f;
                    Level[0]++;
                    Debug.Log("ATTACK UP!");
                }
                else
                {
                    Debug.Log("error");
                }
                break;
            case 1://탄속
                player.attackspeed += 0.05f;
                break;
            case 2://연사속도
                player.rapidfire += 0.01f;
                break;
            case 3://스피드
                break;
            case 4://범위
                player.extent += 0.1f;
                break;
            case 5://체력 회복
                player.GetComponent<hit_player>().hp += 2;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
