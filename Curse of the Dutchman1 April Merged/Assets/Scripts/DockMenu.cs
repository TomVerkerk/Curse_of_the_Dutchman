using UnityEngine;
using System.Collections;

public class DockMenu : MonoBehaviour {

	public GUITexture fader;
	public float fadeSpeed;
	public GUITexture backTex;
	public GUITexture supplyTex;
	public GUITexture dockMessageTex;
	public GUITexture tradeTex;
	public GUITexture ammoSuppl1;
	public GUITexture ammoSuppl2;
	public GUITexture supplAmmo;
	public GUITexture statsUI;
	public GUIText dockText1;
	public GUIText dockText2;
	public GUIText dockText3;
	public GUIText dockText4;
	public GUIText dockTradeText;
	public string level;
	public AudioSource plunderSound;
	public AudioSource buttonClick;

	private float pos = 1;
	private bool loose = false;
	private bool back = false;
	private bool supplied = false;
	private float supplies;
	private float dockTut;
	private bool trade = false;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat("dock",1);
		dockTradeText.enabled = false;
		ammoSuppl1.enabled = false;
		ammoSuppl2.enabled = false;
		supplAmmo.enabled = false;
		dockMessageTex.enabled = false;
		dockText1.enabled = false;
		dockText2.enabled = false;
		dockText3.enabled = false;
		dockText4.enabled = false;
		statsUI.enabled = false;
		PlayerPrefs.SetFloat("supplied",0);
		PlayerPrefs.SetString("level", "dock");
		dockTut = PlayerPrefs.GetFloat("dockTut");
		PlayerPrefs.SetFloat("docked" , 1);
		PlayerPrefs.SetFloat("sails", 0);
		PlayerPrefs.SetFloat("movementSpeed", 0);
		supplies = PlayerPrefs.GetFloat("supplies");
		fader.color = Color.black;
		fader.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		backTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f);
		supplyTex.pixelInset = new Rect(Screen.width*0.05f,Screen.height*0.8f,Screen.width*0.3f,Screen.height*0.15f);
		tradeTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.8f,Screen.width*0.3f,Screen.height*0.15f);
		dockMessageTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.3f);
		ammoSuppl1.pixelInset = new Rect(Screen.width*0.05f, Screen.height*0.6f,Screen.width*0.22f,Screen.height*0.35f);
		ammoSuppl2.pixelInset = new Rect(Screen.width*0.39f, Screen.height*0.6f,Screen.width*0.22f,Screen.height*0.35f);
		supplAmmo.pixelInset = new Rect(Screen.width*0.74f, Screen.height*0.6f,Screen.width*0.22f,Screen.height*0.35f);
		dockText1.text = "You've entered a harbour.";
		dockText2.text = "Here you can trade your supplies for ammo.\nAnd your ammo for new supplies.";
		dockText3.text = "You can also plunder the harbour for supplies,\nThis may cost one of your pirates.";
		dockText4.text = "Youve plundered the harbour.";
		dockTradeText.text = "  1 Ammo                    10 Ammo                     10 Supply\n    for                          for                          for\n10 Supplies                 100 Supplies                    1 Ammo";
		dockText1.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.6f);
		dockText2.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.62f);
		dockText3.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.62f);
		dockText4.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.6f);
		dockTradeText.pixelOffset = new Vector2(Screen.width*0.09f,Screen.height*0.58f);
		dockText1.fontSize = Screen.width/22;
		dockText2.fontSize = Screen.width/32;
		dockText3.fontSize = Screen.width/32;
		dockText4.fontSize = Screen.width/21;
		dockTradeText.fontSize = Screen.width/30;
	}

	// Update is called once per frame
	void Update () {
		if(back == true)
		{
			fadeSpeed = 0.5f;
			FadeOut();
		}
		if(back == false)
		{
			FadeIn();
		}
		if(dockTut == 1 && pos <= 4){
			if(Input.touchCount > 0 && loose == false)
			{
				pos += 1;
				loose = true;
			}
			if(Input.touchCount == 0)
			{
				loose = false;
			}
			if(pos == 1)
			{
				dockMessageTex.enabled = true;
				dockText1.enabled = true;
			}
			if(pos == 2)
			{
				dockText1.enabled = false;
				dockText2.enabled = true;
			}
			if(pos == 3)
			{
				dockText2.enabled = false;
				dockText3.enabled = true;
			}
			if(pos == 4)
			{
				dockText3.enabled = false;
				dockMessageTex.enabled = false;
				PlayerPrefs.SetFloat("dockTut",0);
				dockTut = 0;
			}
		}
		if(supplied == true && Input.touchCount >= 1)
		{
			dockText4.enabled = false;
			dockMessageTex.enabled = false;
		}
	}

	void OnGUI(){
		GUI.color = Color.clear;
		if(dockTut == 0)
		{
			if(GUI.Button(new Rect(Screen.width*0.65f,Screen.height*0.8f,Screen.width*0.3f,Screen.height*0.15f),""))
			{
				//back
				buttonClick.Play();
				PlayerPrefs.SetFloat("supplies", supplies);
				back = true;
			}
			if(GUI.Button(new Rect(Screen.width*0.65f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f),"") && supplied == false)
			{
				//trade
				buttonClick.Play();
				supplyTex.enabled = false;
				tradeTex.enabled = false;
				trade = true;
				supplAmmo.enabled = true;
				ammoSuppl1.enabled = true;
				ammoSuppl2.enabled = true;
				dockTradeText.enabled = true;
			}
			if(GUI.Button(new Rect(Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f),"") && supplied == false && trade == false && PlayerPrefs.GetFloat("supplied") == 0)
			{
				//plunder
				buttonClick.Play();
				supplies = supplies + (15 + Mathf.Round(Random.value*20));
				tradeTex.color = tradeTex.color*0.7f;
				supplyTex.color = supplyTex.color*0.7f;
				dockText4.enabled = true;
				dockMessageTex.enabled = true;
				// display message
				plunderSound.Play ();
				PlayerPrefs.SetFloat("supplied",1);
				supplied = true;
			}
			if(trade == true)
			{
				//trade screen
				if(GUI.Button(new Rect(Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),""))
				{
					buttonClick.Play();
					Debug.Log("supplies1");
				}
				if(GUI.Button(new Rect(Screen.width*0.39f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),""))
				{
					buttonClick.Play();
					Debug.Log("supplies2");
				}
				if(GUI.Button(new Rect(Screen.width*0.74f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),""))
				{
					buttonClick.Play();
					Debug.Log("supplies3");
				}
			}
		}
	}

	void FadeOut(){
		fader.color = Color.Lerp(fader.color, Color.black, fadeSpeed * Time.deltaTime);
		if(fader.color.a >= 0.7)
		{
			PlayerPrefs.SetString("level", level);
			Application.LoadLevel(level);
		}
	}

	void FadeIn(){
		fadeSpeed += 0.05f;
		fader.color = Color.Lerp(fader.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
}
