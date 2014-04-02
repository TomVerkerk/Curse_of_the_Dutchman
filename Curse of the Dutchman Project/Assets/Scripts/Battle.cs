using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

	public GameObject ship;
	public GameObject cam;
	public GameObject enemy;
	public PlayerShoot player;
	public float moveSpeed;
	public float cameraRotateSpeed;
	public GameObject leftCam;
	public GameObject rightCam;
	public GameObject idleCam;

	private Quaternion neededRotation;
	private Vector3 relPos;
	private float leftDis;
	private float rightDis;
	private Vector3 cameraPos;
	public bool battle = false;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetString("level") == "Level2")
		{
			enemy = GameObject.FindWithTag("enemyShip1");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(battle == false)
		{
			cameraPos = idleCam.transform.position;
			player.aimLeft.SetActive(false);
			player.aimRight.SetActive(false);
		}
		else
		{
			relPos = enemy.transform.position - cam.transform.position;
			leftDis = Vector3.Distance(enemy.transform.position, leftCam.gameObject.transform.position);
			rightDis = Vector3.Distance(enemy.transform.position, rightCam.gameObject.transform.position);
			if(leftDis < rightDis)
			{
				player.right = false;
				cameraPos = rightCam.gameObject.transform.position;
				player.aimRight.SetActive(false);
				player.aimLeft.SetActive(true);
			}
			else
			{
				player.right = true;
				cameraPos = leftCam.gameObject.transform.position;
				player.aimLeft.SetActive(false);
				player.aimRight.SetActive(true);
			}
			neededRotation = Quaternion.LookRotation(relPos);
			cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, neededRotation, cameraRotateSpeed * Time.deltaTime);
		}
		float step = moveSpeed * Time.deltaTime;
		cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos, step);
	}
}
