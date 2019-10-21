using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_skill : MonoBehaviour
{
    public int playerType;
    public fire_bomb player;
    public float fireLate,nextFire;
    public GameObject realButton;
    Image myImage;
    // Start is called before the first frame update
    void Start()
    {
        playerType = PlayerPrefs.GetInt("PlayerType");
        player = monster_manager.Instance.player.GetComponent<fire_bomb>();
        myImage = realButton.GetComponent<Image>();
        switch(playerType)
        {
            case 0:
            nextFire=5;
            break;
            case 1:
            nextFire=8;
            break;
        }
    }
    void Update()
    {
        //myImage.fillAmount=2;
        myImage.fillAmount=((Time.time-fireLate)/nextFire)+1;
    }
    void skill_0()
    {
        for (int i = 0; i < 4; i++)
            player.returnActiveObject(i);

        fireLate = Time.time + nextFire;
    }
    void skill_1()
    {
        fireLate = Time.time + nextFire;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(player.Bomb.GetComponent<bomb_boom>().effect, new Vector3(player.transform.position.x + ((-(5 / 2) + i) * 3), player.transform.position.y), Quaternion.Euler(0, 0, Random.Range(220, 120)));
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(player.Bomb.GetComponent<bomb_boom>().effect, new Vector3(player.transform.position.x, player.transform.position.y + ((-(5 / 2) + i)) * 3), Quaternion.Euler(0, 0, Random.Range(220, 120)));
        }
    }

    public void SKILL()
    {
        if (fireLate < Time.time)
        {
            switch (playerType)
            {
                case 0:
                    skill_0();
                    break;
                case 1:
                    skill_1();
                    break;
            }
            Camera.main.GetComponent<ShakeManager>().Shake(0, 5, 5, 1.2f, 10);
        }
    }
}
