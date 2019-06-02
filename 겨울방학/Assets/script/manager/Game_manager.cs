using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
public class Shop_price
{
    public int level, price;
    public Shop_price(int Level, int Price)
    {
        level = Level;
        price = Price;
    }

}
public class Game_manager : MonoBehaviour
{
    public List<Shop_price> Shop_Price_List = new List<Shop_price>();
    private static Game_manager _instance;
    // Start is called before the first frame update  private static ksound_manager _instance;
    public static Game_manager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (Game_manager)GameObject.FindObjectOfType(typeof(Game_manager));
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "MyClassContainer";
                    _instance = container.AddComponent(typeof(Game_manager)) as Game_manager;
                }
            }

            return _instance;
        }
    }
    public new AudioSource audio;

    public AudioClip audioClip;
    public float volume;
    private Touch tempTouchs;
    public Vector3 touchedPos;

    private bool touchOn;

    public int true_money = 0;
    public int ui_money;
    public void save()
    {
        Debug.Log("저장하기");
        Shop_Price_List.Add(new Shop_price(0, 650));
        Shop_Price_List.Add(new Shop_price(1, 650));
        Shop_Price_List.Add(new Shop_price(2, 650));
        Shop_Price_List.Add(new Shop_price(3, 650));
        Shop_Price_List.Add(new Shop_price(4, 650));
        Shop_Price_List.Add(new Shop_price(5, 650));
        JsonData ShopJson=JsonMapper.ToJson(Shop_Price_List);
        File.WriteAllText(Application.dataPath+"/game_data/Shop_pricedata.json",ShopJson.ToString());
    }
    public shop_active shop;
    public void Load()
    {
        Debug.Log("불러오기");
        string Jsonstring=File.ReadAllText(Application.dataPath+"/game_data//Shop_pricedata.json");
       // Debug.Log(Jsonstring);
        JsonData priceData=JsonMapper.ToObject(Jsonstring);
        for(int i=0;i<priceData.Count;i++)
        {
            Debug.Log(priceData[i]["level"].ToString());
            Debug.Log(priceData[int.Parse(priceData[i]["level"].ToString())]["price"].ToString());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        touchOn = false;

        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.audioClip;
        audio.volume = volume;
        audio.loop = true;
        audio.Play();
    }
    public bool shop_touch = false;
    // Update is called once per frame
    void Update()
    {
        if (ui_money < true_money)
            ui_money += 5;
        if (ui_money > true_money)
            ui_money -= 5;
        if (Input.touchCount > 0)
        {    //터치가 1개 이상이면.
            for (int i = 0; i < Input.touchCount; i++)
            {
                tempTouchs = Input.GetTouch(i);
                if (tempTouchs.phase == TouchPhase.Began)
                {    //해당 터치가 시작됐다면.
                    touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);//get world position.
                    touchOn = true;

                    Collider2D temp = Physics2D.OverlapPoint(Game_manager.Instance.touchedPos);
                    if (temp != null)
                    {
                        if (temp.tag == "shop")
                        {
                            Game_manager.Instance.shop_touch = true;
                        }
                        else if (temp.tag != "shop")
                        {
                            Game_manager.Instance.shop_touch = false;
                        }
                    }

                    Debug.Log(touchOn);
                    break;   //한 프레임(update)에는 하나만.
                }
                if (tempTouchs.phase == TouchPhase.Ended)
                {
                    touchOn = false;
                }
                // shop_touch=!shop_touch;
            }


        }
        if (touchOn != true)
        {
            touchedPos = new Vector3(0, 0, 0);
        }
        // Debug.Log("상점!");
        // if (shop_touch)
        // {
        //     if (Input.GetMouseButtonDown(1))
        //     {
        //         shop_touch = !shop_touch;
        //     }
        // }
    }

}
