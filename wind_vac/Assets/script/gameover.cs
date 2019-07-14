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
    void Start()
    {
        //        myText = myText.gameObject.GetComponent<Text>();
        player = monster_manager.Instance.player;
        myImage = gameObject.GetComponent<Image>();
        myText.color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || SceneManager.GetActiveScene().name == "endless")
        {
            myText.text = "Game Over!";
        }

        if (monster_manager.Instance.isClear && SceneManager.GetActiveScene().name != "endless")
        {
            myText.text = "Game Clear!";
        }
    }
    public void GoToMain()
    {
        LoadingSceneManager.LoadScene("mainmenu");
        Time.timeScale = 1;
    }

    public void Retry() { LoadingSceneManager.LoadScene(SceneManager.GetActiveScene().name); Time.timeScale = 1; }
}
