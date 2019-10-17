using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyContents : MonoBehaviour
{
    float pi=3.14f;
    float elastic = 0;
    public Text priceText,playermoney;
    public int price;
    public bool isActive=false;
    public string path;
    float moveElastic(float num)
    {
        float argument0 = num;
        if (argument0 <= 0)
            return 0;
        else if (argument0 >= 1)
            return 1;

        float p = 0.3f;
        float s = p / 4;

        return Mathf.Pow(2, -10 * argument0) * Mathf.Sin((argument0 - s) * (2 * pi) / p) + 1;
    }
    public void BuyContentsInit(int price_,string path_)
    {
        isActive=true;
        price=price_;
        priceText.text=price.ToString();
        path=path_;
        playermoney.text="현재 보유 :"+Canvas_select.Instance.playermoney.ToString();
    } 
    public void what_button(bool isNegative)
    {
        if(!isNegative)
        {
            if(Canvas_select.Instance.playermoney>price)
            {
                PlayerPrefs.SetInt(path,1);
                Canvas_select.Instance.playermoney-=price;
                Canvas_select.Instance.PlayerMoneyText.text=Canvas_select.Instance.playermoney.ToString();
            }
            else
            {
                return;
            }
        }
        isActive=false;
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale=new Vector3(0,0,0);    
        Canvas_select.Instance.buyCon_=this;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive)
        {
            if (elastic < 1)
                    elastic += 0.015f;
        }
        else
        {
            if (elastic >= 0)
                    elastic -= 0.03f;
        }
        transform.localScale = new Vector3(moveElastic(elastic), moveElastic(elastic));
    }
}
