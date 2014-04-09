using UnityEngine;
using System.Collections;

public class SkullColl : MonoBehaviour {

	public GUIText skullText;
	public GUITexture messageTex;
	public GameObject drop;

	private bool show = false;

	void Start(){
		skullText.enabled = false;
		messageTex.enabled = false;
		skullText.pixelOffset = new Vector2(Screen.width*0.3f,Screen.height*0.6f);
		skullText.text = "You've found the skull!";
		skullText.fontSize = Screen.width/25;
		messageTex.pixelInset = new Rect(Screen.width*0.2f, Screen.height*0.4f,Screen.width*0.6f,Screen.height*0.3f);
	}
	// Use this for initialization
	void OnTriggerEnter(Collider col){
		if(gameObject.tag == "Skull")
		{
			skullText.enabled = true;
			messageTex.enabled = true;
			PlayerPrefs.SetFloat("skull",1);
			drop.transform.position = new Vector3(0,-100,0);
			show = true;
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
