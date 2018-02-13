using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

	public float maxThrust;
	public float minThrust;

	private Rigidbody2D ballRb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			ballRb = col.gameObject.GetComponent<Rigidbody2D> ();
			ballRb.AddForce(transform.up * Random.Range(minThrust, maxThrust));
		}

	}

}
