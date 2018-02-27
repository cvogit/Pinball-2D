using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGateController : MonoBehaviour {

	public GameObject GameController;
	private GameController GameControllerScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "Ball" && !GameControllerScript.IsGateOn()) {
			col.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
			GameController.gameObject.GetComponent<GameController> ().EnableGateCollision ();
		}

	}
}
