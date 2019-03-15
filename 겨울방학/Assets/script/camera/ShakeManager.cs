using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeManager : MonoBehaviour {

    public float shake_x = 0;
    public float shake_y = 0;
    public float shake_dire = 0;
    public float size = 1;
    public float length = 15;
    Camera camera_main;
    float camera_size;
    GameObject player;
    private void Start()
    {
        camera_main = Camera.main;
        camera_size = camera_main.orthographicSize;
        player=GameObject.Find("player");
        Shake(0,0,0,1.5f,15);
    }

    void Update()
    {
        ShakeUpdate();
        if(player!=null)
        transform.position=player.transform.position-new Vector3(0,0,10);

    }

    public void Shake(float x=0,float y=0,float dire=0,float size=1,float length=10)
    {
        shake_x = x;
        shake_y = y;
        shake_dire = dire;
        this.size = size;
        this.length = length;
    }

    void ShakeUpdate()
    {
        camera_main.transform.position = new Vector3(Random.Range(-shake_x, shake_x), Random.Range(-shake_y, shake_y), -100);
        camera_main.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-shake_dire, shake_dire));
        camera_main.orthographicSize = camera_size * size;

        shake_x -= shake_x / length;
        shake_y -= shake_y / length;
        shake_dire -= shake_dire / length;
        size += (1 - size) / length;
    }
}
