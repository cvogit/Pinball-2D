using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	private GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ballPosition = ball.transform.position;
		ballPosition.z = gameObject.transform.position.z;

		gameObject.transform.position = ballPosition;
	}
}
