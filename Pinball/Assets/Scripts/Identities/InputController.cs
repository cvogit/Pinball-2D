#if UNITY_ANDROID

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public float torqueForce;

	public GameObject leftFlipper;
	public GameObject rightFlipper;

	private Rigidbody2D leftFlipperRigid;
	private Rigidbody2D rightFlipperRigid;

	private SpriteRenderer leftFlipperSpriteRenderer;
	private SpriteRenderer rightFlipperSpriteRenderer;

	// Use this for initialization
	void Start () {

		// Set up flippers Rigidbody2D
		leftFlipperRigid = leftFlipper.GetComponent<Rigidbody2D>();
		rightFlipperRigid = rightFlipper.GetComponent<Rigidbody2D>();

		// Set up flippers SpritesRenderer
		leftFlipperSpriteRenderer = leftFlipper.GetComponent<SpriteRenderer>();
		rightFlipperSpriteRenderer = rightFlipper.GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseInput = Input.mousePosition;
			//Flipping right
			if (mouseInput.x >= Screen.width / 2f)
			{
			AddTorque(rightFlipperRigid, -torqueForce);
			}

			//Flipping left
			if (mouseInput.x < Screen.width / 2f)
			{
				AddTorque(leftFlipperRigid, torqueForce);
			}
		}
	}

	void AddTorque(Rigidbody2D rigid, float force)
	{
		rigid.AddTorque(force);
	}
}

#endif



#if UNITY_STANDALONE_WIN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public float torqueForce;

	public GameObject leftFlipper;
	public GameObject rightFlipper;

	private Rigidbody2D leftFlipperRigid;
	private Rigidbody2D rightFlipperRigid;

	private SpriteRenderer leftFlipperSpriteRenderer;
	private SpriteRenderer rightFlipperSpriteRenderer;

	// Use this for initialization
	void Start () {

		// Set up flippers Rigidbody2D
		leftFlipperRigid = leftFlipper.GetComponent<Rigidbody2D>();
		rightFlipperRigid = rightFlipper.GetComponent<Rigidbody2D>();

		// Set up flippers SpritesRenderer
		leftFlipperSpriteRenderer = leftFlipper.GetComponent<SpriteRenderer>();
		rightFlipperSpriteRenderer = rightFlipper.GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void FixedUpdate () {
		if ( Input.GetKey(KeyCode.RightArrow) )
			AddTorque (rightFlipperRigid, -torqueForce);
		if ( Input.GetKey(KeyCode.LeftArrow) )
			AddTorque(leftFlipperRigid, torqueForce);
	}

	void AddTorque(Rigidbody2D rigid, float force)
	{
		rigid.AddTorque(force);
	}

}

#endif