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
	public GUITexture dockStatsTex;
	public GUIText dockSupplies;
	public GUIText dockAmmo;
	public GUIText dockText1;
	public GUIText dockText2;
	public GUIText dockText3;
	public GUIText dockText4;
	public GUIText dockTradeText1;
	public GUIText dockTradeText2;
	public GUIText dockTradeText3;
	public string level;
	public AudioSource plunderSound;
	public AudioSource buttonClick;

	private float pirates;
	private float ammo;
	private float pos = 1;
	private bool loose = false;
	private bool back = false;
	private bool supplied = false;
	private float supplies;
	private float dockTut;
	private bool trade = false;

	// Use this for initialization
	void Start () {
		pirates = PlayerPrefs.GetFloat("pirates");
		PlayerPrefs.SetFloat("dock",1);
		dockStatsTex.enabled = true;
		dockTradeText1.enabled = false;
		dockTradeText2.enabled = false;
		dockTradeText3.enabled = false;
		ammoSuppl1.enabled = false;
		ammoSuppl2.enabled = false;
		supplAmmo.enabled = false;
		dockMessageTex.enabled = false;
		dockText1.enabled = false;
		dockText2.enabled = false;
		dockText3.enabled = false;
		dockText4.enabled = false;
		statsUI.enabled = false;
		dockSupplies.enabled = true;
		dockAmmo.enabled = true;
		PlayerPrefs.SetFloat("supplied",0);
		PlayerPrefs.SetString("level", "dock");
		dockTut = PlayerPrefs.GetFloat("dockTut");
		PlayerPrefs.SetFloat("docked" , 1);
		PlayerPrefs.SetFloat("sails", 0);
		PlayerPrefs.SetFloat("movementSpeed", 0);
		fader.color = Color.black;
		dockStatsTex.pixelInset = new Rect(Screen.width*0.08f,Screen.height*0.175f,Screen.width*0.35f,Screen.height*0.18f);
		dockStatsTex.color = dockStatsTex.color*1.4f;
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
		dockTradeText1.text = " 1 Ammo\n   for\n10 Supplies";
		dockTradeText2.text = " 10 Ammo\n   for\n100 Supplies";
		dockTradeText3.text = "10 Supplies\n   for\n 1 Ammo";
		dockText1.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.6f);
		dockText2.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.62f);
		dockText3.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.62f);
		dockText4.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.6f);
		dockSupplies.pixelOffset = new Vector2(Screen.width*0.1f,Screen.height*0.3f);
		dockAmmo.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.3f);
		dockTradeText1.pixelOffset = new Vector2(Screen.width*0.09f,Screen.height*0.58f);
		dockTradeText2.pixelOffset = new Vector2(Screen.width*0.44f,Screen.height*0.58f);
		dockTradeText3.pixelOffset = new Vector2(Screen.width*0.8f,Screen.height*0.58f);
		dockText1.fontSize = Screen.width/22;
		dockText2.fontSize = Screen.width/32;
		dockText3.fontSize = Screen.width/32;
		dockText4.fontSize = Screen.width/21;
		dockSupplies.fontSize = Screen.width/30;
		dockAmmo.fontSize = Screen.width/30;
		dockTradeText1.fontSize = Screen.width/30;
		dockTradeText2.fontSize = Screen.width/30;
		dockTradeText3.fontSize = Screen.width/30;
	}

	// Update is called once per frame
	void Update () {
		supplies = PlayerPrefs.GetFloat("supplies");
		ammo = PlayerPrefs.GetFloat("ammo");
		dockSupplies.text = "Supplies: "+supplies.ToString();
		dockAmmo.text = "Ammo: "+ammo.ToString();
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
				dockTradeText1.enabled = true;
				dockTradeText2.enabled = true;
				dockTradeText3.enabled = true;
			}
			if(GUI.Button(new Rect(Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f),"") && supplied == false && trade == false && PlayerPrefs.GetFloat("supplied") == 0)
			{
				//plunder
				buttonClick.Play();
				supplies = supplies + (2 + Mathf.Round(Random.value*5));
				tradeTex.color = tradeTex.color*0.7f;
				supplyTex.color = supplyTex.color*0.7f;
				dockText4.enabled = true;
				dockMessageTex.enabled = true;
				plunderSound.Play ();
				if(Random.value>0.6f)
				{
					PlayerPrefs.SetFloat("pirates", pirates-1);
				}
				PlayerPrefs.SetFloat("supplied",1);
				PlayerPrefs.SetFloat("pirates", pirates);
				PlayerPrefs.SetFloat("supplies",supplies);
				supplied = true;
			}
			if(trade == true)
			{
				//trade screen
				if(GUI.Button(new Rect(Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),"") && ammo >= 1)
				{
					buttonClick.Play();
					ammo -= 1;
					supplies += 10;
					PlayerPrefs.SetFloat("supplies",supplies);
					PlayerPrefs.SetFloat("ammo",ammo);
				}
				if(GUI.Button(new Rect(Screen.width*0.39f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),"") && ammo >= 10)
				{
					buttonClick.Play();
					ammo -= 10;
					supplies += 100;
					PlayerPrefs.SetFloat("supplies",supplies);
					PlayerPrefs.SetFloat("ammo",ammo);
				}
				if(GUI.Button(new Rect(Screen.width*0.74f,Screen.height*0.05f,Screen.width*0.22f,Screen.height*0.35f),"")&& supplies >= 1)
				{
					buttonClick.Play();
					supplies -= 10;
					ammo += 1;
					PlayerPrefs.SetFloat("supplies",supplies);
					PlayerPrefs.SetFloat("ammo",ammo);
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
