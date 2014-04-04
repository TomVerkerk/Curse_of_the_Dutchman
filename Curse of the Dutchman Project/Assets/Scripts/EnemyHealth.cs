using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth;
	public float sinkSpeed;
	public GameObject smoke;
	public GameObject Drop;

	private bool _drop = false;
	// Use this for initialization
	void Start () {
		if(gameObject.tag == "enemy1")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy1Health");
		}
		if(gameObject.tag == "enemy2")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy2Health");
		}
		if(gameObject.tag == "enemy3")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy3Health");
		}
		if(gameObject.tag == "enemy4")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy4Health");
		}
		if(gameObject.tag == "enemy5")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy5Health");
		}
		if(gameObject.tag == "enemy6")
		{
			enemyHealth = PlayerPrefs.GetFloat("enemy6Health");
		}
		if (enemyHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 1) 
		{
			smoke.transform.position = transform.position;
		}
		if (enemyHealth <= 0)
		{
			transform.Translate(Vector3.down* sinkSpeed * Time.deltaTime);
			if(Drop.transform.position != transform.position && _drop == false){
				_drop = true;
				Drop.transform.position = new Vector3(transform.position.x,transform.position.y +1, transform.position.z);
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(col.name == "Player" && enemyHealth <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
