using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public float boatHealth;
	public float supplies;
	public float pirates;
	public float ammo;

	public GUIText boatHealthText;
	public GUIText boatSuppliesText;
	public GUIText piratesText;
	public GUIText ammoText;
	public GUIText gameOverText;
	public GUIText noSkullText;

	public GUITexture evadeTex;
	public GUITexture dockTex;
	public GUITexture battleTex;
	public GUITexture shootTex;
	public GUITexture statsTex;
	public GUITexture noSkullMessageTex;

	public AudioSource Inpact;

	private float random;
	public bool _dead = false;

	// Use this for initialization
	void Start () {
		noSkullText.enabled = false;
		noSkullMessageTex.enabled = false;
		gameOverText.enabled = false;
		dockTex.enabled = false;
		battleTex.enabled = false;
		shootTex.enabled = false;
		evadeTex.enabled = false;
		if(PlayerPrefs.GetFloat("dock")==0)
		{
			statsTex.enabled = true;
		}
		noSkullText.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.65f);
		noSkullText.text = "You need the skull!\nGo back to find it.";
		noSkullText.fontSize = Screen.width/30;
		noSkullMessageTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.3f);
		gameOverText.pixelOffset = new Vector2 (Screen.width *0.3f, Screen.height * 0.63f);
		statsTex.pixelInset = new Rect(Screen.width*0.052f,Screen.height*1.015f,Screen.width*0.4f,Screen.height*0.1f);
		evadeTex.pixelInset = new Rect(Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f);
		shootTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f);
		battleTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f);
		dockTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.05f,Screen.width*0.3f,Screen.height*0.15f);
		boatHealthText.pixelOffset = new Vector2(Screen.width*0.03f,Screen.height*1.14f);
		boatHealthText.fontSize = Screen.width/25;
		boatSuppliesText.pixelOffset = new Vector2(Screen.width*0.03f,Screen.height*1.08f);
		boatSuppliesText.fontSize = Screen.width/25;
		piratesText.pixelOffset = new Vector2(Screen.width*0.28f,Screen.height*1.08f);
		piratesText.fontSize = Screen.width/25;
		ammoText.pixelOffset = new Vector2(Screen.width*0.28f,Screen.height*1.14f);
		ammoText.fontSize = Screen.width/25;
		gameOverText.text = "You died!\nTap the screen to play again";
		gameOverText.fontSize = Screen.width / 25;
		if(PlayerPrefs.GetFloat("first") == 1)
		{
			boatHealth = 100;
			random = Mathf.Round(Random.value*10);
			supplies = 15 + random;
			random = Mathf.Round(Random.value*10);
			pirates = 10 + random;
			random = Mathf.Round(Random.value*5);
			ammo = 3 + random;
			PlayerPrefs.SetFloat("ammo",ammo);
			PlayerPrefs.SetFloat("boatHealth", boatHealth);
			PlayerPrefs.SetFloat("supplies", supplies);
			PlayerPrefs.SetFloat("pirates", pirates);
			PlayerPrefs.SetFloat("first", 2);
		}
		else
		{
			ammo = PlayerPrefs.GetFloat("ammo");
			boatHealth = PlayerPrefs.GetFloat("boatHealth");
			supplies = PlayerPrefs.GetFloat("supplies");
			pirates = PlayerPrefs.GetFloat("pirates");
		}
	}

	void Update(){
		if(boatHealth <= 0)
		{
			boatHealth = 0;
			PlayerPrefs.SetFloat("died",1);
			noSkullMessageTex.enabled = true;
			gameOverText.enabled = true;
			_dead = true;
		}
		if (_dead == true && Input.touchCount >= 1) {
			Application.LoadLevel("Menu");
		}
		if(supplies <= 10)
		{
			boatSuppliesText.color = Color.red;
			if(supplies <= 0)
			{
				supplies = 0;
			}
		}
		else
		{
			boatSuppliesText.color = Color.black;
		}
		if(pirates <= 0)
		{
			pirates = 0;
			PlayerPrefs.SetFloat("died",1);
			noSkullMessageTex.enabled = true;
			gameOverText.enabled = true;
			_dead = true;
		}
		if(ammo <= 0)
		{
			ammo = 0;
		}
	}

	void OnGUI(){
		ammoText.text = "Ammo: " + ammo.ToString();
		boatHealthText.text = "Boathealth: " + boatHealth.ToString();
		boatSuppliesText.text = "Supplies: " + supplies.ToString();
		piratesText.text = "Pirates: " + pirates.ToString();
	}

	public void ChangeBoatHealth(float change){
		boatHealth += change;
		PlayerPrefs.SetFloat("boatHealth", boatHealth);
	}

	public void ChangeSupplies(float change){
		supplies += change;
		PlayerPrefs.SetFloat("supplies", supplies);
	}

	public void ChangePirates(float change){
		pirates += change;
		PlayerPrefs.SetFloat("pirates", pirates);
	}
	public void ChangeAmmo(float change){
		ammo += change;
		PlayerPrefs.SetFloat("ammo", ammo);
	}
}