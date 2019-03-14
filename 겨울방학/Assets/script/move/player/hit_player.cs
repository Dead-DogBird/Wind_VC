using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_player : GameMaker
{
    public Vector3 knockback;
    public int hp=10;
    void hit()
    {
        
		BoxCollider2D box_collider = transform.GetComponent<BoxCollider2D>();//컴포넌트를 얻어옴
        box_collider.enabled = false;//자신 충돌 체크 꺼줌
		Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position + new Vector3(box_collider.offset.x, box_collider.offset.y),
         new Vector2(box_collider.size.x * transform.localScale.x, box_collider.size.y * transform.localScale.y), 0,1<<8);//충돌  정보를 얻어옴
        if (hit != null)
        {
			foreach (Collider2D i in hit)
            {	if(i.CompareTag("monster"))
            	Camera.main.GetComponent<ShakeManager>().Shake(0.3f,0.3f,0.2f,0.9f,10);
                Doknockback(transform.position,i.transform.position,0.2f);
                hp-=1;
            }
		}
		box_collider.enabled = true;//다시 자신의 충돌 체크를 켜줌		
    }
    public  void Doknockback(Vector3 po1,Vector3 po2,float length=0.1f)
    {
        knockback=-VectorRotation(PointDirection(po1,po2))*length;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        hit();    
        transform.position+=knockback;
        knockback-=knockback/10;
        if(hp<=0)
        Destroy(gameObject);
    }
}
