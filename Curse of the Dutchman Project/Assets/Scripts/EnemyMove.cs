using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float enemyMoveSpeed;
	public float enemyTurnSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,enemyTurnSpeed *Time.deltaTime ,0));
		transform.Translate(new Vector3(0,0,enemyMoveSpeed * Time.deltaTime));
		}
}
