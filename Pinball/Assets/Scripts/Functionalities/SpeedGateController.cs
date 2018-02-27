using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGateController : MonoBehaviour {

	private bool isAccelerating = false;
	private Rigidbody2D ballRigidbody;

	public float force;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		if (isAccelerating)
			AccelerateObject ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			ballRigidbody = col.gameObject.GetComponent<Rigidbody2D> ();
			isAccelerating = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			ballRigidbody.AddForce(new Vector2(-1, 1) * force/2, ForceMode2D.Impulse);
			ballRigidbody = null;
			isAccelerating = false;
		}

	}

	void AccelerateObject(){
		ballRigidbody.AddForce(new Vector2(-1, 1) * force);
	}

}
