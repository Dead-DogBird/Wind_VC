using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
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
public class Canvas_select : MonoBehaviour
{
    public int CanvasCode;
    public int StageCode = 1, maxNum;
    public static Canvas_select Instance = null;
    public List<Stage_info> StageInfolist = new List<Stage_info>();
    public Text StageComent, StageName, StageNumber;
    public Slider Master, Bgm, Sfx;
    public GameObject Ship, Ship_Cloud;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void saveStageInfo()
    {
        StageInfolist.Add(new Stage_info(1, "하늘 간이역", "위대한 발견을 향한 여정의 시작 \n 모든것이 시작된다.(기차표 별도 구매)(배 무단 주차금지)"));
        StageInfolist.Add(new Stage_info(2, "스탠다드 하늘섬", "낮선 기류에 휩쓸려 도착한 곳은 \n 알수없는 하늘섬, 범상치 않다.(쓰레기 무단투기 금지)"));
        StageInfolist.Add(new Stage_info(3, "미스테리 사막유적", "작열하는 태양, 때때로의 야자수 \n 그리고 알수없는 사막의 고대유적.(낙서 금지)"));
        JsonData ShopJson = JsonMapper.ToJson(StageInfolist);

        File.WriteAllText(Application.dataPath + "/Resources/StageInfo.json", ShopJson.ToString());
        Debug.Log("저장됨!");
    }
    JsonData priceData;
    public void Load()
    {
        Debug.Log("불러오기");
        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/StageInfo.json");
        // Debug.Log(Jsonstring);
        priceData = JsonMapper.ToObject(Jsonstring);
        for (int i = 0; i < priceData.Count; i++)
        {
            Debug.Log(priceData[i]["StageName"].ToString());
        }
    }
    public void anotherLoad()
    {
        TextAsset test = Resources.Load("StageInfo") as TextAsset;
        string Jsonstring = test.text;
        priceData = JsonMapper.ToObject(Jsonstring);
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
    public void DataDelete()
    {
        PlayerPrefs.DeleteAll();
    }
    public void toCanvas(int num)
    {
        CanvasCode = num;
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
    // Start is called before the first frame update
    void Start()
    {
        //saveStageInfo();
        //Load();
        anotherLoad();
        SetsoundKey();
        ship_position = new Vector3(-2000, -150, 0);
        cloud_position = new Vector3(-2000, 0, 0);
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
                string map = "stage" + i;
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
    void Update()
    {


        if (CanvasCode == 3)
        {
            Option();
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
            if (cloud_position.x >= -901)
                cloud_position.x += (-901 - cloud_position.x) / 10;  
        }
        Ship.transform.localPosition = ship_position;
        Ship_Cloud.transform.localPosition = cloud_position;
    }
}
 