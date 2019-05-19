using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_ui : MonoBehaviour
{
    Vector3 shopUi;
    // Start is called before the first frame update
    void Start()
    {
        shopUi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_manager.Instance.shop_touch != false)
        {
            shopUi.y += (0 - shopUi.y) / 10;
        }
        else
        {
            shopUi.y += (1200 - shopUi.y) / 10;
        }
        shopUi.x = 0;
        transform.localPosition = shopUi;

    }
}
