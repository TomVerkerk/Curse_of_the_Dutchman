using UnityEngine;
using System.Collections;

public class EnemyColl : MonoBehaviour {

	public EnemyHealth enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Bullet"))
		{
			enemy.enemyHealth --;
			PlayerPrefs.SetFloat("enemy1Health",enemy.enemyHealth);//enemyname?
			Destroy(col.gameObject, 0.2f);
		}
		
	}
}
