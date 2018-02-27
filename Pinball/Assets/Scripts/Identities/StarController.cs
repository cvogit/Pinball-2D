using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public float offTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
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
