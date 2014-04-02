using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public GameObject ship;
	public GameObject mainCam;
	public GameObject aimLeft;
	public GameObject aimRight;
	public Collider enemy;
	public float _timer;
	public bool right = true;
	public bool battle = false;
	public AudioSource canonSound;
	public GameData gamedata;

	private GameObject lastBullet;
	private bool _coolDown = true;
	private Vector3 bombSpawn = new Vector3(0,0.2f,0);

	// Use this for initialization
	void Start () {
		aimLeft.SetActive(false);
		aimRight.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (_timer <= 0) 
		{
			_coolDown = true;
			_timer = 2;
		}
		else if (!_coolDown) 
		{
			_timer -= Time.deltaTime;
		}

	}
	public void Shoot(){

		if(_coolDown == true)
		{
			lastBullet = Instantiate(bullet, transform.position+bombSpawn, ship.transform.rotation) as GameObject;
			lastBullet.gameObject.GetComponent<Bullet>().shootRight = right;
			canonSound.Play();
			gamedata.ChangeAmmo(-1);
			_coolDown = false;
		}
	}
}
