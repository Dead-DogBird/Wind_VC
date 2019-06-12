using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
public class shop_upgrade : MonoBehaviour
{
    public Shop_price[] inst = new Shop_price[6];
    int[] Level = new int[5] { 0, 0, 0, 0, 0 };
    player_stats player;
    Game_manager Gm;
    int max = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        player = monster_manager.Instance.player.GetComponent<player_stats>();
        if (player == null)
            Debug.Log("려ㅛ차");

        string Jsonstring = File.ReadAllText(Application.dataPath + "/game_data//Shop_pricedata.json");
        JsonData priceData = JsonMapper.ToObject(Jsonstring);
        for (int i = 0; i < inst.Length; i++)
        {
            inst[i] = new Shop_price(0, 0);
            inst[i].level = int.Parse(priceData[i]["level"].ToString());
            inst[i].price = int.Parse(priceData[inst[i].level]["price"].ToString());
        }
        Gm = Game_manager.Instance;
    }
    public void UpBoutton(int code)
    {
        switch (code)
        {
            case 0://공격력
                if (Level[0] < max && Gm.true_money >= inst[Level[0]].price)
                {
                    Gm.true_money -= inst[Level[0]].price;
                    player.attack += 0.5f;
                    Level[0]++;
                }
                break;
            case 1://탄속
                if (Level[1] < max && Gm.true_money >= inst[Level[1]].price)
                {
                    Gm.true_money -= inst[Level[1]].price;
                    player.attackspeed += 0.05f;
                    Level[1]++;
                }
                break;
            case 2://연사속도

                if (Level[2] < max && Gm.true_money >= inst[Level[2]].price)
                {
                    Gm.true_money -= inst[Level[2]].price;
                    Level[2]++;
                    player.rapidfire += 0.01f;
                }
                break;
            case 3://스피드
                if (Level[3] < max && Gm.true_money >= inst[Level[3]].price)
                {
                    Gm.true_money -= inst[Level[3]].price;
                    Level[3]++;
                    player.speed += 0.015f;
                }
                break;
            case 4://범위
                if (Level[4] < max && Gm.true_money >= inst[Level[4]].price)
                {
                    Gm.true_money -= inst[Level[4]].price;
                    Level[4]++;
                    player.extent += 0.1f;
                }
                break;
            case 5://체력 회복
                player.GetComponent<hit_player>().hp += 2;
                break;
        }
        Camera.main.GetComponent<ShakeManager>().Shake(0, 10f, 0, 0.7f, 4);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
