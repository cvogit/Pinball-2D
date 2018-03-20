using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour {

	private float mRotateSpeed;
	private float mRadius;

	private GameObject mGameController;
	private GameObject mBoss;

	private bool mIsClockwise;
	private Vector2 mCenter;
	private float mAngle;

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
		mBoss = GameObject.Find ("Boss");
		mRotateSpeed = 0.0005f;
		mRadius = 1.5f;
		mCenter = mBoss.transform.position;
		mIsClockwise = true;
	}
	
	// Update is called once per frame
	void Update () {
		if( gameObject.tag != "Boss" )
			mCenter = mBoss.transform.position;
		else
			mCenter = new Vector3(0,0,0);

	}

	void FixedUpdate () {
		
		mAngle += mRotateSpeed + Time.deltaTime;
		var Offset = new Vector2 (Mathf.Sin (mAngle), Mathf.Cos (mAngle)) * mRadius;

		if ( mIsClockwise )
			gameObject.GetComponent<Transform>().position = mCenter + Offset;
		else 
			gameObject.GetComponent<Transform>().position = mCenter - Offset;

	}

	public void ChangeOrbitDirection(bool pIsClockwise) {
		mIsClockwise = pIsClockwise;
	}

	public void ChangeRadius(float pRadius) {
		mRadius = pRadius;
	}
}
