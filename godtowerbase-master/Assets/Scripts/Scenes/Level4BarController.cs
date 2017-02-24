using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4BarController : MonoBehaviour {

    private Image image;
    private Color imageOriginalColor;

    void Awake()
    {
        image = GetComponent<Image>();
        imageOriginalColor = image.color;
    }

	public void OnMouseEnter() {
        image.color = Color.clear;
		
	}
	
    public void OnMouseExit(){
        image.color = Color.yellow; //ảnh vẫn màu vàng vì white ở đây là maximum các màu cơ bản (ảnh ko bị sửa)
		
	}
}
