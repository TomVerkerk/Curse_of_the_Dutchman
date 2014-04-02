using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public GameObject enemyBullet;
	public AudioSource canonEnemySound;
	private bool _coolDown = true;
	private float _timer = 2;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(target);
		if (!_coolDown) 
		{
			_timer -= Time.deltaTime;
		}
		if (_timer <= 0) 
		{
			_coolDown = true;
			_timer = 2;
		}
	}
	/*void OnTriggerEnter(Collider col){
		if(col.collider.tag == "Player")
		{
			Debug.Log ("if");
		}
		else
		{
			Debug.Log ("else");
		}
	}*/
	void OnTriggerStay(Collider col){
		if (col.collider.name == "Player") {
						RaycastHit hit;
						if (Physics.Raycast (transform.position, Vector3.right, out hit)) {
				
								if (hit.collider.name == "Player" && (_coolDown)) {
										_coolDown = false;
										Instantiate(enemyBullet, transform.position, Quaternion.Euler(0,0,0));
										canonEnemySound.Play();
								} 
								
								//float distanceToGround = hit.distance;
								//hit.
								//Debug.Log ("Hij valt aan!");
								//target = col.transform;
								/*if(_coolDown){
				_coolDown = false;
				GameObject bullet = Instantiate(Resources.Load("BulletEnemy")) as GameObject;
				bullet.transform.position = transform.position;
				}*/
						}

				else if (Physics.Raycast (transform.position, Vector3.left, out hit)) {
				if (hit.collider.name == "Player" && (_coolDown)) {
					
					_coolDown = false;
					Instantiate(enemyBullet, transform.position, Quaternion.Euler(0,180,0));
					canonEnemySound.Play();
					//new Vector3(1,transform.position.y,transform.position.z);
					
				}		
			}		
				}
	}
}
