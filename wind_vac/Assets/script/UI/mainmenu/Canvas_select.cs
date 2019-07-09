using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_select : MonoBehaviour
{
    public int CanvasCode;
    public int StageCode=1,maxNum;
    public static Canvas_select Instance = null;
    public void ToStage(bool isUp)
    {
        if(isUp&&StageCode+1<=maxNum)
        {
            StageCode++;
        }
        if(!isUp&&StageCode-1>=1)
        {
            StageCode--;
        }
    }
    public void toCanvas(int num)
    {
        CanvasCode = num;
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void GoIngame(int i)
    {
        if (i == 999)
        {
            LoadingSceneManager.LoadScene("endless");
        }
        else
        {
            string map = "stage" + i;
            LoadingSceneManager.LoadScene(map);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
