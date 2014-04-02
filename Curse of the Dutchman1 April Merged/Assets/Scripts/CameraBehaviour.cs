using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public GameObject ship;
	public float lookHeight;
	public float introCamSpeed;
	public bool battle = false;
	private Quaternion neededRotation;
	private Vector3 relPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(battle == false)
		{
			relPos = ship.transform.position + Vector3.up*lookHeight - transform.position;
			neededRotation = Quaternion.LookRotation(relPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, introCamSpeed * Time.deltaTime);
		}
	}
}
