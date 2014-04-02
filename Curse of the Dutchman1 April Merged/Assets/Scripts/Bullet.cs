using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float bulletSpeed;
	public bool shootRight = true;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
		if(shootRight == true)
		{
			transform.Translate (bulletSpeed * Vector3.right * Time.deltaTime);
		}
		else
		{
			transform.Translate (bulletSpeed * Vector3.left * Time.deltaTime);
		}
	}
}
