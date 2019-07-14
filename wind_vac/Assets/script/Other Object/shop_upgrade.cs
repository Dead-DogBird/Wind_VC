using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
public class aText
{
    public Text Level;
    public Text price;
    public aText(Text Lv, Text Pr)
    {
        Level = Lv;
        price = Pr;
        Level = Level.GetComponent<Text>();
        price = price.GetComponent<Text>();
    }
    public void ToText(string LV, string pr)
    {
        Level.text = LV;
        price.text = pr;
    }
}
public class shop_upgrade : MonoBehaviour
{
    public Shop_price[] inst = new Shop_price[6];
    int[] Level = new int[6] { 0, 0, 0, 0, 0,0 };
    player_stats player;
    Game_manager Gm;
    int max = 6;
    int fullhp;
    public aText[] AllText = new aText[5];
    public Text[] Levels;
    public Text[] Prices;
    // Start is called before the first frame update
    void Start()
    {
        player = monster_manager.Instance.player.GetComponent<player_stats>();
        if (player == null)
            Debug.Log("려ㅛ차");

        //string Jsonstring = File.ReadAllText(Application.dataPath + "/game_data/Shop_pricedata.json");
        TextAsset test =Resources.Load("Shop_pricedata") as TextAsset;        
        string Jsonstring=test.text;


        //JsonData priceData = JsonMapper.ToObject(Jsonstring);
        JsonData priceData = JsonMapper.ToObject(Jsonstring);
        for (int i = 0; i < inst.Length; i++)
        {
            inst[i] = new Shop_price(0, 0);
            inst[i].level = int.Parse(priceData[i]["level"].ToString());
            inst[i].price = int.Parse(priceData[inst[i].level]["price"].ToString());
        }
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i] = new aText(Levels[i], Prices[i]);
            AllText[i].ToText("LV." + inst[0].level, inst[0].price + " G");
        }
        Gm = Game_manager.Instance;
        fullhp=player.GetComponent<hit_player>().hp;
    }
    public void UpBoutton(int code)
    {
        switch (code)
        {
            case 0://공격력
                if (Level[0] < max && Gm.true_money >= inst[Level[0]].price)
                {
                    Gm.true_money -= inst[Level[0]].price;
                    player.attack += 0.25f;
                    Level[0]++;
                if (Level[0] == max)
                {
                    AllText[0].ToText("LV.MAX!", "MAX!");
                }
                 else
                    AllText[0].ToText("LV." + Level[0], inst[Level[0]].price + " G");
                }
                break;
            case 1://탄속
                if (Level[1] < max && Gm.true_money >= inst[Level[1]].price)
                {
                    Gm.true_money -= inst[Level[1]].price;
                    player.attackspeed += 0.015f;
                    Level[1]++;
                if (Level[1] == max)
                {
                    AllText[1].ToText("LV.MAX!", "MAX!");
                }
                else   AllText[1].ToText("LV." + Level[1], inst[Level[1]].price + " G");
                }
                break;
            case 2://연사속도

                if (Level[2] < max && Gm.true_money >= inst[Level[2]].price)
                {
                    Gm.true_money -= inst[Level[2]].price;
                    player.rapidfire += 0.04f;
                    Level[2]++;
                if (Level[2] == max)
                {
                    AllText[2].ToText("LV.MAX!", "MAX!");
                }
                else AllText[2].ToText("LV." + Level[2], inst[Level[2]].price + " G");
                }
                break;
            case 3://스피드
                if (Level[3] < max && Gm.true_money >= inst[Level[3]].price)
                {
                    Gm.true_money -= inst[Level[3]].price;
                    Level[3]++;
                    player.speed += 0.015f;
                 if (Level[3] == max)
                {
                    AllText[3].ToText("LV.MAX!", "MAX!");
                }
                    else AllText[3].ToText("LV." + Level[3], inst[Level[3]].price + " G");
                }
                break;
            case 4://범위
                if (Level[4] < max && Gm.true_money >= inst[Level[4]].price)
                {
                    Gm.true_money -= inst[Level[4]].price;
                    Level[4]++;
                    player.extent += 0.1f;
                 if (Level[4] == max)
                {
                    AllText[4].ToText("LV.MAX!", "MAX!");
                }
                    else AllText[4].ToText("LV." + Level[4], inst[Level[4]].price + " G");
                }
                break;
            case 5://체력 회복
               if(Gm.true_money-500>=0)
                {if(player.GetComponent<hit_player>().hp+2<=fullhp)
                player.GetComponent<hit_player>().hp += 2;
                else
                player.GetComponent<hit_player>().hp=fullhp;
                Gm.true_money-=500;
                }
                break;
        }
        Camera.main.GetComponent<ShakeManager>().Shake(0, 10f, 0, 0.7f, 4);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
