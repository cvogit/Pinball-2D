using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject GameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Point") {
			int point = col.gameObject.GetComponent<PointController> ().GetPoint ();
			GameController.gameObject.GetComponent<GameController> ().IncreaseScore (point);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Point") {
			int point = col.gameObject.GetComponent<PointController> ().GetPoint ();
			GameController.gameObject.GetComponent<GameController> ().IncreaseScore (point);
		}
	}
}
