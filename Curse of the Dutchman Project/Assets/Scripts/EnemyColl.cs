using UnityEngine;
using System.Collections;

public class EnemyColl : MonoBehaviour {

	private GameObject enemy1;
	private GameObject enemy2;
	private GameObject enemy3;
	private EnemyHealth health1;
	private EnemyHealth health2;
	private EnemyHealth health3;

	void Start(){
		if(PlayerPrefs.GetString("level") == "Level2")
		{
			health1 = GameObject.FindWithTag("enemy1").GetComponent<EnemyHealth>();
			enemy1 = GameObject.FindWithTag("enemy1");
		}
		if(PlayerPrefs.GetString("level") == "Level3")
		{
			health1 = GameObject.FindWithTag("enemy2").GetComponent<EnemyHealth>();
			enemy1 = GameObject.FindWithTag("enemy2");
		}
		if(PlayerPrefs.GetString("level") == "Level4")
		{
			health1 = GameObject.FindWithTag("enemy3").GetComponent<EnemyHealth>();
			enemy1 = GameObject.FindWithTag("enemy3");
		}
		if(PlayerPrefs.GetString("level") == "Level5")
		{
			health1 = GameObject.FindWithTag("enemy4").GetComponent<EnemyHealth>();
			health2 = GameObject.FindWithTag("enemy5").GetComponent<EnemyHealth>();
			health3 = GameObject.FindWithTag("enemy6").GetComponent<EnemyHealth>();
			enemy1 = GameObject.FindWithTag("enemy4");
			enemy2 = GameObject.FindWithTag("enemy5");
			enemy3 = GameObject.FindWithTag("enemy6");
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Bullet"))
		{
			health1.enemyHealth --;
			if(PlayerPrefs.GetString("level") == "Level5")
			{
				health2.enemyHealth --;
				health3.enemyHealth --;
			}
			PlayerPrefs.SetFloat(enemy1.tag,health1.enemyHealth);
			if(PlayerPrefs.GetString("level") == "Level5")
			{
				PlayerPrefs.SetFloat(enemy2.tag,health2.enemyHealth);
				PlayerPrefs.SetFloat(enemy3.tag,health3.enemyHealth);
			}
			Destroy(col.gameObject, 0.2f);
		}
		
	}
}
