using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		// set rigidbody velocity equal to [current forward direction] * 10f + Physics.gravity 
		rb.velocity = transform.forward * 5f + Physics.gravity;

		// declare a var of type Ray, called "moveRay" that starts from [current position] 
		// and goes [current forward direction]

		Ray moveRay = new Ray ( transform.position, transform.forward );

		// if Raycast with moveRay for 3 units is TRUE... (if there is an obstacle in front of us...)
		// then randomly turn 90 degrees left or right (around Y axis) 
		//if ( Physics.Raycast(moveRay, 3f) ) {
		if (Physics.SphereCast (moveRay, 0.9f, 2f) ) {
			int randomNum = Random.Range (0,2); // returns either 0 or 1
			if (randomNum == 0) { // turn right
				transform.Rotate (0f, 90f, 0f);

			} else if (randomNum == 1) { // turn left
				transform.Rotate (0f, -90f, 0f);

			}
		} 

	}
	
}
