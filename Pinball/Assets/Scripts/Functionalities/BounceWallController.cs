using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWallController : MonoBehaviour {

	public GameObject SoundController;

	private float force = 0.4f;
	private Rigidbody2D ballRigidbody;

	void Start () {

	}

	void FixedUpdate () {

	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Ball") {

			ShakeSprite ();
			SoundController.GetComponent<AudioController> ().PlayBounceWall ();

			// Bounce ball
			ballRigidbody = col.gameObject.GetComponent<Rigidbody2D> ();
			int tNumContacts = col.GetContacts (col.contacts);

			if(tNumContacts > 0 )
				ballRigidbody.AddForce(-1 * col.contacts[0].normal * force, ForceMode2D.Impulse);

		}
	}

	void ShakeSprite() {
		transform.Translate (0.01f, 0, 0);
		Invoke ("UnshakeSprite", 0.1f);
	}

	void UnshakeSprite() {
		transform.Translate (-0.01f, 0, 0);
	}
}
