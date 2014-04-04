using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUITexture menu;
	public GUITexture creditsTex;
	public GUITexture winTex;
	public GUITexture fader;
	public GUIText tutorial;
	public GUIText tutorialCheck;
	public float fadeSpeed;
	public string nextLevel;
	public AudioSource buttonClick;

	private bool tutorialBool = true;
	private bool win = false;
	private bool credits = false;
	private bool startGame = false;
	private bool loadGame = false;
	private bool start = true;

	void Start(){
		tutorial.text = "Tutorial:";
		tutorialCheck.text = "Tutorial: *";
		tutorialCheck.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.07f);
		tutorialCheck.fontSize = Screen.width/35;
		tutorial.pixelOffset = new Vector2(Screen.width*0.02f,Screen.height*0.07f);
		tutorial.fontSize = Screen.width/30;
		tutorialCheck.fontSize = Screen.width/30;
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
		if(PlayerPrefs.GetFloat("menuTut")==0)
		{
			tutorialBool = false;
		}
		else if(PlayerPrefs.GetFloat("menuTut")==1)
		{
			tutorialBool = true;
		}
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
			if(tutorialBool == true)
			{
				tutorialBool = false;
			}
			else if(tutorialBool == false)
			{
				tutorialBool = true;
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
			PlayerPrefs.SetFloat("Skull",0);
			PlayerPrefs.SetFloat("first", 1);
			PlayerPrefs.SetFloat("enemy1Health", 2);
			PlayerPrefs.SetFloat("enemy2Health", 2);
			PlayerPrefs.SetFloat("enemy3Health", 2);
			PlayerPrefs.SetFloat("enemy4Health", 2);
			PlayerPrefs.SetFloat("enemy5Health", 2);
			PlayerPrefs.SetFloat("enemy6Health", 2);
			PlayerPrefs.SetFloat("dock1",0);
			PlayerPrefs.SetFloat("dock2",0);
			PlayerPrefs.SetFloat("dock3",0);
			PlayerPrefs.SetFloat("dock4",0);
			PlayerPrefs.SetFloat("dock5",0);
			PlayerPrefs.SetFloat("dock6",0);
			PlayerPrefs.SetFloat("dock7",0);
			PlayerPrefs.SetFloat("dock8",0);
			PlayerPrefs.SetFloat("dock9",0);
			PlayerPrefs.SetFloat("dock10",0);
			PlayerPrefs.SetFloat("dock11",0);
			PlayerPrefs.SetString("level", "level1");
			PlayerPrefs.SetFloat("startGame", 1);
			PlayerPrefs.SetFloat("died",0);
			PlayerPrefs.SetFloat("statsOpen",0);
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
			loadGame = true;
			startGame = true;
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.61f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),""))
		{
			//credits
			menu.enabled = false;
			tutorial.enabled = false;
			tutorialCheck.enabled = false;
			creditsTex.enabled = true;
			credits = true;
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
			PlayerPrefs.SetFloat("menuTut",1);
			tutorialCheck.enabled = true;
			tutorial.enabled = false;
		}
		if(tutorialBool == false && credits == false)
		{
			PlayerPrefs.SetFloat("menuTut",0);
			tutorial.enabled = true;
			tutorialCheck.enabled = false;
		}
		if(credits == true)
		{
			if(Input.GetKeyDown(KeyCode.Escape) || Input.touchCount >= 1)
			{
				tutorial.enabled = true;
				creditsTex.enabled = false;
				menu.enabled = true;
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
