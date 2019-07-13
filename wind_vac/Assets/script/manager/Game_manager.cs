using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public enum gameMode{stageMode,acadeMode,endlessMode};
    public gameMode NowWhatMode;
    public static Game_manager Instance = null;
    public List<Shop_price> Shop_Price_List = new List<Shop_price>();
    public new AudioSource audio;

    public AudioClip audioClip;
    public float volume;
    private Touch tempTouchs;
    public Vector3 touchedPos;

    private bool touchOn;

    public int true_money = 0;
    public int ui_money;
    public int highScore;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void save()
    {
        Debug.Log("저장하기");
        Shop_Price_List.Add(new Shop_price(0, 650));
        Shop_Price_List.Add(new Shop_price(1, 675));
        Shop_Price_List.Add(new Shop_price(2, 725));
        Shop_Price_List.Add(new Shop_price(3, 800));
        Shop_Price_List.Add(new Shop_price(4, 900));
        Shop_Price_List.Add(new Shop_price(5, 1025));
        JsonData ShopJson = JsonMapper.ToJson(Shop_Price_List);


        File.WriteAllText(Application.dataPath + "/game_data/Shop_pricedata.json", ShopJson.ToString());
    }
    public shop_active shop;
    public void Load()
    {
        Debug.Log("불러오기");
        string Jsonstring = File.ReadAllText(Application.dataPath + "/game_data/Shop_pricedata.json");
        // Debug.Log(Jsonstring);
        JsonData priceData = JsonMapper.ToObject(Jsonstring);
        for (int i = 0; i < priceData.Count; i++)
        {
            Debug.Log(priceData[i]["level"].ToString());
            Debug.Log(priceData[int.Parse(priceData[i]["level"].ToString())]["price"].ToString());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      //  save();
        touchOn = false;
        if(NowWhatMode==gameMode.endlessMode)
        {
         if(!PlayerPrefs.HasKey("endLessHigh"))
         {
             PlayerPrefs.SetInt("endLessHigh",0);
         }
         else
         {
             highScore=PlayerPrefs.GetInt("endLessHigh");
         }
        }
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.audioClip;
        audio.volume = volume;
        audio.loop = true;
        audio.Play();
    }
    public void pause(bool ispause)
    {
        if(ispause)
        Time.timeScale = 0;
        else
        Time.timeScale =1;
    }
    public bool shop_touch = false;
    public GameObject pauseCanvas;
    void Update()
    {
        if(Time.timeScale!=0)
        pauseCanvas.SetActive(false);
        else
        pauseCanvas.SetActive(true);

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log(Time.timeScale);

        if (ui_money < true_money)
            ui_money += 10;

        if (ui_money > true_money)
        {
            if (ui_money - true_money < 500)
                ui_money = true_money;
            ui_money -= 10;
        }

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
