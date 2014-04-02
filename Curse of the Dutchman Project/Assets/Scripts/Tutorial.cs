using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public float pos;

	public GUIText messageText1;
	public GUIText messageText2;
	public GUIText messageText3;
	public GUIText messageText4;
	public GUIText messageText5;

	public GUITexture messageTex;
	public GUITexture arrowTex;
	public GUITexture fingerTex;

	private float step = -1;

	void Start()
	{
		pos = PlayerPrefs.GetFloat("tutPos");
		messageTex.enabled = false;
		arrowTex.enabled = false;
		fingerTex.enabled = false;
		messageText1.enabled = false;
		messageText2.enabled = false;
		messageText3.enabled = false;
		messageText4.enabled = false;
		messageText5.enabled = false;
		if(pos == 1)
		{
			messageTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.3f);
			arrowTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.6f,Screen.width*0.1f,Screen.height*0.35f);
			fingerTex.pixelInset = new Rect(Screen.width*0.65f,Screen.height*0.2f,Screen.width*0.23f,Screen.height*0.38f);
			messageText1.text = "Welcome aboard ship, Captain.";
			messageText2.text = "Your ship has limited supplies,\nDon't let them run out or your crew will starve.";
			messageText3.text = "Swipe down your stats to look at them,\nSwipe back to hide.";
			messageText4.text = "Swipe up to open your first sail,\nSwipe again for your second sail.";
			messageText5.text = "Find the skull, sail the seas,\nAnd keep your supplies at stock.";
			messageText1.pixelOffset = new Vector2(Screen.width*0.29f,Screen.height*0.6f);
			messageText2.pixelOffset = new Vector2(Screen.width*0.25f,Screen.height*0.62f);
			messageText3.pixelOffset = new Vector2(Screen.width*0.29f,Screen.height*0.62f);
			messageText4.pixelOffset = new Vector2(Screen.width*0.29f,Screen.height*0.62f);
			messageText5.pixelOffset = new Vector2(Screen.width*0.29f,Screen.height*0.62f);
			messageText1.fontSize = Screen.width/25;
			messageText2.fontSize = Screen.width/35;
			messageText3.fontSize = Screen.width/30;
			messageText4.fontSize = Screen.width/30;
			messageText5.fontSize = Screen.width/30;
			messageTex.enabled = true;
			messageText1.enabled = true;
		}
	}
	public void ShowTutorial()
	{
		if(pos == 2)
		{
			messageText1.enabled = false;
			messageText2.enabled = true;
		}
		if(pos == 3)
		{
			messageText2.enabled = false;
			messageText3.enabled = true;
			arrowTex.enabled = true;
		}
		if(pos == 5)
		{
			arrowTex.enabled = false;
			messageText3.enabled = false;
			messageText4.enabled = true;
			fingerTex.enabled = true;
		}
		if(pos == 6)
		{
			messageText4.enabled = false;
			fingerTex.enabled = false;
			messageTex.enabled = false;
		}
		if(pos == 7)
		{
			messageTex.enabled = true;
			messageText5.enabled = true;
		}
		if(pos == 8)
		{
			messageTex.enabled = false;
			messageText5.enabled = false;
			PlayerPrefs.SetFloat("tutPos",0);
			pos = 0;
		}
	}

	void Update()
	{
		if(fingerTex.enabled == true)
		{
			step++;
			if(step == 0)
			{
				fingerTex.transform.position = new Vector3(0,-0.2f,0.2f);
			}
			if(step == 12)
			{
				fingerTex.transform.position = new Vector3(0,0,0.2f);
			}
			if(step == 24)
			{
				fingerTex.transform.position = new Vector3(0,0.2f,0.2f);
			}
			if(step == 36)
			{
				step -= 37;
			}
		}
	}
}
