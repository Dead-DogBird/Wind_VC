using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom_effect_shadow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player_stats player=monster_manager.Instance.player.GetComponent<player_stats>();
        transform.localScale += new Vector3(player.extent, player.extent);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.localScale += new Vector3(0.075f, 0.075f, 0);
        Destroy(gameObject, 0.3f);
    }
}
