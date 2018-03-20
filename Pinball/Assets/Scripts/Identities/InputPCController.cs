using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPCController : MonoBehaviour {

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

	private bool mCharging;
	private bool mGateClose;
	private Vector3 mStartPosition;
	private Vector3 mCurrentPosition;


	// Use this for initialization
	void Start () {

		#if UNITY_STANDALONE_ANDROID
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

		if (Input.anyKey) {
			mGateClose = mGameController.GetComponent<GameController> ().IsShootGateClose ();
			if (mGateClose) {
				Vector3 mouseInput = Input.mousePosition;

				//Flipping right
				if ( Input.GetKey(KeyCode.Slash)) {
					AddTorque (mRightFlipperRigid, -mTorqueForce);
				}

				//Flipping left
				if ( Input.GetKey(KeyCode.Z)) {
					AddTorque (mLeftFlipperRigid, mTorqueForce);
				}
			}
		}
	}

	void Update() {

		// If mouse is being held down
		if (Input.GetMouseButton(0)) {
			mGateClose = mGameController.GetComponent<GameController> ().IsShootGateClose ();
			// If the ball is in the shoot tube
			if (!mGateClose) {
				// If currently not charging, start
				if ( !mCharging ) {
					// Start telling shooter to load up
					mShooter.GetComponent<ShooterController> ().StartCharging ();
					mCharging = true;
					mStartPosition = Input.mousePosition;
				} else {
					// If already charging and still is, calculate swiping distance since last measure
					// Continue to tell the shooter the change in swiping position
					// Calculate relative swipe distance and tell shooter
					float tYPositionChange = mStartPosition.y - Input.mousePosition.y;
					// Calculate relative Y position change according to screen height comparing to shooter pull height
					tYPositionChange = (tYPositionChange / Screen.height ) * 0.35f;

					mShooter.GetComponent<ShooterController> ().UpdateShooterPosition (tYPositionChange);
					mStartPosition.y = Input.mousePosition.y;
				}
			}
		}

		// If mouse is released while being charge, shoot
		if (!Input.GetMouseButton (0) && mCharging) {
			mShooter.GetComponent<ShooterController> ().Shoot ();
			mCharging = false;
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