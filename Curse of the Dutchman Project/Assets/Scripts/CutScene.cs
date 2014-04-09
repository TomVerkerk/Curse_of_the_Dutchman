using UnityEngine;
using System.Collections;

public class CutScene : MonoBehaviour {

	//private bool next = false;
	
/*	public float frameTimer1 = 5f;
	public float frameTimer2 = 3f;

	private bool _frame1 = true;
	private bool _frame2 = false;*/
	//private bool _timeOn;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("intro") == 1)
		{
			Handheld.PlayFullScreenMovie("Curse of the Dutchman intro.mp4",Color.black,FullScreenMovieControlMode.Hidden);
			PlayerPrefs.SetFloat("intro", 0);
		}
	}
	
	// Update is called once per frame
	//void Update () {
		/*if(!movie.isPlaying || next)
		{
			FadeOut("Level1");
		}*/
		/*if(Input.touchCount >=2)
		{
			Application.LoadLevel("Level1");
		}*/
		/*if (_frame1) {
			frameTimer1 -= Time.deltaTime;
		}
		if (_frame2) {
			frameTimer2 -= Time.deltaTime;
		}
			//Debug.Log (frameTimer1);
		if (frameTimer1 <= 0) {
						transform.position = new Vector3 (transform.position.x + 20, transform.position.y, transform.position.z);
						frameTimer1 = 4f;
		}
		if (frameTimer2 <= 0) {
			Application.LoadLevel("Level1");
		}
		if(transform.position.x > 420){
				_frame1 = false;
				_frame2 = true;
		}*/

//	}
}