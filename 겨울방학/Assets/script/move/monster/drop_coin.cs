using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_coin : MonoBehaviour
{
    move_player player;
    // Start is called before the first frame update
    void Start()
    {
        player=monster_manager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=(player.transform.position-transform.position)/10;
        if(Vector3.Distance(player.transform.position, transform.position)<1f)
        {
            ksound_manager.Instance.get=true;
            Destroy(gameObject);
        }
    }
}
