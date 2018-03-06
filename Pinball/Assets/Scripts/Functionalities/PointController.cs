using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

	private GameObject GameController;
	public int point;

	// Use this for initialization
	void Start () {
		GameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetPoint() {
		return point;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			GameController.gameObject.GetComponent<GameController> ().IncreaseScore (point);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			// Increment score
			GameController.gameObject.GetComponent<GameController> ().IncreaseScore (point);
		}
	}
}
