using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject Ball;
	public GameObject EndGate;
	public GameObject ScoreGate;
	public GameObject ShootGate;
	public GameObject ShootGate2;

	public Text LifeBoard;
	public Text ScoreBoard;

	private bool GateOn = true;
	private int Score = 0;
	private int Life = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Shoot the ball and continute the game
	public void ContinueGame() {
		DisableGateCollision ();
	}

	// Disable score gate collision
	public void DisableGateCollision() {
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ScoreGate.gameObject.GetComponent<Collider2D> ());
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate.gameObject.GetComponent<Collider2D> ());
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate2.gameObject.GetComponent<Collider2D> ());

		GateOn = false;
	}

	// Enable gate to block the ball
	public void EnableGateCollision() {
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ScoreGate.gameObject.GetComponent<Collider2D> (), false);
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate.gameObject.GetComponent<Collider2D> (), false);
		Physics2D.IgnoreCollision (Ball.gameObject.GetComponent<Collider2D> (), ShootGate2.gameObject.GetComponent<Collider2D> (), false);

		GateOn = true;
	}

	public void EndGame() {
		Instantiate (EndGate);
	}

	public void IncreaseScore(int incScore) {
		
		Score += incScore;
		UpdateScoreBoard ();

		// Turn gate on if it's off
		if (GateOn == false) {
			EnableGateCollision ();
		}

	}

	public bool IsGateOn(){
		return GateOn;
	}

	public int GetScore() {
		return Score;
	}

	public void HandleDeath() {
		Life--;
		UpdateLifeBoard ();
		ContinueGame ();

		if (Life == 0)
			EndGame ();
	}
		

	public void UpdateLifeBoard() {
		LifeBoard.text = "Life: " + Life;
	}

	public void UpdateScoreBoard() {
		ScoreBoard.text = "Score: " + Score;
	}


}
