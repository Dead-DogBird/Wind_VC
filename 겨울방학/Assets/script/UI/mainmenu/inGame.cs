using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class inGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GOingame()
    {
           SceneManager.LoadScene("stage1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
