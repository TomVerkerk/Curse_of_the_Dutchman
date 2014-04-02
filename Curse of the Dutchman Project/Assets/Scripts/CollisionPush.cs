using UnityEngine;
using System.Collections;

public class CollisionPush : MonoBehaviour {

	private Vector3 relPos;
	public GameData gameData;

	void OnCollisionEnter(Collision col){
		relPos = transform.position - col.transform.position;
		if (col.gameObject.tag == "Environment")
		{
			if(relPos.x > 0 && relPos.z > 0 && relPos.z*relPos.z > relPos.x*relPos.x) {
				transform.position = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z + 2);
			}
			else if (relPos.x > 0 && relPos.z > 0 && relPos.x*relPos.x > relPos.z*relPos.z) {
				transform.position = new Vector3 (transform.position.x + 2 , transform.position.y, transform.position.z + 1);
			}
			else if (relPos.x > 0 && relPos.z <= 0 && relPos.x*relPos.x > relPos.z*relPos.z) {
				transform.position = new Vector3 (transform.position.x + 2 , transform.position.y, transform.position.z - 1);
			}
			else if(relPos.x > 0 && relPos.z <= 0 && relPos.z*relPos.z > relPos.x*relPos.x){
				transform.position = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z - 2);
			}
			else if(relPos.x <= 0 && relPos.z <= 0 && relPos.z*relPos.z > relPos.x*relPos.x){
				transform.position = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z - 1);
			}
			else if(relPos.x <= 0 && relPos.z <= 0 && relPos.x*relPos.x > relPos.z*relPos.z){
				transform.position = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z - 1);
			}
			else if(relPos.x <= 0 && relPos.z > 0 && relPos.x*relPos.x > relPos.z*relPos.z){
				transform.position = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z + 1);
			}
			else if(relPos.x <= 0 && relPos.z > 0 && relPos.z*relPos.z > relPos.x*relPos.x){
				transform.position = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z + 2);
			}
			gameData.ChangeBoatHealth(-30);
		}
	}
}