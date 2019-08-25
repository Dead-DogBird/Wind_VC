using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour
{
    move_player player;
    public Text myText;
    float nextfire, firelate = 0.4f;
    Image myImage;
    Vector3 Mytransform;
    public delegate void tempOver();
    public tempOver TempOverMethod;
    void Start()
    {
        //        myText = myText.gameObject.GetComponent<Text>();
        TempOverMethod = delegate ()
        {
            if (player == null || SceneManager.GetActiveScene().name == "endless")
            {
                myText.text = "Game Over!";
            }

            if (monster_manager.Instance.isClear && SceneManager.GetActiveScene().name != "endless")
            {
                myText.text = "Game Clear!";
            }
        };
        player = monster_manager.Instance.player;
        myImage = gameObject.GetComponent<Image>();
        myText.color = new Color(1, 1, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void GoToMain()
    {
        //Debug.Log(Game_manager.Instance.StageCode + 1+"번 잠금 해제됨!");
        if (!PlayerPrefs.HasKey("Stage_Num" +(Game_manager.Instance.StageCode + 1)) && myText.text == "Game Clear!"&&Game_manager.Instance.NowWhatMode==Game_manager.gameMode.stageMode)
        {
            PlayerPrefs.SetInt("Stage_Num" + (Game_manager.Instance.StageCode + 1), 1);
            Debug.Log(PlayerPrefs.HasKey("Stage_Num" + Game_manager.Instance.StageCode + 1) + " 이렇게 됨!");
        }
        LoadingSceneManager.LoadScene("mainmenu");
        Time.timeScale = 1;
    }

    public void Retry() { LoadingSceneManager.LoadScene(SceneManager.GetActiveScene().name); Time.timeScale = 1; }
}
