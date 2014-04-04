using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameData gameDate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameDate.boatHealth <= 0) {
			Debug.Log("dead");
		}
	}
}
