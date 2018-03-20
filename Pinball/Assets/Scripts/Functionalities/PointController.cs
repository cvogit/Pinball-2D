using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

	private GameObject mCanvas;
	private GameObject mGameController;

	public GameObject PopupFadePrefab;

	public int mPoint;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
		mCanvas = GameObject.Find ("Canvas");
	}

	public int GetPoint() {
		return mPoint;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Ball") {
			// Increment score
			// For object with collisions
			mGameController.gameObject.GetComponent<GameController> ().IncreaseScore (mPoint);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			// Increment score
			// Create instance of point popup animation
			GameObject tPopupFade = Instantiate (PopupFadePrefab, gameObject.transform.position, Quaternion.identity);
			tPopupFade.transform.SetParent (mCanvas.transform, false);

			// Tell popup the point value
			tPopupFade.GetComponent<PopupFadeController> ().SetText(mPoint.ToString());

			// Tell popup object where to show up
			Vector3 tTempPosition = gameObject.transform.position;
			tTempPosition.y = tTempPosition.y + 0.3f;
			tPopupFade.transform.position = tTempPosition;

			mGameController.gameObject.GetComponent<GameController> ().IncreaseScore (mPoint);
		}
	}
}
