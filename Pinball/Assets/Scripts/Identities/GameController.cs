using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject BallPrefab;
	public GameObject EndGameMenuPrefab;
	public Text LifeBoard;
	public Text ScoreBoard;

	private bool mShootGateClosed;
	private GameObject mShooter;
	private GameObject mShootGateTop;
	private GameObject mShootGateBottom;
	private GameObject mBall;
	private GameObject mBoss;
	private GameObject mMainCamera;
	private int mScore = 0;
	private int mLife = 3;

	// Use this for initialization
	void Start () {
		mBoss 				= GameObject.Find ("Boss");
		mMainCamera 		= GameObject.Find ("Main Camera");
		mShooter 			= GameObject.Find ("Shooter");
		mShootGateTop 		= GameObject.Find ("Shoot Gate Top");
		mShootGateBottom 	= GameObject.Find ("Shoot Gate Bottom");
		mShootGateClosed 	= false;

		GameObject mBall = GameObject.Find ("Ball");
		DisableGateCollision (mBall);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake () {
		
	}

	// Determine action after a ball is destroyed
	public void BallIsDeath() {
		mBoss.GetComponent<BossController> ().DestroyUltimateWell ();
		mLife--;
		UpdateLifeBoard ();

		if (mLife == 0)
			EndGame ();
		else
			RestartGame ();
	}

	// Disable gates collision with the ball
	public void DisableGateCollision(GameObject tball) {
		mShootGateClosed = false;
		Physics2D.IgnoreCollision (tball.gameObject.GetComponent<Collider2D> (), mShootGateTop.gameObject.GetComponent<Collider2D> ());
		Physics2D.IgnoreCollision (tball.gameObject.GetComponent<Collider2D> (), mShootGateBottom.gameObject.GetComponent<Collider2D> ());
	}

	// Enable gates collision with the ball
	public void EnableGateCollision(GameObject tball) {
		mShootGateClosed = true;
		Physics2D.IgnoreCollision (tball.gameObject.GetComponent<Collider2D> (), mShootGateTop.gameObject.GetComponent<Collider2D> (), false);
		Physics2D.IgnoreCollision (tball.gameObject.GetComponent<Collider2D> (), mShootGateBottom.gameObject.GetComponent<Collider2D> (), false);
	}

	public void EndGame() {
		Time.timeScale = 0;

		int pHighScore = PlayerPrefs.GetInt ("HighScore");

		if ( pHighScore < mScore )
			PlayerPrefs.SetInt ("HighScore", mScore);
		
		// Bring up menu
		GameObject tMenu = Instantiate (EndGameMenuPrefab, new Vector3(0, 0, -9), Quaternion.identity);
		GameObject HighScoreBoard = GameObject.Find ("High Score Board");

		Text HighScoreMenu = HighScoreBoard.GetComponent<Text> ();
		if (pHighScore < mScore)
			pHighScore = mScore;
		
		HighScoreMenu.text = "High Score: " + pHighScore; 

		mMainCamera.gameObject.GetComponent<MainCameraController> ().SetCentralObject (tMenu);
	}

	public void IncreaseScore(int incScore) {
		
		mScore += incScore;
		if (mScore < 0)
			mScore = 0;
		
		UpdateScoreBoard ();
		UpdateLifeBoard ();
	}

	public bool IsShootGateClose() {
		return mShootGateClosed;
	}

	void OnLevelWasLoaded(int level) {
		if (level == 1)
			ResetLevel ();
	}

	private void ResetLevel() {
		mScore = 0;
		mLife = 3;
		Time.timeScale = 1;
	}

	private void RestartGame() {
		// Create a new ball
		if (mBall == null)
			mBall = GameObject.Find ("Ball");

		Destroy (mBall);

		GameObject tNewBall;
		tNewBall = Instantiate (BallPrefab, new Vector3(2.65f, -4.0f, 0), Quaternion.identity);

		// Tell important GameObject about the new ball
		mMainCamera.gameObject.GetComponent<MainCameraController> ().SetCentralObject (tNewBall);
		mBoss.gameObject.GetComponent<BossController> ().SetBall (tNewBall);
		mShooter.gameObject.GetComponent<ShooterController> ().SetBall (tNewBall);

		// Disable the gate to shoot the ball
		DisableGateCollision(tNewBall);
		mShootGateClosed = false;
	}

	public void UpdateLifeBoard() {
		LifeBoard.text = "" + mLife;
	}

	public void UpdateScoreBoard() {
		ScoreBoard.text = "Score: " + mScore;
	}

	public void GotDiamond() {
		mLife++;
		UpdateLifeBoard ();
		RestartGame ();
	}
}
