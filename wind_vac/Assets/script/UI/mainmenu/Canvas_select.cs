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
    public int playerCode,playerPrice;
    public string playerStory, playerName;
    public Character(int p_code,int p_price ,string pN, string pS)
    {
        playerCode = p_code;
        playerStory = pS;
        playerName = pN;
        playerPrice =p_price;
    }

}
public class Canvas_select : MonoBehaviour
{
    public new AudioSource audio;
    AudioSource sfxaudio;
    public AudioClip sfxClip;
    public AudioClip audioClip;
    [HideInInspector]
    public static List<SetPlayer> Unlock_playerlist=new List<SetPlayer>();
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
    public BuyContents buyCon_;
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
        if (!PlayerPrefs.HasKey("noWStage"))
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

        playerList.Add(new Character(0,0,"캡틴", "낯선 섬에 불시착한 1인 해적단의 선장. \n\n탈출이 1 순위 인듯 하다"));
        playerList.Add(new Character(1,1000,"나이트", "용병일을 하는 방랑기사인 그녀는\n\n험난한 전장을 누비며 명성을 쌓았다.\n꿈은 부귀영화"));
        playerList.Add(new Character(2,1700,"엘 폭탄코", "폭발과 다이너마이트를 광적으로 사랑한다.\n사방을 폭발로 물들이는것을 꿈꾼다."));
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
        sfxaudio.Play();
        if (isUp && StageCode + 1 <= maxNum)
        {
            StageCode++;
        }
        if (!isUp && StageCode - 1 >= 1)
        {
            StageCode--;
        }
        StageNumber.text = priceData[StageCode - 1]["StageNumber_text"].ToString();
        StageName.text = (PlayerPrefs.HasKey("Stage_Num" + StageCode))?priceData[StageCode - 1]["StageName"].ToString():"???";
        StageComent.text =(PlayerPrefs.HasKey("Stage_Num" + StageCode))?priceData[StageCode - 1]["StageComent"].ToString():"잠겨있습니다 \n("+(StageCode-1)+" 스테이지 클리어시 잠금해제됨)";

    }
    public void SetPlayer_button(bool isUp)
    {
        sfxaudio.Play();
        if (isUp && playerCode + 1 <= Maxplayer)
        {
            playerCode++;
        }
        if (!isUp && playerCode - 1 >= 0)
        {
            playerCode--;
        }
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        CharacterName.text =(PlayerPrefs.HasKey("Player_Num"+playerCode))? PlayerData[playerCode]["playerName"].ToString():"???";
        CharacterStory.text =(PlayerPrefs.HasKey("Player_Num"+playerCode))? PlayerData[playerCode]["playerStory"].ToString():"\n\n\t\t잠겨 있습니다.";

    }
    public void UnlockReActive()
    {
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        CharacterName.text =(PlayerPrefs.HasKey("Player_Num"+playerCode))? PlayerData[playerCode]["playerName"].ToString():"???";
        CharacterStory.text =(PlayerPrefs.HasKey("Player_Num"+playerCode))? PlayerData[playerCode]["playerStory"].ToString():"\n\n\t\t잠겨 있습니다.";
    }
    public void ChoosePlayer()
    {
        sfxaudio.Play();
        if (PlayerPrefs.HasKey("Player_Num" + playerCode))
        {
            PlayerPrefs.SetInt("PlayerType", playerCode);
            Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        }
        else
        {
            Debug.Log("player :"+playerCode);
            buyCon_.BuyContentsInit(int.Parse(PlayerData[playerCode]["playerPrice"].ToString()),"Player_Num" + playerCode);
        }
    }
    public void DataDelete()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("title");
    }
    public void toCanvas(int num)
    {
        sfxaudio.Play();
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
    public GameObject resetWaring, creditPanel;
    // Start is called before the first frame update
    void Start()
    {
        ///Json파일 수정할일 있으면 한번 돌리고 하기
        //saveStageInfo();
        //Load();
        //-------------------------------------------
        anotherLoad();
        SetsoundKey();
        playerCode = PlayerPrefs.GetInt("PlayerType");
        //객체 설정
        ship_position = new Vector3(-2000, -150, 0);
        cloud_position = new Vector3(-2000, 0, 0);
        
        oriImg = Background.GetComponent<Image>().sprite;
        //Json파일들 파싱
        StageComent.text = priceData[StageCode - 1]["StageComent"].ToString();
        StageName.text = priceData[StageCode - 1]["StageName"].ToString();
        StageNumber.text = priceData[StageCode - 1]["StageNumber_text"].ToString();
        CharacterName.text = PlayerData[playerCode]["playerName"].ToString();
        CharacterStory.text = PlayerData[playerCode]["playerStory"].ToString();
        //플레이어 설정 초기화
        Selected.text = (playerCode == PlayerPrefs.GetInt("PlayerType", playerCode)) ? "선택됨" : "";
        //광고
        AdBanner.Instance.banner.Show();
        //옵션 판넬
        resetWaring.transform.localScale = new Vector3(0, 0, 0);
        creditPanel.transform.localScale = new Vector3(0, 0, 0);
       //초기화시 담당
        PlayerMoneyText.text = playermoney.ToString();
        if (!PlayerPrefs.HasKey("Stage_Num1"))
            PlayerPrefs.SetInt("Stage_Num1", 1);
        if (!PlayerPrefs.HasKey("Player_Num0"))
            PlayerPrefs.SetInt("Player_Num0", 1);
        //플레이어 리스트 정렬
        sort();
        Maxplayer=Unlock_playerlist.Count-1;
        //사운드 초기화
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.audioClip;
        audio.volume = PlayerPrefs.GetFloat("BgmVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        audio.loop = true;
        audio.Play();
        sfxaudio=this.gameObject.AddComponent<AudioSource>();
        sfxaudio.clip=sfxClip;
        sfxaudio.volume =  PlayerPrefs.GetFloat("SfxVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        sfxaudio.loop=false;
    }
    public void sort()
    {
                Unlock_playerlist.Sort(delegate(SetPlayer A,SetPlayer B){
            if(A.Player_num>B.Player_num) return 1;
            else if(A.Player_num<B.Player_num) return -1;
            return 0;
        });
        Debug.Log("리스트 갯수 :"+Unlock_playerlist.Count);
        //정렬 테스트 
        for(int i=0;i<Unlock_playerlist.Count;i++)
        Debug.Log(Unlock_playerlist[i].Player_num);
    }
    public void GoIngame(int i)
    {
        sfxaudio.Play();
        switch (i)
        {
            case 666:
            if(PlayerPrefs.HasKey("Stage_Num" + i))
                LoadingSceneManager.LoadScene("Hellsight");
            else
            {
                buyCon_.BuyContentsInit(3000,"Stage_Num666");
            }
                break;
            case 999:
                LoadingSceneManager.LoadScene("endless");
                break;

            default:
            if(i==StageCode)
             {if(i==1||PlayerPrefs.HasKey("Stage_Num" + i))
                {
                    string map = "stage";
                    PlayerPrefs.SetInt("noWStage", i - 1);
                    LoadingSceneManager.LoadScene(map);
                }}
                break;
        }
    }
    void Option()
    {
        audio.volume = PlayerPrefs.GetFloat("BgmVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        sfxaudio.volume =  PlayerPrefs.GetFloat("SfxVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        PlayerPrefs.SetFloat("MasterVoluim", Master.value);
        PlayerPrefs.SetFloat("SfxVoluim", Sfx.value);
        PlayerPrefs.SetFloat("BgmVoluim", Bgm.value);
    }
    // Update is called once per frame
    bool isReset = false;
    bool isCredit = false;
    public void Reset(bool reset)
    {
        sfxaudio.Play();
        if (!reset)
            isReset = true;
        else
            isCredit = true;
    }
    public void closeCredit()
    {
        sfxaudio.Play();
        isCredit=false;
    }
    public void Reset_true(bool isyes=false)
    {
        if (isyes)
            DataDelete();
        else
            isReset = false;
    }
    float elastic = 0;
    float C_elastic = 0;
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
            if (isCredit)
            {
                if (C_elastic < 1)
                    C_elastic += 0.015f;
            }
            else
            {
                  if (C_elastic >= 0)
                    C_elastic -= 0.03f;
            }
            resetWaring.transform.localScale = new Vector3(moveElastic(elastic), moveElastic(elastic));
            creditPanel.transform.localScale = new Vector3(moveElastic(C_elastic), moveElastic(C_elastic));
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
    void OnDestroy()
    {
        Unlock_playerlist.Clear();
        Debug.Log("리스트 클리어! 리스트 노드 수 : "+Unlock_playerlist.Count);
    }
}
