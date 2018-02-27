using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedDownBumperController : MonoBehaviour {

	private Rigidbody2D ballRb;
	public float force = 5;
	public float offTime;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {

			gameObject.GetComponent<Animator> ().SetTrigger("BumperHit");

			ballRb = col.gameObject.GetComponent<Rigidbody2D> ();
			ballRb.AddForce(-1 * col.contacts[0].normal * force, ForceMode2D.Impulse);

			TriggerTempInactive();
		}
	}

	void TriggerTempInactive()
	{
		Dissapear ();
		Invoke ("Appear", offTime);
	}

	void Appear() {
		gameObject.SetActive (true);
	}

	void Dissapear() {
		gameObject.SetActive (false);
	}
}
