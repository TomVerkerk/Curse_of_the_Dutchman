using UnityEngine;
using System.Collections;

public class Wobbler : MonoBehaviour {

	public float wobbleSpeed;
	public float maxLean;
	public float maxWobble;
	public float seaStrength;
	//private Vector3 wobble = new Vector3(0,5,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * seaStrength * Time.deltaTime);
		if(transform.localRotation.z > maxLean && seaStrength > -maxWobble)
		{
			seaStrength -= wobbleSpeed;
		}
		else if(transform.localRotation.z < -maxLean && seaStrength < maxWobble)
		{
			seaStrength += wobbleSpeed;
		}
	}
}
