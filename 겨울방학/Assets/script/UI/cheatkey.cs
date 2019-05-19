using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatkey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Onclick()
    {
        if (monster_manager.Instance.monsterList.Count != 0)
        {
            foreach (var temp in monster_manager.Instance.monsterList)
            {
                temp.Kill();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
