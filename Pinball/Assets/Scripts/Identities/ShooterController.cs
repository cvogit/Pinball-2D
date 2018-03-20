using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterController : MonoBehaviour {

	public float  mThrust;

	public GameObject SoundController;

	private bool  mCharging;
	private float mLerpTime;
	private float mCurrentLerpTime;
	private float mYPositionChange;
	private GameObject mBall;
	private GameObject mGameController;
	private Vector3 mOriginalPosition;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
		SoundController = GameObject.Find ("Audio Controller");
	
		mBall = GameObject.Find ("Ball");
		mOriginalPosition = gameObject.transform.position;
		mYPositionChange = 0f;
		mCharging = true;
		mLerpTime = 1f;
	}
		
	void FixedUpdate () {
		if (mCharging) {

			// Move the shooter and reset distance to move to 0
			if (mYPositionChange != gameObject.transform.position.y) {
				Vector3 tPosition = gameObject.transform.position;
				tPosition.y -= mYPositionChange;

				// Shooter can't move higher than -4.85	(original position)
				if (tPosition.y > mOriginalPosition.y)
					tPosition.y = mOriginalPosition.y;

				// Shooter can't move farther than -5.2		
				if (tPosition.y < -5.2f)
					tPosition.y = -5.2f;
				
				// Move shooter according to physic time passed
				mLerpTime += Time.fixedDeltaTime;
				if (mCurrentLerpTime > mLerpTime)
					mCurrentLerpTime = mLerpTime;

				float tPerc = mCurrentLerpTime / mLerpTime;
				gameObject.transform.position = tPosition;
			
				mYPositionChange = 0f;
			}
		} else {
			// If the shooter is lower than it's original position, spring it back
			if (gameObject.transform.position.y < mOriginalPosition.y)
			{
				// Spring the shooter back into original position
				float tShooterPulledDistance = mOriginalPosition.y - gameObject.transform.position.y;
				gameObject.GetComponent<Rigidbody2D> ().MovePosition (mOriginalPosition);

				Collider2D tBallCollider = mBall.GetComponent<Collider2D> ();
				Collider2D tShooterCollider = gameObject.GetComponent<Collider2D> ();

				// Calculate how much force to add to the ball if it's touching the shooter
				if (tShooterCollider.IsTouching (tBallCollider)) {
					float tForce = mThrust * tShooterPulledDistance;
					mBall.GetComponent<Rigidbody2D>().AddForce(Vector3.up * tForce , ForceMode2D.Impulse);
				}
				SoundController.GetComponent<AudioController> ().PlayShooter ();


				// Reset any distance to move if left over.
				mYPositionChange = 0f;

			}
		}
	}
		
	public void UpdateShooterPosition(float pYPositionChange) {
		mYPositionChange += pYPositionChange;
	}

	public void Shoot () {
		StopCharging ();
	}

	public void StartCharging() {
		mCharging = true;
	}

	public void StopCharging() {
		mCharging = false;
	}

	public void SetBall(GameObject pBall) {
		mBall = pBall;
	}

}
