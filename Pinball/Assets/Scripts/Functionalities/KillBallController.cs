using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBallController : MonoBehaviour {

	private GameObject mGameController;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			Destroy (col.gameObject);
			mGameController.gameObject.GetComponent<GameController> ().BallIsDeath ();
		}
	}
}
