using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroidController : MonoBehaviour {

	public float mTorqueForce;
	public GameObject SoundController;

	private GameObject mGameController;
	private GameObject mLeftFlipper;
	private GameObject mRightFlipper;
	private GameObject mShooter;
	private GameObject mShootGate;

	private Rigidbody2D mLeftFlipperRigid;
	private Rigidbody2D mRightFlipperRigid;

	private SpriteRenderer mLeftFlipperSpriteRenderer;
	private SpriteRenderer mRightFlipperSpriteRenderer;

	private bool mGateClose;
	private Vector3 mStartPosition;
	private Vector3 mCurrentPosition;


	// Use this for initialization
	void Start () {

		#if UNITY_STANDALONE_WIN
			Destroy(this);
		#endif

		mGameController = GameObject.Find("Game Controller");
		mLeftFlipper = GameObject.Find("Left Flipper");
		mRightFlipper = GameObject.Find("Right Flipper");
		mShooter = GameObject.Find ("Shooter");

		// Set up flippers Rigidbody2D
		mLeftFlipperRigid = mLeftFlipper.GetComponent<Rigidbody2D>();
		mRightFlipperRigid = mRightFlipper.GetComponent<Rigidbody2D>();

		// Set up flippers SpritesRenderer
		mLeftFlipperSpriteRenderer = mLeftFlipper.GetComponent<SpriteRenderer>();
		mRightFlipperSpriteRenderer = mRightFlipper.GetComponent<SpriteRenderer>();

		mGateClose = false;

	}

	void FixedUpdate () {
		if (Input.touchCount != 0) {
			mGateClose = mGameController.GetComponent<GameController> ().IsShootGateClose ();
			if (mGateClose) {
				Vector3 touchPosition = Input.GetTouch(0).position;

				//Flipping right
				if (touchPosition.x >= Screen.width / 2f) {
					AddTorque (mRightFlipperRigid, -mTorqueForce);
				}

				//Flipping left
				if (touchPosition.x < Screen.width / 2f) {
					AddTorque (mLeftFlipperRigid, mTorqueForce);
				}
			}
		}
	}

	void Update() {
		// If screen is being touch
		if (Input.touchCount != 0) {
			mGateClose = mGameController.GetComponent<GameController> ().IsShootGateClose ();
			Touch tTouch = Input.GetTouch(0);

			// If the gate is open
			if (!mGateClose) {
				// Starting swipe motion for controlling the shooter
				if (tTouch.phase == TouchPhase.Began) {
					// Start telling shooter to load up
					mShooter.GetComponent<ShooterController> ().StartCharging ();
					mStartPosition = tTouch.position;
				} else if (tTouch.phase == TouchPhase.Moved) {
					// Continue to tell the shooter the change in swiping position
					// Calculate relative swipe distance and tell shooter
					float tYPositionChange = tTouch.position.y - mStartPosition.y;
					tYPositionChange = (-tYPositionChange / Screen.height ) * 0.35f;

					mShooter.GetComponent<ShooterController> ().UpdateShooterPosition (tYPositionChange);
					mStartPosition.y = tTouch.position.y;
				} else if (tTouch.phase == TouchPhase.Ended)
					mShooter.GetComponent<ShooterController> ().Shoot ();
			}
		}
	}

	void AddTorque(Rigidbody2D rigid, float force)
	{
		rigid.AddTorque(force);
	}

	public void GateIsClose(bool pClose) {
		mGateClose = pClose;
	}
}