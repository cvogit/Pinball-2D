using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public float pForce;
	public GameObject PullWellPrefabLarge;
	public GameObject PushWellPrefabLarge;

	public GameObject PullWellPrefabSmall;
	public GameObject PushWellPrefabSmall;
	public GameObject UltimatePullWellPrefab;

	public Sprite BossAngrySprite;
	public Sprite BossLaughSprite;

	private GameObject mGameController;
	private GameObject SoundController;
	private GameObject mBall;
	private GameObject mNewWell;
	private GameObject mUltimateWell;

	private Vector3 mCurrentPosition;

	private int  mHealth 	= 4;
	private int  mPhrase	= 0; 
	private int  mNumberOfAttacks = 0;
	private bool mProvoked 	= false;
	private float  mTimeSinceLastHit = 0f;
	private int mUltiCounter = 0;
	private bool mVulnerable = true;
	private Sprite mCurrentSprite;

	private List<GameObject> mPullWells = new List<GameObject>();
	private List<GameObject> mPushWells = new List<GameObject>();

	// Use this for initialization
	void Start () {
		mGameController = GameObject.Find ("Game Controller");
		SoundController = GameObject.Find ("Audio Controller");

		mBall = GameObject.Find ("Ball");

	}
	
	// Update is called once per frame
	void Update () {
		if (!mProvoked) {
			// TODO Sleep Animation
		} else if (mProvoked) {

			if (!mVulnerable) {
				// Play damage animation
			} else if (mNumberOfAttacks < 4 && mTimeSinceLastHit < 15f) {
				mTimeSinceLastHit += Time.deltaTime;
				if (mTimeSinceLastHit > 5f) {
					
					mUltiCounter++;
					if (mUltiCounter == 3)
						PerformUltimateMove ();
					
					mTimeSinceLastHit = 0f;
				}
			}
				
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Ball") {
			
			SoundController.GetComponent<AudioController> ().PlayBossHit ();

			Rigidbody2D ballRigidbody = col.gameObject.GetComponent<Rigidbody2D> ();
			ballRigidbody.AddForce (-1 * col.contacts [0].normal * pForce, ForceMode2D.Impulse);

			if (!mProvoked) {
				BossHit ();
				SoundController.GetComponent<AudioController> ().PlayMainSoundLoop ();

				mProvoked = true;
				mPhrase = 1;
				Invoke("TakePhraseAction", 2);
			} else {
				BossHit ();
				mHealth -= 1;
				mTimeSinceLastHit = 0f;
				if (mHealth == 0) {
					mGameController.GetComponent<GameController> ().EndGame ();
				}

				mPhrase++;
				RemoveBossAttacks ();
				DisableBallCollision ();
				// TODO PlayDamagedAnimation
				BossHit ();
				Invoke("TakePhraseAction", 2);
			}
		}
	}

	private void AddRotatingOrbitWell() {
		mCurrentPosition = gameObject.transform.position;
		mNewWell = Instantiate (PushWellPrefabSmall, mCurrentPosition + new Vector3(1.65f, 0.35f, 0), Quaternion.identity);
		SoundController.GetComponent<AudioController> ().PlayWellAppear ();
		mNewWell.AddComponent <OrbitController>() ;
		mPushWells.Add (mNewWell);
	}

	private void AddWellShield() {
		mCurrentPosition = gameObject.transform.position;
		GameObject tWellShield = Instantiate (PushWellPrefabLarge, mCurrentPosition, Quaternion.identity);
		SoundController.GetComponent<AudioController> ().PlayWellAppear ();
		mPushWells.Add (tWellShield);
		tWellShield.GetComponent<Transform> ().SetParent (gameObject.GetComponent<Transform> ());
	}

	private void BossHit(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = BossAngrySprite;
		PlayAnimation ("BossHit", 1);
		mCurrentSprite = BossLaughSprite;
		Invoke ("ChangeSprite", 1);
	}

	private void ChangeSprite(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = mCurrentSprite;
	}

	private void DisableAnimation(){
		gameObject.GetComponent<Animator> ().enabled = false;
	}

	private void DisableOrbit() {
		
		if (gameObject.GetComponent<OrbitController> ()) {
			Destroy (GetComponent<OrbitController>());
			gameObject.GetComponent<Transform> ().position = new Vector3 (0, 0, 0);
		}
	}

	private void EnableOrbit(float tRadius) {
		gameObject.AddComponent<OrbitController> ();
	}

	private void PlayAnimation(string pAnimation, float pTime){
		gameObject.GetComponent<Animator> ().enabled = true;
		gameObject.GetComponent<Animator> ().SetTrigger(pAnimation);
		Invoke ("DisableAnimation", pTime);
	}

	private void TakePhraseAction() {
		
		if (mPhrase == 1) {
			AddWellShield ();
		} else if (mPhrase == 2) {

			AddWellShield ();
			SoundController.GetComponent<AudioController> ().PlayWellAppear ();

			mCurrentPosition = gameObject.transform.position;


			mNewWell = Instantiate (PushWellPrefabSmall, mCurrentPosition + new Vector3 (1.65f, 0, 0), Quaternion.identity);
			SoundController.GetComponent<AudioController> ().PlayWellAppear ();

			mPushWells.Add (mNewWell);

			mNewWell = Instantiate (PushWellPrefabSmall, mCurrentPosition + new Vector3 (-1.65f, 0, 0), Quaternion.identity);
			SoundController.GetComponent<AudioController> ().PlayWellAppear ();

			mPushWells.Add (mNewWell);
			Invoke ("EnableBallCollision", 2);
		} else if (mPhrase == 3) {
			// Create Pull Well Orbit
			AddWellShield ();
			mVulnerable = true;

			Invoke ("AddRotatingOrbitWell", 2);
			Invoke ("AddRotatingOrbitWell", 5);
			Invoke ("AddRotatingOrbitWell", 8);
			Invoke ("EnableBallCollision", 8);
		} else if (mPhrase == 4) {
			// Create Pull Well Orbit
			AddWellShield ();
			mVulnerable = true;
			DisableBallCollision ();
			Invoke ("AddRotatingOrbitWell", 2);
			Invoke ("AddRotatingOrbitWell", 4);
			Invoke ("AddRotatingOrbitWell", 6);

			Invoke ("EnableBallCollision", 6);
		}
	}

	private void RemoveBossAttacks(){

		if (mPullWells.Count > 0) {
			foreach (GameObject well in mPullWells)
				Destroy (well);
		}

		if (mPushWells.Count > 0) {
			foreach (GameObject well in mPushWells)
				Destroy (well);
		}
	}

	private void DisableBallCollision() {
		Physics2D.IgnoreCollision (mBall.gameObject.GetComponent<Collider2D> (), gameObject.GetComponent<Collider2D> ());
	}

	private void EnableBallCollision() {
		Physics2D.IgnoreCollision (mBall.gameObject.GetComponent<Collider2D> (), gameObject.GetComponent<Collider2D> (), false);
	}

	private void PerformUltimateMove () {
		mUltimateWell = Instantiate(UltimatePullWellPrefab, new Vector3(0, -4, 0), Quaternion.identity);
		// Play boss ulti sound
		SoundController.GetComponent<AudioController> ().PlayBossUlti ();
		// Play Boss Ultimate animation for 4 secs
		Invoke ("DestroyUltimateWell", 4);
		gameObject.GetComponent<SpriteRenderer> ().sprite = BossAngrySprite;
		mCurrentSprite = BossLaughSprite;
		Invoke ("ChangeSprite", 4);
	}

	public void DestroyUltimateWell() {
		mUltiCounter = 0;
		if( mUltimateWell != null )
			Destroy (mUltimateWell);
	}

	public void Reset() {
		mHealth 	= 4;
		mPhrase	= 0; 
		mNumberOfAttacks = 0;
		mProvoked 	= false;
		mTimeSinceLastHit = 0f;
		mUltiCounter = 0;
		mVulnerable = true;
	}

	public void SetBall(GameObject pBall) {
		mBall = pBall;
	}
}
