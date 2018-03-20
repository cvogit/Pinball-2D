using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGateController : MonoBehaviour {

	private GameObject mGameController;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			mGameController.gameObject.GetComponent<GameController> ().EnableGateCollision (col.gameObject);
		}
	}
}
