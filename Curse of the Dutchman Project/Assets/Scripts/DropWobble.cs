using UnityEngine;
using System.Collections;

public class DropWobble : MonoBehaviour {
	
	private Vector3 startPos;
	private Vector2 offset;
	//private float height = 0.005f;
	public float moveSpeed;
	private Vector3 water;
	public float maxHeight;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		water = new Vector3(0,moveSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= -maxHeight + startPos.y)
		{
			water = new Vector3(0,moveSpeed,0);
		}
		if(transform.position.y >= maxHeight + startPos.y)
		{
			water = new Vector3(0,-moveSpeed,0);
		}
		transform.Translate(water*Time.deltaTime);
	}
}
