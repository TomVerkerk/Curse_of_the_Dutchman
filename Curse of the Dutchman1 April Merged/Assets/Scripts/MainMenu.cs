using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUITexture menu;
	private bool startGame = false;
	private bool loadGame = false;
	public GUITexture fader;
	public float fadeSpeed;
	public string nextLevel;
	private bool start = true;
	public AudioSource buttonClick;

	void Start(){
		menu.pixelInset = new Rect(-Screen.width/68.3f,0,Screen.width,Screen.height);
		fader.color = Color.black;
		PlayerPrefs.SetFloat("docked" , 0);
		PlayerPrefs.SetFloat("sails", 0);
		PlayerPrefs.SetFloat("movementSpeed", 0);
	}

	void OnGUI()
	{
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.26f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),""/*"Start Game", mainMenuSkin*/))
	    {
			//start game
			buttonClick.Play();
			PlayerPrefs.SetFloat("tutPos", 1);
			PlayerPrefs.SetFloat("dockTut", 1);
			PlayerPrefs.SetFloat("first", 1);
			PlayerPrefs.SetFloat("enemy1Health", 2);
			PlayerPrefs.SetString("level", "level1");
			PlayerPrefs.SetFloat("startGame", 1);
			startGame = true;
		}
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.4f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),""/*"Load Game", mainMenuSkin*/)&&PlayerPrefs.GetFloat("startGame")==1)
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
/*		if(GUI.Button(new Rect(Screen.width * 0.25f,
		                       Screen.height * 0.8f, 
		                       Screen.width * 0.4f, Screen.height * 0.2f),"""Options", mainMenuSkin))
		{
			Debug.Log ("Options");
		}
		if(GUI.Button(new Rect(Screen.width * 0.25f,
		                       Screen.height * 0.8f, 
		                       Screen.width * 0.4f, Screen.height * 0.2f),""/"Credits", mainMenuSkin))
		{
			Debug.Log ("Credits");
		}*/
		if(GUI.Button(new Rect(Screen.width * 0.28f,
		                       Screen.height * 0.87f, 
		                       Screen.width * 0.4f, Screen.height * 0.14f),""/*"Quit", mainMenuSkin*/))
		{
			//quit
			buttonClick.Play();
			Application.Quit();
		}
	}

	void Update(){
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
