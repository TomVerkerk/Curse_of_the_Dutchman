﻿using UnityEngine;
using System.Collections;

public class DropScript : MonoBehaviour {

	public GameData gameData;
	private float random;
	public GUIText skullText;
	public GUITexture messageTex;
	private bool show = false;
	
	private GameObject drop1;
	private GameObject drop2;
	private GameObject drop3;
	private GameObject drop4;
	private GameObject drop5;
	private GameObject drop6;
	private GameObject drop7;
	private GameObject drop8;
	private GameObject drop9;
	private GameObject drop10;
	private GameObject drop11;
	
	void Start(){
		if(PlayerPrefs.GetString("level") == "Level1")
		{
			drop1 = GameObject.FindGameObjectWithTag("drop1");
			drop2 = GameObject.FindGameObjectWithTag("drop2");
		}
		if(PlayerPrefs.GetString("level") == "Level2")
		{
			drop3 = GameObject.FindGameObjectWithTag("drop3");
		}
		if(PlayerPrefs.GetString("level") == "Level3")
		{
			drop4 = GameObject.FindGameObjectWithTag("drop4");
			drop5 = GameObject.FindGameObjectWithTag("drop5");
			drop6 = GameObject.FindGameObjectWithTag("drop6");
		}
		if(PlayerPrefs.GetString("level") == "Level4")
		{
			drop7 = GameObject.FindGameObjectWithTag("drop7");
			drop8 = GameObject.FindGameObjectWithTag("drop8");
			drop9 = GameObject.FindGameObjectWithTag("drop9");
		}
		if(PlayerPrefs.GetString("level") == "Level5")
		{
			drop10 = GameObject.FindGameObjectWithTag("drop10");
			drop11 = GameObject.FindGameObjectWithTag("drop11");
		}
		if(PlayerPrefs.GetFloat(this.gameObject.tag) == 1)
		{
			Destroy(this.gameObject);
		}
		skullText.enabled = false;
		messageTex.enabled = false;
		skullText.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.6f);
		skullText.text = "Youve found the skull!";
		skullText.fontSize = Screen.width/25;
		messageTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.3f);
	}

	void OnTriggerEnter(Collider col){
		if (col.name == "Player") {
			transform.position = new Vector3(transform.position.z,transform.position.y - 10,transform.position.z);
			random = 1 + Mathf.Round(Random.value*3);
			gameData.ChangeAmmo(random);
			random = Mathf.Round(Random.value*8);
			gameData.ChangeSupplies(random);
			PlayerPrefs.SetFloat(this.gameObject.tag,1);
			if(gameObject.tag == "Skull")
			{
				PlayerPrefs.SetFloat("Skull",1);
				skullText.enabled = true;
				messageTex.enabled = true;
				show = true;
			}
		}
	}
	void Update(){
		if(show = true && Input.touchCount >= 1)
		{
			skullText.enabled = false;
			messageTex.enabled = false;
			show = false;
		}
	}
}
