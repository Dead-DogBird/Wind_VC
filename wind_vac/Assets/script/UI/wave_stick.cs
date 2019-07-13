using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class wave_stick : MonoBehaviour
{
    float x;
    Image myImage;
    // Start is called before the first frame update
    void Start()
    {
      x=transform.localScale.x;
        myImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       if(monster_manager.Instance.player!=null&&!monster_manager.Instance.isClear)
       myImage.fillAmount= ((monster_manager.Instance.nextfireQ - Time.time) / monster_manager.Instance.firerateQ);
       // transform.localScale=new Vector3((,1);
    }
}
