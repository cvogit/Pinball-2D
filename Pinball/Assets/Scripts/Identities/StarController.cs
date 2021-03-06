using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	private GameObject SoundController;
	public float mOffTime;

	// Use this for initialization
	void Start () {
		SoundController = GameObject.Find ("Audio Controller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			SoundController.GetComponent<AudioController> ().PlayStar ();

			TriggerTempInactive();
		}
	}

	void TriggerTempInactive()
	{
		Dissapear ();
		Invoke ("Appear", mOffTime);
	}

	void Appear() {
		gameObject.SetActive (true);
	}

	void Dissapear() {
		gameObject.SetActive (false);
	}
		
}
