using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUITexture menu;
	public GUITexture creditsTex;
	public GUITexture winTex;
	public GUITexture fader;
	public GUIText tutorial;
	public GUIText tutorialCheck;
	public GUIText intro;
	public GUIText introCheck;
	public float fadeSpeed;
	public string nextLevel;
	public AudioSource buttonClick;

	private bool introBool = true;
	private bool seen = false;
	private bool tutorialBool = true;
	private bool win = false;
	private bool credits = false;
	private bool startGame = false;
	private bool loadGame = false;
	private bool start = true;

	void Start(){
		tutorial.text = "Tutorial:";
		tutorialCheck.text = "Tutorial: *";
		intro.text = "Intro:";
		introCheck.text = "Intro: *";
		tutorialCheck.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.07f);
		tutorialCheck.fontSize = Screen.width/35;
		tutorial.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.07f);
		tutorial.fontSize = Screen.width/35;
		intro.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.15f);
		intro.fontSize = Screen.width/35;
		introCheck.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.15f);
		introCheck.fontSize = Screen.width/35;
		if(PlayerPrefs.GetFloat("win") == 1)
		{
			winTex.pixelInset = new Rect(0,0,Screen.width,Screen.height);
			win = true;
			winTex.enabled = true;
		}
		else
		{
			winTex.enabled = false;
			Menu();
		}
		tutorialCheck.enabled = true;
		introCheck.enabled = true;
		tutorial.enabled = false;
		intro.enabled = false;
	}

	void Menu()
	{
		menu.enabled = true;
		creditsTex.enabled = false;
		creditsTex.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		menu.pixelInset = new Rect(-Screen.width/68.3f,0,Screen.width,Screen.height);
		fader.color = Color.black;
		PlayerPrefs.SetFloat("docked" , 0);
		PlayerPrefs.SetFloat("sails", 0);
		PlayerPrefs.SetFloat("movementSpeed", 0);
	}

	void OnGUI()
	{
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(Screen.width * 0,
		                       Screen.height * 0.93f, 
		                       Screen.width * 0.2f, Screen.height * 0.07f),"")&& credits == false)
		{
			buttonClick.Play();
			if(tutorialBool == true)
			{
				tutorialBool = false;
			}
			else if(tutorialBool == false)
			{
				tutorialBool = true;
			}
		}
		if(GUI.Button(new Rect(Screen.width * 0,
		                       Screen.height * 0.84f, 
		                       Screen.width * 0.2f, Screen.height * 0.07f),"")&& credits == false)
		{
			buttonClick.Play();
			if(introBool == true)
			{
				introBool = false;
			}
			else if(introBool == false)
			{
				introBool = true;
			}
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.26f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),"")&& credits == false)
	    {
			//start game
			buttonClick.Play();
			if(tutorialBool == true)
			{
				PlayerPrefs.SetFloat("tutPos", 1);
				PlayerPrefs.SetFloat("dockTut", 1);
			}
			else if (tutorialBool == false)
			{
				PlayerPrefs.SetFloat("tutPos", 0);
				PlayerPrefs.SetFloat("dockTut", 0);
			}
			if(introBool == true)
			{
				PlayerPrefs.SetFloat("intro", 1);
			}
			else if(introBool == false)
			{
				PlayerPrefs.SetFloat("intro", 0);
			}
			PlayerPrefs.SetFloat("Skull",0);
			PlayerPrefs.SetFloat("first", 1);
			PlayerPrefs.SetFloat("enemy1Health", 2);
			PlayerPrefs.SetFloat("enemy2Health", 2);
			PlayerPrefs.SetFloat("enemy3Health", 2);
			PlayerPrefs.SetFloat("enemy4Health", 2);
			PlayerPrefs.SetFloat("enemy5Health", 2);
			PlayerPrefs.SetFloat("enemy6Health", 2);
			PlayerPrefs.SetFloat("drop1",0);
			PlayerPrefs.SetFloat("drop2",0);
			PlayerPrefs.SetFloat("drop3",0);
			PlayerPrefs.SetFloat("drop4",0);
			PlayerPrefs.SetFloat("drop5",0);
			PlayerPrefs.SetFloat("drop6",0);
			PlayerPrefs.SetFloat("drop7",0);
			PlayerPrefs.SetFloat("drop8",0);
			PlayerPrefs.SetFloat("drop9",0);
			PlayerPrefs.SetFloat("drop10",0);
			PlayerPrefs.SetFloat("drop11",0);
			PlayerPrefs.SetString("level", "Level1");
			PlayerPrefs.SetFloat("startGame", 1);
			PlayerPrefs.SetFloat("died",0);
			PlayerPrefs.SetFloat("statsOpen",0);
			PlayerPrefs.SetFloat("skullLevel",0);
			PlayerPrefs.SetFloat("suppliedLevel1",0);
			PlayerPrefs.SetFloat("suppliedLevel2",0);
			PlayerPrefs.SetFloat("suppliedLevel3",0);
			PlayerPrefs.SetFloat("suppliedLevel4",0);
			PlayerPrefs.SetFloat("suppliedLevel5",0);
			startGame = true;
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.43f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),"")&& PlayerPrefs.GetFloat("startGame") == 1 && PlayerPrefs.GetFloat("died") == 0 && credits == false)
		{
			//load game
			buttonClick.Play();
			PlayerPrefs.SetFloat("tutPos", 0);
			PlayerPrefs.SetFloat("dockTut", 0);
			PlayerPrefs.SetFloat("first", 0);
			PlayerPrefs.SetFloat("loadGame", 1);
			PlayerPrefs.SetFloat("Intro",0);
			loadGame = true;
			startGame = true;
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.61f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),"")&& seen == true)
		{
			//credits
			buttonClick.Play();
			credits = true;
			seen = false;
			menu.enabled = false;
			tutorial.enabled = false;
			tutorialCheck.enabled = false;
			intro.enabled = false;
			introCheck.enabled = false;
			creditsTex.enabled = true;
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.79f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),"")&& credits == false)
		{
			//quit
			buttonClick.Play();
			Application.Quit();
		}
	}

	void Update(){
		if(tutorialBool == true && credits == false)
		{
			tutorialCheck.enabled = true;
			tutorial.enabled = false;
		}
		if(tutorialBool == false && credits == false)
		{
			tutorial.enabled = true;
			tutorialCheck.enabled = false;
		}
		if(introBool == true && credits == false)
		{
			introCheck.enabled = true;
			intro.enabled = false;
		}
		if(introBool == false && credits == false)
		{
			intro.enabled = true;
			introCheck.enabled = false;
		}
		if(Input.touchCount == 0)
		{
			seen = true;
		}
		if(credits == true)
		{
			if(Input.GetKeyDown(KeyCode.Escape) || Input.touchCount >= 1 && seen == true)
			{
				tutorial.enabled = true;
				creditsTex.enabled = false;
				menu.enabled = true;
				seen = false;
				credits = false;
			}
		}
		if(win == true && Input.touchCount >= 1)
		{
			winTex.enabled = false;
			Menu();
			PlayerPrefs.SetFloat("win",0);
		}
		if(startGame == true)
		{
			fader.enabled = true;
			fader.color = Color.Lerp(fader.color, Color.black, fadeSpeed * Time.deltaTime);
			if(fader.color.a >= 0.5 && loadGame == false)
			{
				PlayerPrefs.SetFloat("dock", 0);
				Application.LoadLevel(nextLevel);
			}
			if(fader.color.a >= 0.5 && loadGame == true)
			{
				PlayerPrefs.SetFloat("dock",1);
				Application.LoadLevel(PlayerPrefs.GetString("level"));
			}
		}
		if(start == true)
		{
			fader.enabled = true;
			fader.color = Color.Lerp(fader.color, Color.clear, fadeSpeed * Time.deltaTime);
			if(fader.color.a <= 0.02)
			{
				fader.enabled = false;
				start = false;
			}
		}
	}
}
