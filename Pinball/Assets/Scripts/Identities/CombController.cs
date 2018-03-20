using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombController : MonoBehaviour {

	public int mButtonPoint;
	public int mAllPressedPoint;

	private GameObject mGameController;

	private int mNumButtonPressed;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
		mNumButtonPressed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PressButton() {
		mNumButtonPressed++;
		mGameController.gameObject.GetComponent<GameController> ().IncreaseScore (mButtonPoint);
		mButtonPoint *= 2;

		if (mNumButtonPressed == 4) {
			// Trigger animation
			mGameController.gameObject.GetComponent<GameController> ().IncreaseScore (mAllPressedPoint);
		}
	}

	public void UnPressButton () {
		mNumButtonPressed--;
		mButtonPoint /= 2;
	}
}
