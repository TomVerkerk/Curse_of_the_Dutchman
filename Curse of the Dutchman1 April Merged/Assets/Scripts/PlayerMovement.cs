using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float maxSpeed;
	public float accelerationFactor;
	public float rotateSpeed;
	public float minRotation;
	public float fadeSpeed;
	public float supplyDropTime;
	public float minSwipePer;
	public GameObject mainCam;
	public GUITexture fader;
	public Battle battleScript;
	public PlayerShoot playerShoot;
	public Tutorial tutorial;
	public GameData gameData;
	public GameObject sailFront1;
	public GameObject sailFront2;
	public GameObject sailBack1;
	public GameObject sailBack2;
	public AudioSource dockSound;
	public AudioSource ambientSound;

	private bool enteringLevel = false;
	private float beginAcceleration;
	private bool goingIn=false;
	private bool nextMessage = false;
	private Vector3 openStatsPos = new Vector3(0,-0.18f,0);
	private Vector3 openStatsTextPos = new Vector3(0,-0.18f,0.1f);
	private Vector3 closedStatsTextPos = new Vector3(0,0,0.1f);
	private EnemyHealth enemy;
	private Vector2 swipeBegin;
	private Vector2 swipeEnd;
	private float sails;
	private bool battle = false;
	private float startSupplyDropTime;
	private float timer;
	private float rotated;
	private Vector3 spawnRotation;
	private Vector3 spawn;
	private bool fading = true;
	private bool arrived = false;
	private float leftDockDis;
	private float rightDockDis;
	private Vector3 leftDock;
	private Vector3 rightDock;
	private bool nearDock = false;
	private bool docking = false;
	private Collider dock;
	private float rotate;
	private float movementSpeed;
	private Vector3 acceleration;
	private string nextLevel;
	private bool enemyInRange = false;
	private Color startcol;

	// Use this for initialization
	void Start () {
		beginAcceleration = accelerationFactor;
		Input.multiTouchEnabled = true;
		fader.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		startcol = gameData.dockTex.color;
		startSupplyDropTime = supplyDropTime;
		movementSpeed = PlayerPrefs.GetFloat("movementSpeed");
		rotated = PlayerPrefs.GetFloat("dockRotation");
		sails = PlayerPrefs.GetFloat("sails");
		fader.enabled = false;
		if(rotated == 0)
		{
			spawnRotation = Vector3.forward;
		}
		else
		{
			spawnRotation = Vector3.back;
		}
		if(PlayerPrefs.GetFloat("enteringLevel") == 1 && PlayerPrefs.GetString("level") == "level1")
		{
			spawnRotation = Vector3.left;
			PlayerPrefs.SetFloat("enteringLevel",0);
		}
		if(PlayerPrefs.GetFloat("dock") == 1)
		{
			spawn.x = PlayerPrefs.GetFloat("spawnX");
			spawn.z = PlayerPrefs.GetFloat("spawnZ");
			transform.position = spawn;
			transform.LookAt(transform.position + spawnRotation);
			docking = false;
			arrived = false;
			fader.color = Color.black;
			PlayerPrefs.SetFloat("dock",0);
			if(PlayerPrefs.GetFloat("loadGame") == 1)
			{
				transform.rotation = new Quaternion(0,PlayerPrefs.GetFloat("rotation"),0,0);
			}
		}
		if(PlayerPrefs.GetString("level") == "Level2")
		{
			enemy = GameObject.FindWithTag("enemy1").GetComponent<EnemyHealth>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if(sails == 0)
		{
			sailBack1.SetActive(false);
			sailBack2.SetActive(false);
			sailFront1.SetActive(false);
			sailFront2.SetActive(false);
		}
		else if(sails == 1)
		{
			sailFront1.SetActive(true);
			sailFront2.SetActive(true);
			sailBack1.SetActive(false);
			sailBack2.SetActive(false);
		}
		else
		{
			sailFront1.SetActive(true);
			sailFront2.SetActive(true);
			sailBack1.SetActive(true);
			sailBack2.SetActive(true);
		}
		if(tutorial.pos > 0)
		{
			if(tutorial.pos == 1 && Input.touchCount > 0)
			{
				tutorial.pos = 2;
				tutorial.ShowTutorial();
			}
			if(tutorial.pos == 2 && Input.touchCount == 0)
			{
				nextMessage = true;
			}
			if(tutorial.pos == 2 && Input.touchCount > 0 && nextMessage == true)
			{
				tutorial.pos = 3;
				tutorial.ShowTutorial();
				nextMessage = false;
			}
			if(tutorial.pos == 7 && Input.touchCount > 0 && nextMessage == true)
			{
				tutorial.pos = 8;
				tutorial.ShowTutorial();
				nextMessage = false;
			}
		}
		if(timer >= (supplyDropTime/(sails+1)))
		{
			if(gameData.supplies <= 0)
			{
				supplyDropTime = startSupplyDropTime * 1.5f;
				gameData.pirates -=1;
			}
			else
			{
				supplyDropTime = startSupplyDropTime;
				gameData.supplies -=1;
			}
			timer = 0;
		}
		foreach(var T in Input.touches)
		{
			if(T.phase == TouchPhase.Began)
			{
				swipeBegin.x = ((100f/Screen.width)*T.position.x);
				swipeBegin.y = ((100f/Screen.height)*T.position.y);
			}
			else if(T.phase == TouchPhase.Ended)
			{
				swipeEnd.x = ((100f/Screen.width)*T.position.x);
				swipeEnd.y = ((100f/Screen.height)*T.position.y);
				if(swipeBegin.x < 50 && swipeBegin.y > 85 && swipeEnd.y <= swipeBegin.y - 10)
				{
					if(tutorial.pos == 2 || tutorial.pos == 1)
					{
						break;
					}
					gameData.statsTex.transform.position = openStatsPos;
					gameData.boatHealthText.transform.position = openStatsTextPos;
					gameData.boatSuppliesText.transform.position = openStatsTextPos;
					gameData.piratesText.transform.position = openStatsTextPos;
					gameData.ammoText.transform.position = openStatsTextPos;
					if(tutorial.pos == 3)
					{
						tutorial.pos = 5;
						tutorial.ShowTutorial();
					}
				}
				else if(swipeBegin.x < 50 && swipeBegin.y > 70 && swipeEnd.y > swipeBegin.y + 5)
				{
					gameData.statsTex.transform.position = Vector3.zero;
					gameData.boatHealthText.transform.position = closedStatsTextPos;
					gameData.boatSuppliesText.transform.position = closedStatsTextPos;
					gameData.piratesText.transform.position = closedStatsTextPos;
					gameData.ammoText.transform.position = closedStatsTextPos;
				}
				else if(swipeBegin.y - swipeEnd.y < -minSwipePer && sails < 2)
				{
					sails += 1;
					if(tutorial.pos <= 4 && tutorial.pos > 0)
					{
						sails = 0;
					}
					if(tutorial.pos == 5)
					{
						tutorial.pos = 6;
						tutorial.ShowTutorial();
					}
				}
				else if(swipeBegin.y - swipeEnd.y > minSwipePer && sails > 0)
				{
					sails -= 1;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}
		if(fading == true)
		{
			FadeIn();
		}
		if(!docking)
		{
			if (!ambientSound.isPlaying)
			{
				ambientSound.Play();
			}
			if(dockSound.isPlaying)
			{
				dockSound.Stop();
			}
			if(enteringLevel == false)
			{
				PlayerPrefs.SetFloat("rotation",transform.rotation.y);
				PlayerPrefs.SetFloat("spawnX",transform.position.x);
				PlayerPrefs.SetFloat("spawnZ",transform.position.z);
			}
			acceleration = Input.acceleration;
			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
			if(sails == 2)
			{
				accelerationFactor = beginAcceleration * 1.5f;
			}
			else if(sails == 1)
			{
				accelerationFactor = beginAcceleration;
			}
			if(movementSpeed <= (maxSpeed * sails))
			{
				movementSpeed += accelerationFactor;
			}
			else if(movementSpeed <=0)
			{
				movementSpeed = 0;
			}
			else if(tutorial.pos == 6 && movementSpeed > maxSpeed)
			{
				tutorial.pos = 7;
				tutorial.ShowTutorial();
			}
			else
			{
				movementSpeed -= accelerationFactor;
				if(tutorial.pos == 7)
				{
					nextMessage = true;
				}
			}
			rotate = movementSpeed * rotateSpeed;
			if(acceleration.x >= minRotation || acceleration.x <= -minRotation)
			{
				if(acceleration.x >= 0.6)
				{
					acceleration.x = 0.7f;
				}
				if(acceleration.x <= -0.6)
				{
					acceleration.x = -0.7f;
				}
				transform.Rotate(new Vector3(0,acceleration.x,0)*rotate*Time.deltaTime);
			}
		}
		if(PlayerPrefs.GetFloat("docked") == 1)
		{
			gameData.dockTex.color = startcol*0.7f;
		}
		else
		{
			gameData.dockTex.color = startcol;
		}
		if(docking)
		{
			if (ambientSound.isPlaying)
			{
				ambientSound.Stop();
			}
			if(!dockSound.isPlaying)
			{
				dockSound.Play();
			}
			gameData.dockTex.enabled = false;
			if(transform.position.x < dock.transform.position.x && arrived == false)
			{
				if(transform.position.x > leftDock.x)
				{
					transform.LookAt(transform.position + Vector3.left);
				}
				else
				{
					transform.LookAt(leftDock);
				}
				if(rotated == 1)
				{
					dock.gameObject.GetComponent<DockBehaviour>().actionCamLeft.SetActive(true);
				}
				else
				{
					dock.gameObject.GetComponent<DockBehaviour>().actionCamRight.SetActive(true);
				}
				transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
				PlayerPrefs.SetFloat("spawnX",leftDock.x);
				PlayerPrefs.SetFloat("spawnZ",leftDock.z);
			}
			if(transform.position.x >= dock.transform.position.x && arrived == false)
			{
				if(transform.position.x < rightDock.x)
				{
					transform.LookAt(transform.position + Vector3.right);
				}
				else
				{
					transform.LookAt(rightDock);
				}
				if(rotated == 1)
				{
					dock.gameObject.GetComponent<DockBehaviour>().actionCamRight.SetActive(true);
				}
				else
				{
					dock.gameObject.GetComponent<DockBehaviour>().actionCamLeft.SetActive(true);
				}
				transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
				PlayerPrefs.SetFloat("spawnX",rightDock.x);
				PlayerPrefs.SetFloat("spawnZ",rightDock.z);
			}
			mainCam.SetActive(false);
			movementSpeed = 3;
			leftDockDis = (leftDock.x - transform.position.x)*(leftDock.x - transform.position.x)+(leftDock.z - transform.position.z)*(leftDock.z - transform.position.z);
			rightDockDis = (rightDock.x - transform.position.x)*(rightDock.x - transform.position.x)+(rightDock.z - transform.position.z)*(rightDock.z - transform.position.z);
			if(leftDockDis < 5 || rightDockDis < 5)
			{
				goingIn = true;
			}
			if(goingIn == true)
			{
				if(rotated == 1)
				{
					transform.LookAt(transform.position + Vector3.forward);
				}
				else
				{
					transform.LookAt(transform.position + Vector3.back);
				}
				transform.Translate(Vector3.zero);
				arrived = true;
				fader.enabled = true;
				PlayerPrefs.SetFloat("supplies", gameData.supplies);
				if(enemy != null)
				{
					PlayerPrefs.SetFloat("enemy1Health", enemy.enemyHealth);//enemy name?
				}
				PlayerPrefs.SetFloat("supplies", gameData.supplies);
				PlayerPrefs.SetFloat("pirates", gameData.pirates);
				FadeOut("Dock");
			}
		}
	}
	
	void OnTriggerEnter(Collider trigger)
	{
		if(trigger.name == "Coll")
		{
			dock = trigger;
			leftDock = dock.gameObject.GetComponent<DockBehaviour>().leftDock;
			rightDock = dock.gameObject.GetComponent<DockBehaviour>().rightDock;
			nearDock = true;
			rotated = dock.gameObject.GetComponent<DockBehaviour>().dockRotation;
			PlayerPrefs.SetFloat("dockRotation", dock.gameObject.GetComponent<DockBehaviour>().dockRotation);
			gameData.dockTex.enabled = true;
		}
		if(trigger.name == "EnemyShip")
		{
			battleScript.enemy = trigger.gameObject;
			enemyInRange = true;
			gameData.battleTex.enabled = true;
			playerShoot.enemy = trigger;
		}
	}

	void OnTriggerStay(Collider trigger)
	{
		if(trigger.name == "NextLevelTrigger")
		{
			PlayerPrefs.SetString("level", trigger.gameObject.GetComponent<NextLevel>().nextLevel);
			PlayerPrefs.SetFloat("supplies", gameData.supplies);
			PlayerPrefs.SetFloat("pirates", gameData.pirates);
			PlayerPrefs.SetFloat("supplies", gameData.supplies);
			PlayerPrefs.SetFloat("movementSpeed", movementSpeed);
			PlayerPrefs.SetFloat("sails", sails);
			if(enemy != null)
			{
				PlayerPrefs.SetFloat("enemy1Health", enemy.enemyHealth);//enemy name
			}
			if(trigger.gameObject.GetComponent<NextLevel>().back == true)
			{
				PlayerPrefs.SetFloat("dock",1);
				PlayerPrefs.SetFloat("spawnX",trigger.gameObject.GetComponent<NextLevel>().spawnX);
				PlayerPrefs.SetFloat("spawnZ",trigger.gameObject.GetComponent<NextLevel>().spawnZ);
				PlayerPrefs.SetFloat("enteringLevel",1);
				enteringLevel = true;
			}
			FadeOut(trigger.gameObject.GetComponent<NextLevel>().nextLevel);
		}
	}
	
	void OnTriggerExit(Collider coll)
	{
		if(coll.name == "Coll")
		{
			dock = null;
			nearDock = false;
			gameData.dockTex.enabled = false;
			fader.color = Color.clear;
			fader.enabled = false;
			PlayerPrefs.SetFloat("docked" , 0);
		}
		if(coll.name == "EnemyShip")
		{
			battle = false;
			enemyInRange = false;
			gameData.shootTex.enabled = false;
			gameData.evadeTex.enabled = false;
			battleScript.battle = false;
			playerShoot.battle = false;
			gameData.battleTex.enabled = false;
			mainCam.gameObject.GetComponent<CameraBehaviour>().battle = false;
		}
	}
	
	void OnGUI()
	{
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(Screen.width*0.65f,Screen.height*0.79f,Screen.width*0.3f,Screen.height*0.16f),""))
		{
			if(nearDock == true && dock != null && PlayerPrefs.GetFloat("docked") == 0)
			{
				docking = true;
			}
			if(battle == true)
			{
				playerShoot.Shoot();
			}
			if(enemyInRange == true && battle == false)
			{
				playerShoot.battle = true;
				battleScript.battle = true;
				gameData.shootTex.enabled = true;
				gameData.evadeTex.enabled = true;
				gameData.battleTex.enabled = false;
				mainCam.gameObject.GetComponent<CameraBehaviour>().battle = true;
				battle = true;
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.05f,Screen.height*0.79f,Screen.width*0.3f,Screen.height*0.16f),""))
		{
			if(battle == true)
			{
				gameData.shootTex.enabled = false;
				gameData.evadeTex.enabled = false;
				gameData.battleTex.enabled = true;
				mainCam.gameObject.GetComponent<CameraBehaviour>().battle = false;
				battleScript.battle = false;
				playerShoot.battle = false;
				battle = false;
			}
		}
	}
	
	void FadeOut(string nextLevel)
	{
		fader.enabled = true;
		fader.color = Color.Lerp(fader.color, Color.black, fadeSpeed*1.2f * Time.deltaTime);
		if(fader.color.a >= 0.5)
		{
			Application.LoadLevel(nextLevel);
		}
	}
	
	void FadeIn()
	{
		fader.enabled = true;
		fader.color = Color.Lerp(fader.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(fader.color.a <= 0.02)
		{
			fader.enabled = false;
		}
	}
}
