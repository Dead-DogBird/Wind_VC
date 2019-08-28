using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;
public class Stage_info
{
    public int stageCode;
    public string StageComent, StageName, StageNumber_text;
    public Stage_info(int SNUM, string SN, string SC)
    {
        stageCode = SNUM;
        StageComent = SC;
        StageName = SN;
        StageNumber_text = SNUM + " 스테이지";
    }

}
public class Character
{
    public int playerCode;
    public string playerStory, playerName;
    public Character(int p_code, string pN, string pS)
    {
        playerCode = p_code;
        playerStory = pS;
        playerName = pN;
    }

}
public class Canvas_select : MonoBehaviour
{
    public int CanvasCode;
    public int StageCode = 1, maxNum;
    public static Canvas_select Instance = null;
    public int playerCode, Maxplayer;
    public List<Character> playerList = new List<Character>();
    public List<Stage_info> StageInfolist = new List<Stage_info>();
    public Text StageComent, StageName, StageNumber;
    public Text CharacterName, CharacterStory, Selected;
    public Slider Master, Bgm, Sfx;
    public GameObject Ship, Ship_Cloud, Background;
    public Sprite Bullred, oriImg;
    public Text PlayerMoneyText;
    public int playermoney
    {
        get
        {
            if (!PlayerPrefs.HasKey("playermoney"))
                PlayerPrefs.SetInt("playermoney", 0);

            return PlayerPrefs.GetInt("playermoney");
        }
        set
        {
            PlayerPrefs.SetInt("playermoney", value);
        }

    }
    public GameObject Locker;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (!PlayerPrefs.HasKey("PlayerType"))
            PlayerPrefs.SetInt("PlayerType", 0);
        if (PlayerPrefs.HasKey("noWStage"))
            PlayerPrefs.SetInt("noWStage", 0);

    }
    float pi = 3.14f;
    float moveElastic(float num)
    {
        float argument0 = num;
        if (argument0 <= 0)
            return 0;
        else if (argument0 >= 1)
            return 1;

        float p = 0.3f;
        float s = p / 4;

        return Mathf.Pow(2, -10 * argument0) * Mathf.Sin((argument0 - s) * (2 * pi) / p) + 1;
    }

    public void saveStageInfo()
    {
        StageInfolist.Add(new Stage_info(1, "하늘 간이역", "위대한 발견을 향한 여정의 시작 \n 모든것이 시작된다.(기차표 별도 구매)(배 무단 주차금지)"));
        StageInfolist.Add(new Stage_info(2, "스탠다드 하늘섬", "낮선 기류에 휩쓸려 도착한 곳은 \n 알수없는 하늘섬, 범상치 않다.(쓰레기 무단투기 금지)"));
        StageInfolist.Add(new Stage_info(3, "미스테리 사막유적", "작열하는 태양, 때때로의 야자수 \n 그리고 알수없는 사막의 고대유적.(낙서 금지)"));
        JsonData ShopJson = JsonMapper.ToJson(StageInfolist);

        File.WriteAllText(Application.dataPath + "/Resources/StageInfo.json", ShopJson.ToString());

        playerList.Add(new Character(0, "캡틴", "낯선 섬에 불시착한 1인 해적단의 선장. \n\n탈출이 1 순위 인듯 하다"));
        playerList.Add(new Character(1, "나이트", "용병일을 하는 기사.\n\n험난한 전장을 누비며 명성을 쌓았다.\n꿈은 부귀영화"));
        JsonData PlayerJson = JsonMapper.ToJson(playerList);

        File.WriteAllText(Application.dataPath + "/Resources/playerList.json", PlayerJson.ToString());
        Debug.Log("저장됨!");
    }
    JsonData priceData, PlayerData;
    public void Load()
    {
        Debug.Log("불러오기");
        {
            string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/StageInfo.json");
            // Debug.Log(Jsonstring);
            priceData = JsonMapper.ToObject(Jsonstring);
        }
        {
            string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/playerList.json");
            // Debug.Log(Jsonstring);
            PlayerData = JsonMapper.ToObject(Jsonstring);
        }

    }
    public void anotherLoad()
    {
        {
            TextAsset test = Resources.Load("StageInfo") as TextAsset;
            priceData = JsonMapper.ToObject(test.text);
        }
        {
            TextAsset test = Resources.Load("playerList") as TextAsset;
            PlayerData = JsonMapper.ToObject(test.text);
        }
    }

    public void ToStage(bool isUp)
    {
        if (isUp && StageCode + 1 <= maxNum)
        {
            StageCode++;
        }
        if (!isUp && StageCode - 1 >= 1)
        {
            StageCode--;
        }
        StageComent.text = priceData[StageCode - 1]["StageComent"].ToString();
        StageName.text = priceData[StageCode - 1]["StageName"].ToString();
        StageNumber.text = priceData[StageCode - 1]["StageNumber_text"].ToString();

    }
    public void SetPlayer_button(bool isUp)
    {
        if (isUp && playerCode + 1 <= Maxplayer)
        {
            playerCode++;
        }
        if (!isUp && playerCode - 1 >= 0)
        {
            playerCode--;
        }
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        CharacterName.text = PlayerData[playerCode]["playerName"].ToString();
        CharacterStory.text = PlayerData[playerCode]["playerStory"].ToString();

    }
    public void ChoosePlayer()
    {
        PlayerPrefs.SetInt("PlayerType", playerCode);
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
    }
    public void DataDelete()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("title");
    }
    public void toCanvas(int num)
    {
        CanvasCode = num;
        if (CanvasCode == 0)
            Background.GetComponent<Image>().sprite = oriImg;
        else
            Background.GetComponent<Image>().sprite = Bullred;
    }
    void SetsoundKey()
    {
        if (!PlayerPrefs.HasKey("MasterVoluim"))
            PlayerPrefs.SetFloat("MasterVoluim", 1);
        if (!PlayerPrefs.HasKey("SfxVoluim"))
            PlayerPrefs.SetFloat("SfxVoluim", 1);
        if (!PlayerPrefs.HasKey("BgmVoluim"))
            PlayerPrefs.SetFloat("BgmVoluim", 1);

        Master.value = PlayerPrefs.GetFloat("MasterVoluim");
        Sfx.value = PlayerPrefs.GetFloat("SfxVoluim");
        Bgm.value = PlayerPrefs.GetFloat("BgmVoluim");
    }
    Vector3 ship_position, cloud_position;
    public GameObject resetWaring;
    // Start is called before the first frame update
    void Start()
    {
        //saveStageInfo();
        //Load();
        anotherLoad();
        SetsoundKey();
        playerCode = PlayerPrefs.GetInt("PlayerType");
        ship_position = new Vector3(-2000, -150, 0);
        cloud_position = new Vector3(-2000, 0, 0);
        oriImg = Background.GetComponent<Image>().sprite;
        StageComent.text = priceData[StageCode - 1]["StageComent"].ToString();
        StageName.text = priceData[StageCode - 1]["StageName"].ToString();
        StageNumber.text = priceData[StageCode - 1]["StageNumber_text"].ToString();
        CharacterName.text = PlayerData[playerCode]["playerName"].ToString();
        CharacterStory.text = PlayerData[playerCode]["playerStory"].ToString();
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        AdBanner.Instance.banner.Show();
        resetWaring.transform.localScale = new Vector3(0, 0, 0);
        PlayerMoneyText.text = playermoney.ToString();
        if (!PlayerPrefs.HasKey("Stage_Num1"))
            PlayerPrefs.SetInt("Stage_Num1", 1);
        if (!PlayerPrefs.HasKey("Player_Num0"))
            PlayerPrefs.SetInt("Player_Num0", 1);
    }
    public void GoIngame(int i)
    {
        switch (i)
        {
            case 666:
                LoadingSceneManager.LoadScene("Hellsight");
                break;
            case 999:
                LoadingSceneManager.LoadScene("endless");
                break;

            default:
                string map = "stage";
                PlayerPrefs.SetInt("noWStage",i-1);
                LoadingSceneManager.LoadScene(map);
                break;
        }
    }
    void Option()
    {
        PlayerPrefs.SetFloat("MasterVoluim", Master.value);
        PlayerPrefs.SetFloat("SfxVoluim", Sfx.value);
        PlayerPrefs.SetFloat("BgmVoluim", Bgm.value);
    }
    // Update is called once per frame
    bool isReset = false;
    public void Reset()
    {
        isReset = true;
    }
    public void Reset_true(bool isyes)
    {
        if (isyes)
            DataDelete();
        else
            isReset = false;
    }
    float elastic = 0;
    void Update()
    {


        if (CanvasCode == 3)
        {
            if (isReset)
            {
                if (elastic < 1)
                    elastic += 0.015f;
            }
            else
            {
                Option();
                if (elastic >= 0)
                    elastic -= 0.03f;
            }
            resetWaring.transform.localScale = new Vector3(moveElastic(elastic), moveElastic(elastic));
        }
    }
    float shipsin, sizesin;
    void ShipUpdate()
    {
        shipsin += 0.005f;
        if (shipsin > 10000)
            shipsin = 0;
        ship_position.y = ship_position.y + Mathf.Sin(shipsin) * 0.5f;
        ship_position.x = ship_position.x + Mathf.Cos(shipsin) * 0.5f;

    }
    void FixedUpdate()
    {

        if (CanvasCode == 0)
        {
            if (ship_position.x <= -250)
                ship_position.x += (-250 - ship_position.x) / 15;
            ShipUpdate();
            if (cloud_position.x <= -91)
                cloud_position.x += (-91 - cloud_position.x) / 10;
        }
        else
        {
            if (ship_position.x >= -2500)
                ship_position.x += (-2500 - ship_position.x) / 15;
            ShipUpdate();
            if (cloud_position.x >= -1201)
                cloud_position.x += (-1201 - cloud_position.x) / 10;
        }
        Ship.transform.localPosition = ship_position;
        Ship_Cloud.transform.localPosition = cloud_position;
    }
}
