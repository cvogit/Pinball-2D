using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject Ball;
	public GameObject EndGate;
	public GameObject ScoreGate;
	public GameObject ShootGate;
	public GameObject RightBounceWall;

	public Text LifeBoard;
	public Text ScoreBoard;
	private int Score = 0;
	private int Life = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Disable gate taht block the ball
	public void DisableGateCollision() {
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ScoreGate.gameObject.GetComponent<Collider2D> ());
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate.gameObject.GetComponent<Collider2D> ());
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), RightBounceWall.gameObject.GetComponent<Collider2D> ());
	}

	// Enable gate to block the ball
	public void EnableGateCollision() {
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ScoreGate.gameObject.GetComponent<Collider2D> (), false);
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate.gameObject.GetComponent<Collider2D> (), false);
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), RightBounceWall.gameObject.GetComponent<Collider2D> (), false);
	}

	public void EndGame() {
		Instantiate (EndGate);
	}

	public void IncreaseScore(int incScore) {
		Score += incScore;
		UpdateScoreBoard ();
	}

	public void HandleDeath() {
		Life--;
		UpdateLifeBoard ();
		ContinueGame ();

		if (Life == 0)
			EndGame ();
	}

	// Shoot the ball and continute teh game
	public void ContinueGame() {

		DisableGateCollision ();
		Invoke ("EnableGateCollision", 3);
	}

	public void UpdateLifeBoard() {
		LifeBoard.text = "Life: " + Life;
	}

	public void UpdateScoreBoard() {
		ScoreBoard.text = "Score: " + Score;
	}


}
