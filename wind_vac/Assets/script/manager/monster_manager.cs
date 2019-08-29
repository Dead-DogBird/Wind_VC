using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monster_manager : MonoBehaviour
{



    public new AudioSource audio;

    public AudioClip fireSound;
    public AudioClip hitMonster;
    public float volume;
    public bool isHit;
    public float firebombCount, hitbombCount;
    public GameObject EffectText;
    public static monster_manager Instance = null;
    public LinkedList<monster_parents> monsterList;
    public GameObject bossMonster;
    public GameObject[] Monster = new GameObject[3];
    public float nextfireQ, firerateQ = 15f;
    public move_player player;
    public bool isDead;
    public int combo;
    public int wave, boss_wave;

    public GameObject hit_effect;
    public wave_start wave_start_;
    public GameObject coin;
    GameObject instanceBoss;
    public int SumonTime = 2;
    public mapInfo mapinfo_; 
    void OnEnable()
    {
       // player = GameObject.Find("player").GetComponent<move_player>();
        wave_start_ = wave_start_.transform.GetComponent<wave_start>();
        if((mapinfo_=GetComponent<mapInfo>())!=null)
        {
            Monster=mapinfo_.MapMonster[PlayerPrefs.GetInt("noWStage")].Monster;
            bossMonster=mapinfo_.MapBoss[PlayerPrefs.GetInt("noWStage")];
            boss_wave=mapinfo_.Wave[PlayerPrefs.GetInt("noWStage")];
           // Instantiate(mapinfo_.Map[PlayerPrefs.GetInt("noWStage")],new Vector3(0,0,0),Quaternion.identity);
        }
    

    }
    public void pressButton(int dir)
    {
        if (player != null)
        {
            player.GetComponent<fire_bomb>().isActive = true;
            player.GetComponent<fire_bomb>().Dir = dir;
        }
    }
    public void unpressButtom()
    {
        if (player != null)
            player.GetComponent<fire_bomb>().isActive = false;
    }
    public void Jump()
    {
        if (player != null)
            player.canJump = true;
    }
    public void disJump()
    {
        if (player != null)
            player.canJump = false;
    }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Use this for initialization
    float TnextfireQ, TfirelateQ;
    public Text leftWave;
    public GameObject waringMark;
    public GameObject skipButton;
    Vector3 skipPosition;
    float oriY;
    bool isSkip;
    void Start()
    {
        monsterList = new LinkedList<monster_parents>();
        audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.fireSound;
        audio.volume = PlayerPrefs.GetFloat("SfxVoluim") * PlayerPrefs.GetFloat("MasterVoluim");
        nextfireQ = Time.time + 10;
        TfirelateQ = firerateQ + 1f;
        TnextfireQ = nextfireQ + 1f;
        wave = 0;
     
     
        skipPosition=skipButton.transform.localPosition;
        oriY=skipPosition.y;
    }
    bool SkipActive()
    {
        if(monsterList.Count == 0)
        return true;
        else
        return false;
    }
    public void Skip()
    {
        nextfireQ=Time.time;
    }
    void nextWave(bool boss = false)
    {
        wave++;
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 6f, 3f, 10);
        wave_start_.is_startWave = true;
        if (wave == boss_wave)
        {
            sumBoss();
            wave_start_.lateTime = Time.time + wave_start_.lateQ + 1;
        }
        else
        {
            wave_start_.lateTime = Time.time + wave_start_.lateQ;
        }
        if (leftWave != null)
            leftWave.text = (wave == boss_wave) ? "보스등장!" : "보스까지 " + (boss_wave - wave) + "웨이브 남았습니다! 현재 " + wave + "웨이브.";
        trueNextWave(boss);
        nextfireQ = Time.time + firerateQ;
    }
    public Vector3 RandomCircle(Vector3 center, float radius, float a)
    {

        float ang = a;

        Vector3 pos = new Vector3(0, 0, 0);

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);

        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);

        return pos;

    }
    void trueNextWave(bool boss = false)
    {
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 0, 1.5f, 5);
        SumonTime = (wave <= 7) ? wave * 2 : 7 + (wave - 7) / 3;
        if (!boss)
        {
            for (int i = 0; i < SumonTime; i++)
            {
                GameObject temp = Instantiate(waringMark, RandomCircle(player.transform.position, 10, Random.Range(0, 360)), Quaternion.identity);
                temp = temp.GetComponent<waringmark>().monster = Monster[Random.Range(0, Monster.Length)];
            }
        }
        if (boss && !wave_start_.is_startWave)
            wave = boss_wave + 1;
    }
    void sumBoss()
    {
        Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 0, 1.5f, 5);
        GameObject temp = Instantiate(bossMonster);
        temp.transform.position = RandomCircle(player.transform.position, 10, Random.Range(0, 360));
        instanceBoss = temp;
    }
    public bool isClear;
    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            if (wave < boss_wave)
            {
                if (Time.time > nextfireQ)
                {
                    nextWave();
                }
            }
            else if (wave == boss_wave)
            {
                if (Time.time > nextfireQ)
                {
                    nextWave(true);
                }
                if (instanceBoss != null || isClear)
                {
                    nextfireQ = Time.time + 1;
                    TnextfireQ = Time.time + 1;
                }
            }
            if (wave >= boss_wave && Time.time > wave_start_.lateTime + 1)
            {
                if (instanceBoss == null)
                    isClear = true;

            }
            if (isClear || player == null)
            {
                Time.timeScale += (0 - Time.timeScale) / 20;
            }
            if (isHit)
            {
                // if (monsterList.Count != 0)
                // {
                //     foreach (var item in monsterList)
                //     {
                //         item.Doknockback(item.transform.position, player.transform.position, 7.5f);
                //     }
                // }
                isHit = false;
            }

        }
        if (isDead)
        {
            audio.Play();
            isDead = false;
        }
        
        if(!SkipActive())skipPosition.y+=(700-skipPosition.y)*0.1f;
        else skipPosition.y+=(oriY-skipPosition.y)*0.1f;

        skipButton.transform.localPosition=skipPosition;
    }
}
