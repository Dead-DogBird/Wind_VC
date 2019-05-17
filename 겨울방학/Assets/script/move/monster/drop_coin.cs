using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_coin : MonoBehaviour
{
    move_player player;
    public GameObject paticle;
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
            Vector3 temp=new Vector3(transform.position.x+Random.Range(-0.5f,0.5f),transform.position.y+Random.Range(-0.5f,0.5f));
            Instantiate(paticle,temp,Quaternion.Euler(0, 0,0));
            ksound_manager.Instance.get=true;
            Destroy(gameObject);
        }
    }
}
