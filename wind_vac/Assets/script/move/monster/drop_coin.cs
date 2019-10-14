using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_coin : MonoBehaviour
{
    move_player player;
    public GameObject paticle;
    Vector3 tovec;
    float to = -2;
    // Start is called before the first frame update
    void Start()
    {
        player = monster_manager.Instance.player;
        tovec = transform.position;
        to = tovec.y - 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null && monster_manager.Instance.monsterList.Count == 0)
        {
            transform.position += (player.transform.position - transform.position) / 10;
        }
        else
        {
            tovec.y += (to - tovec.y) / 10;
            transform.position = tovec;
        }
        if (player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 1f)
            {
                Vector3 temp = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                Instantiate(paticle, temp, Quaternion.Euler(0, 0, 0));
                ksound_manager.Instance.get = true;
                Game_manager.Instance.giveMoney();
                Destroy(gameObject);
            }
        }
    }
}
