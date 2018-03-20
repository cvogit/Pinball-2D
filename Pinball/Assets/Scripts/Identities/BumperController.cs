using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {

	public float force = 5;

	public GameObject SoundController;

	private Rigidbody2D ballRigidbody;

	// Use this for initialization
	void Start () {
		SoundController = GameObject.Find ("Audio Controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {

		if (col.gameObject.tag == "Ball") {

			gameObject.GetComponent<Animator> ().SetTrigger("BumperHit");
			SoundController.GetComponent<AudioController> ().PlayBumperHit ();

			ballRigidbody = col.gameObject.GetComponent<Rigidbody2D> ();
			int tNumContacts = col.GetContacts (col.contacts);

			if(tNumContacts > 0 )
				ballRigidbody.AddForce(-1 * col.contacts[0].normal * force, ForceMode2D.Impulse);
		}
	}
}
