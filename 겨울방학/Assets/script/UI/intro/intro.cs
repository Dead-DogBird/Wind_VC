using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class intro : MonoBehaviour
{
    Vector3 toVec;
    float startTime;
    float pi = 3.14f;
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
    float moveBounce(float argument0)
    {
        var t = argument0;

        if (t < 1 / 2.75f)
        {
            return 7.5625f * t * t;
        }
        else if (t < 2f / 2.75f)
        {
            t -= 1.5f / 2.75f;
            return 7.5625f * t * t + 0.75f;
        }
        else if (t < 2.5f / 2.75f)
        {
            t -= 2.25f / 2.75f;
            return 7.5625f * t * t + 0.9375f;
        }
        else
        {
            t -= 2.625f / 2.75f;
            return 7.5625f * t * t + 0.984375f;
        }

    }
    // Update is called once per frame
    float t = 0.2f;
    float alpha=1;
    void Update()
    {
        if (GetTime() < 1.5f)
        {
            toVec.y += (0 - toVec.y) / 10;
        }
        transform.localScale = new Vector3(moveElastic(t), moveElastic(t));
        if (GetTime() >= 3.5f)
        {
            toVec.y += (600 - toVec.y) / 20;
            transform.localScale = new Vector3(1, 1);
            transform.GetComponent<Image>().color=new Color(1,1,1,alpha);
            alpha+=(0-alpha)/30;
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
