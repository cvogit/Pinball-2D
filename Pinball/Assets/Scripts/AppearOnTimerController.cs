using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnTimerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			Dissapear ();
			Invoke ("Appear", 10);
		}
	}

	void Dissapear() {
		gameObject.SetActive (false);
	}

	void Appear() {
		gameObject.SetActive (true);
	}
}
