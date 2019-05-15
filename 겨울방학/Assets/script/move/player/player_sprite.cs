using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sprite : MonoBehaviour
{
    public LinkedList<player_spritechild> Childs;
    // Start is called before the first frame update
    void Start()
    {
        Childs=new LinkedList<player_spritechild>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
