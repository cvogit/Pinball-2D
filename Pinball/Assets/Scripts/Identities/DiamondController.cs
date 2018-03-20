using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour {

	public float mOffTime;

	private GameObject mGameController;
	private GameObject SoundController;

	void Start() {
		mGameController = GameObject.Find ("Game Controller");
		SoundController = GameObject.Find ("Audio Controller");
		SoundController.GetComponent<AudioController> ().PlayStar ();

	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == "Ball") {
			mGameController.GetComponent<GameController> ().GotDiamond ();
			TriggerTempInactive ();
		}
	}

	private void TriggerTempInactive()
	{
		Dissapear ();
		Invoke ("Appear", mOffTime);
	}

	private void Appear() {
		gameObject.SetActive (true);
	}

	private void Dissapear() {
		gameObject.SetActive (false);
	}
}
