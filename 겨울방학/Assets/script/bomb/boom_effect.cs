using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom_effect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
 
       // Camera.main.GetComponent<ShakeManager>().Shake(0.3f, 0.3f, 0, 0.9f, 10);
        player_stats player=monster_manager.Instance.player.GetComponent<player_stats>();
        transform.localScale += new Vector3(player.extent, player.extent);
        BoxCollider2D box_collider = transform.GetComponent<BoxCollider2D>();//컴포넌트를 얻어옴
        box_collider.enabled = false;//자신 충돌 체크 꺼줌
       // transform.localScale+=new Vector3(player.extent,player.extent);
        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position + new Vector3(box_collider.offset.x, box_collider.offset.y),
         new Vector2(box_collider.size.x * transform.localScale.x, box_collider.size.y * transform.localScale.y), 0, 1 << 8);//충돌  정보를 얻어옴
        if (hit != null)
        {
            foreach (Collider2D i in hit)
            {
                if (i.tag == "monster")
                {
                    i.GetComponent<monster_parents>().hp -= 1f+player.attack;
                    i.GetComponent<monster_parents>().Doknockback(i.transform.position, transform.position, 5f);
                    i.GetComponent<monster_parents>().hitcolor = 20;
                    i.GetComponent<monster_parents>().audio.Play();

                    Instantiate(monster_manager.Instance.hit_effect, i.GetComponent<monster_parents>().transform.position+new Vector3(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f)),Quaternion.identity);
                    
                    EffectFont text = Instantiate(monster_manager.Instance.EffectText, i.GetComponent<monster_parents>().transform.position, Quaternion.identity).GetComponent<EffectFont>();
                    text.fwspeed=Random.Range(-0.05f,0.05f);

                        if(i.GetComponent<monster_parents>().hp==0)
                        text.effectText = "처치!";
                        else
                        text.effectText = "-"+(player.attack+1)*10;
                         
                }
            }
        }
        box_collider.enabled = true;//다시 자신의 충돌 체크를 켜줌		
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.075f, 0.075f, 0);
        Destroy(gameObject, 0.3f);
    }
}
