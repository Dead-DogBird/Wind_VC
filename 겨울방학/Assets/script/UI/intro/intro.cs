using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour
{
    Vector3 toVec;
    float startTime;
    float pi = 3.14f;
    bool nextScene=false;
    // Start is called before the first frame update
    void Start()
    {
        toVec = transform.localPosition;
        startTime = Time.time;
    }
    float GetTime()
    {
        return Time.time - startTime;
    }

    float moveElastic(float num)
    {
        float argument0 = num;
        if (argument0 == 0)
            return 0;
        else if (argument0 == 1)
            return 1;

        float p = 0.3f;
        float s = p / 4;

        return Mathf.Pow(2, -10 * argument0) * Mathf.Sin((argument0 - s) * (2 * pi) / p) + 1;
    }
    // Update is called once per frame
    float t = 0.2f;
    float alpha=1;
    void FixedUpdate()
    {
        if (GetTime() < 1.5f)
        {
            toVec.y += (0 - toVec.y) / 10;
        }
        transform.localScale = new Vector3(moveElastic(t), moveElastic(t));
        if (GetTime() >= 3.5f&&nextScene==false)
        {
            toVec.y += (600 - toVec.y) / 20;
            transform.localScale = new Vector3(1, 1);
            transform.GetComponent<Image>().color=new Color(1,1,1,alpha);
            alpha+=(0-alpha)/30;
            if(Input.GetMouseButton(0))
            {
                nextScene=true;
            }
        }
        else if(nextScene)
        {
            transform.GetComponent<Image>().color=new Color(1,1,1,alpha);
            alpha+=(1-alpha)/10;
            if(alpha>=0.99f)
            {
                LoadingSceneManager.LoadScene("mainmenu");
            }
        }

        if (t <= 1)
        {
            t += 0.012f;
        }
        else
        {
            t = 0.2f;
        }

        transform.localPosition = toVec;
    

    }
}
