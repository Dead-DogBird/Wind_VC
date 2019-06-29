using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChildManage : MonoBehaviour {

	TextMesh my_text;
	TextMesh[] textChilds = new TextMesh[8];

	void Start()
	{
		my_text = GetComponent<TextMesh>();
		for(int i = 0 ; i < 8 ; i ++)
		{
			textChilds[i] = transform.GetChild(i).GetComponent<TextMesh>();
		}
		
	}

	void Update()
	{
		foreach (var item in textChilds)
		{
			item.color = new Color(item.color.r,item.color.g,item.color.b,my_text.color.a);
			item.text = my_text.text;
		}
	}

	
}
