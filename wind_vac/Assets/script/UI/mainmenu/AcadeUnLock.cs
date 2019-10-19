using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AcadeUnLock : MonoBehaviour
{
    public Text acadeName,acadeInfo;
    public int acadeCode;
    public string OriName,OriInfo;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(path))
        {
            acadeName.text=OriName;
            acadeInfo.text=OriInfo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
