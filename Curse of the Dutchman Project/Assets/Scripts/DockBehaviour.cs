using UnityEngine;
using System.Collections;

public class DockBehaviour : MonoBehaviour {

	public Vector3 dockOffsetNeg;
	public Vector3 dockOffset;
	public Vector3 leftDock;
	public Vector3 rightDock;
	public GameObject actionCamLeft;
	public GameObject actionCamRight;
	public float dockRotation;
	// 1= normal 2= rotated


	// Use this for initialization
	void Start () {
		leftDock = transform.position + dockOffsetNeg;
		rightDock = transform.position + dockOffset;
	}
}
