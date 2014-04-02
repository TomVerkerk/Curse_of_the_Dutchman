using UnityEngine;
using System.Collections;

public class IntroVideoTrigger : MonoBehaviour {

	public float dropRate;
	public Light light1;
	public Light light2;

	// Use this for initialization
	void OnTriggerStay(Collider col){
		if(col.name == "the flying dutchman")
		{
			Debug.Log(col);
			light1.intensity -= dropRate;
			light2.intensity -= dropRate;
		}
	}
}
