using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexController : MonoBehaviour {

	public float blackHoleMass;
	public float radius;

	public GameObject ball;
	private const float gravitationalConstant = 6.672e-11f;

	// Use this for initialization
	void Start () {
		//ball = GameObject.Find ("Ball");
	}

	// Physic here
	void FixedUpdate () {
		if (Vector2.Distance (gameObject.transform.position, ball.transform.position) < radius) {

			Vector2 direction = ball.transform.position - transform.position;

			ball.gameObject.GetComponent<Rigidbody2D> ().velocity *= 0.7f;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**********
	 * Calculate trajectory of object being pull into vortex
	 * params: 3
	 *  -  Vector2 Center of vortex mass
	 *  -  Mass of center of vortex
	 *  -  Rigidbody of orbiting object
	 *********/
	public static Vector2 GAcceleration(Vector2 position, float mass, Rigidbody2D r) {
		Vector2 direction = position - r.position;

		float gravityForce = gravitationalConstant * ((mass * r.mass) / direction.sqrMagnitude);
		gravityForce /= r.mass;

		return direction.normalized * gravityForce * Time.fixedDeltaTime;
	}
}
