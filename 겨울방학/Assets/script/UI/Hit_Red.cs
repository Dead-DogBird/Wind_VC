using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hit_Red : MonoBehaviour
{
    new SpriteRenderer renderer;
    public float hitcolor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (monster_manager.Instance.player != null)
        {
            hitcolor -= hitcolor / 20;
        }
        else
        {
             if( Input.GetMouseButton(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        renderer.color = new Color(1, 1, 1, hitcolor);


    }
}
