using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	private GameObject mCentralObject;
	private GameObject ScoreBoxCanvas;

	// Use this for initialization
	void Start () {
		mCentralObject = GameObject.Find ("Ball");

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ballPosition;
		if (mCentralObject != null) {
			ballPosition = mCentralObject.transform.position;
			ballPosition.z = gameObject.transform.position.z;

			if (ballPosition.y > -0.25f)
				ballPosition.y = -0.25f;
			else if (ballPosition.y < -0.50)
				ballPosition.y = -0.50f;

			if (ballPosition.x > 0.75)
				ballPosition.x = 0.75f;
			else if (ballPosition.x < -0.75)
				ballPosition.x = -0.75f;
		}
		else 
			ballPosition = gameObject.transform.position;

		gameObject.transform.position = ballPosition;
	}

	public void SetCentralObject(GameObject pObject) {
		mCentralObject = pObject;
	}
}
