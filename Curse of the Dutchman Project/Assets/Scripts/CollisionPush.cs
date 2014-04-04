using UnityEngine;
using System.Collections;

public class CollisionPush : MonoBehaviour {

	private Vector3 relPos;
	public GameData gameData;
	private float enemyDamage;
	public PlayerMovement player;
	private bool noSkull = false;

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
		if (col.gameObject.tag == "volumeBlock")
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
		}
		if (col.gameObject.tag == "endTrigger" && PlayerPrefs.GetFloat("skull") == 1)
		{
			PlayerPrefs.SetFloat("win",1);
			player.FadeOut("Menu");
		}
		if (col.gameObject.tag == "endTrigger" && PlayerPrefs.GetFloat("skull") == 0)
		{
			noSkull = true;
			gameData.noSkullText.enabled = true;
			gameData.noSkullMessageTex.enabled = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "enemyBullet")
		{
			enemyDamage = 5 + Mathf.Round(Random.value*20);
			gameData.ChangeBoatHealth(-enemyDamage);
			gameData.Inpact.Play();
		}
	}

	void Update(){
		if(noSkull == true && Input.touchCount >= 1)
		{
			gameData.noSkullText.enabled = false;
			gameData.noSkullMessageTex.enabled = false;
			noSkull = false;
		}
	}
}