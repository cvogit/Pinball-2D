using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

	private Rigidbody2D ballRigidbody;
	public float force = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

		if (col.gameObject.tag == "Ball") {

			gameObject.GetComponent<Animator> ().SetTrigger("BumperHit");

			ballRigidbody = col.gameObject.GetComponent<Rigidbody2D> ();
			ballRigidbody.AddForce(-1 * col.contacts[0].normal * force, ForceMode2D.Impulse);
		}
	}
}
