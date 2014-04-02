using UnityEngine;
using System.Collections;

public class DropScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.name == "Player") {
			transform.position = new Vector3(transform.position.z,transform.position.y - 10,transform.position.z);
		}
	
	}

	               
}
