using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombButtonController : MonoBehaviour {

	public GameObject mCombBumper;
	public Sprite mUnpressedButton;
	public Sprite mPressedButton;

	private bool mPressed;

	private SpriteRenderer mSelfSprite;
	private GameObject mCombController;
	private Vector3 mCombBumperPosition;

	// Use this for initialization
	void Start () {
		mPressed = false;
		mSelfSprite = gameObject.GetComponent<SpriteRenderer> ();
		mCombController = GameObject.Find ("Comb");
		mCombBumperPosition = mCombBumper.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Ball") {
			if (!mPressed) {
				mSelfSprite.sprite = mPressedButton;
				mPressed = true;
				mCombController.GetComponent<CombController> ().PressButton();
				HideCombBumper ();
				Invoke ("ResetButton", 10);
			}
		}
	}

	private void ResetButton () {
		mSelfSprite.sprite = mUnpressedButton;
		mPressed = false;
		mCombController.GetComponent<CombController> ().UnPressButton();
		ResetCombBumper ();
	}

	private void HideCombBumper() {
		mCombBumper.GetComponent<Transform> ().position = new Vector3 (10, 10, 10);
	}

	private void ResetCombBumper() {
		mCombBumper.GetComponent<Transform> ().position = mCombBumperPosition;
	}
}
