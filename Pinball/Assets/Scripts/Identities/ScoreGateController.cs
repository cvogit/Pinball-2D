using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGateController : MonoBehaviour {

	public GameObject GameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			GameController.gameObject.GetComponent<GameController>().HandleDeath (col.gameObject);
		}
	}
}
